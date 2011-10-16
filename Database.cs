/*
 * Lloyd - An alcohol and tab monitoring program.
 * Copyright 2011 Michael Farrell <http://micolous.id.au/>.
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Security.Cryptography;


namespace Lloyd
{
    public class User
    {
        public long id;
        public string name;
        public string access_key;
        public bool admin;
        public long last_access;
        public bool enabled;

        public DateTime LastAccess
        {
            get
            {
                return (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(last_access);
            }
        }

    }

    /// <summary>
    /// Database access layer for Lloyd.
    /// 
    /// Note: This library is not thread-safe, call only one thing at a time.  Otherwise it will likely fall over.
    /// </summary>
    public class Database
    {

        SQLiteConnection conn;
        bool firstRun = false;

        /// <summary>
        /// If this is the first time that Lloyd has been run (or more specifically,
        /// a file/schema was created), then this will be true.
        /// </summary>
        public bool FirstRun { get { return firstRun; } }

        /// <summary>
        /// Creates a new connection to a Lloyd database file.  If the file doesn't already exist, it will be created.
        /// </summary>
        /// <param name="filename">The path to the database file.</param>
        public Database(string filename)
        {
            SQLiteConnectionStringBuilder csb = new SQLiteConnectionStringBuilder();
            csb.Add("Data Source", filename);
            csb.Add("Version", "3");

            conn = new SQLiteConnection(csb.ToString());

            if (!CheckForSchema())
            {
                firstRun = true;
                CreateSchema();
            }
        }

        void Open()
        {
            conn.Open();
        }

        void Close()
        {
            conn.Close();
        }

        bool CheckForSchema()
        {
            bool success = false;

            lock (conn)
            {
                Open();

                SQLiteCommand cmd = new SQLiteCommand("SELECT version FROM meta LIMIT 1", conn);

                try
                {
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        return false;
                    }

                    if (reader.GetInt16(0) == 1)
                    {
                        success = true;
                    }
                    else
                    {
                        throw new ArgumentException(
                            "Specified file contains a database that is either not belonging to " +
                            "Lloyd, or is from a newer version. (expected meta.version == 1)"
                        );
                    }

                    reader.Close();
                }
                catch (SQLiteException)
                {
                    // probably means that the table doesn't exist
                    success = false;
                }
                finally
                {
                    Close();
                }
            }

            return success;
        }

        void CreateSchema()
        {
            lock (conn)
            {
                Open();
                (new SQLiteCommand(
                    "CREATE TABLE meta (" +
                        "version int " +
                    ")", conn
                )).ExecuteNonQuery();

                (new SQLiteCommand("INSERT INTO meta VALUES (1);", conn)).ExecuteNonQuery();

                (new SQLiteCommand(
                    "CREATE TABLE users (" +
                        "id integer primary key autoincrement, " +
                        "name varchar, " +
                        "access_card varchar, " +
                        "admin integer default 0, " +
                        "enabled integer default 1, " +
                        "last_access integer default 0" +
                    ")", conn
                )).ExecuteNonQuery();

                Close();
            }


            // admin : 0000
            CreateUser("admin", "0000", true);

        }

        /// <summary>
        /// Computes an SHA1 checksum of the input string.
        /// </summary>
        /// <param name="input">The string to compute the checksum for.</param>
        /// <returns>A base16 encoding of the checksum.</returns>
        string SHA1Sum(string input)
        {
            SHA1 s = SHA1.Create();
            byte[] b = s.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input));

            return BitConverter.ToString(b).Replace("-", string.Empty);
        }

        public User GetUserByAccessKey(string access_key)
        {
            string access_key_sha1 = SHA1Sum(access_key);
            User u = new User();

            lock (conn)
            {
                Open();

                SQLiteCommand cmd = new SQLiteCommand("SELECT id, name, admin FROM users WHERE enabled=1 AND access_card=:access_card LIMIT 1", conn);
                cmd.Parameters.Add(new SQLiteParameter("access_card", access_key_sha1));


                try
                {
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        u = null;
                    }
                    else
                    {
                        u.id = reader.GetInt64(0);
                        u.name = reader.GetString(1);
                        u.admin = reader.GetBoolean(2);
                        u.access_key = access_key;
                    }

                    reader.Close();
                }
                catch (SQLiteException)
                {
                    // probably means that the table doesn't exist
                    u = null;
                }
                finally
                {
                    Close();
                }

            }
            return u;
        }

        /// <summary>
        /// Similar to GetUserByAccessKey, except this also updates the last_access time in the database.
        /// 
        /// The object returned will have the user's old last_access time, not the current one.
        /// </summary>
        /// <param name="access_key">The user's access key to find.</param>
        /// <returns>The User associated with that access key, or null if no user exists.</returns>
        public User LoginUser(string access_key)
        {
            User u = GetUserByAccessKey(access_key);
            if (u != null)
            {
                Open();
                SQLiteCommand cmd = new SQLiteCommand("UPDATE users SET last_access = strftime('%s', 'now') WHERE id = :id", conn);
                cmd.Parameters.Add(new SQLiteParameter("id", (object)(u.id)));
                cmd.ExecuteNonQuery();
                Close();
            }

            return u;
        }

        public void CreateUser(string user, string access_key, bool admin)
        {
            // check to see if the access key has been used.
            User u = GetUserByAccessKey(access_key);
            if (u != null)
            {
                throw new ArgumentException("Access key is already in use.");
            }

            string access_key_sha1 = SHA1Sum(access_key);

            lock (conn)
            {
                Open();
                SQLiteCommand cmd = new SQLiteCommand("INSERT INTO users (name, access_card, admin) VALUES (:name, :access_card, :admin)", conn);
                cmd.Parameters.Add(new SQLiteParameter("name", user));
                cmd.Parameters.Add(new SQLiteParameter("access_card", access_key_sha1));
                cmd.Parameters.Add(new SQLiteParameter("admin", admin));
                cmd.ExecuteNonQuery();
                
                Close();

            }
        }

        public IList<User> GetAllUsers()
        {
            List<User> lu = new List<User>();
            lock (conn)
            {
                Open();
                SQLiteCommand cmd = new SQLiteCommand("SELECT id, name, admin, last_access, enabled FROM users", conn);
                SQLiteDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    User u = new User();
                    u.id = reader.GetInt64(0);
                    u.name = reader.GetString(1);
                    u.admin = reader.GetBoolean(2);
                    u.last_access = reader.GetInt64(3);
                    u.enabled = reader.GetBoolean(4);
                    lu.Add(u);
                }

                Close();
            }
            return lu;
        }


        public void DeleteUser(long id)
        {
            lock (conn)
            {
                Open();

                SQLiteCommand cmd = new SQLiteCommand("DELETE FROM users WHERE id = :id LIMIT 1", conn);
                cmd.Parameters.Add(new SQLiteParameter("id", id));
                cmd.ExecuteNonQuery();

                Close();
            }

        }

        public void RenameUser(long id, string new_name)
        {
            lock (conn)
            {
                Open();

                SQLiteCommand cmd = new SQLiteCommand("UPDATE users SET name = :name WHERE id = :id", conn);
                cmd.Parameters.Add(new SQLiteParameter("id", id));
                cmd.Parameters.Add(new SQLiteParameter("name", new_name));
                cmd.ExecuteNonQuery();

                Close();
            }
        }

        public void ChangeAccessKey(long id, string new_access_key)
        {
            User u = GetUserByAccessKey(new_access_key);

            if (u != null)
            {
                if (u.id == id)
                {
                    // then we're just changing to the same access key again,
                    // do nothing and move along.
                    return;
                }

                throw new ArgumentException("That access key is already in use by another user.");
            }


            string new_access_key_sha1 = SHA1Sum(new_access_key);
            lock (conn)
            {
                Open();

                SQLiteCommand cmd = new SQLiteCommand("UPDATE users SET access_card = :access_card WHERE id = :id", conn);
                cmd.Parameters.Add(new SQLiteParameter("id", id));
                cmd.Parameters.Add(new SQLiteParameter("access_card", new_access_key_sha1));
                cmd.ExecuteNonQuery();

                Close();
            }
        }

        public void SetUserEnabled(long id, bool new_state)
        {
            lock (conn)
            {
                Open();

                SQLiteCommand cmd = new SQLiteCommand("UPDATE users SET enabled=:enabled WHERE id = :id", conn);
                cmd.Parameters.Add(new SQLiteParameter("id", id));
                cmd.Parameters.Add(new SQLiteParameter("enabled", new_state));
                cmd.ExecuteNonQuery();

                Close();
            }
        }

        public void SetUserAdministrator(long id, bool new_admin)
        {
            lock (conn)
            {
                Open();

                SQLiteCommand cmd = new SQLiteCommand("UPDATE users SET admin=:admin WHERE id = :id", conn);
                cmd.Parameters.Add(new SQLiteParameter("id", id));
                cmd.Parameters.Add(new SQLiteParameter("admin", new_admin));
                cmd.ExecuteNonQuery();

                Close();
            }
        
        }
    }
}
