using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Security.Cryptography;


namespace Lloyd
{
    class User
    {
        public long id;
        public string name;
        public string access_key;
        public bool admin;
        public long last_access;

        public DateTime LastAccess
        {
            get
            {
                return (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(last_access);
            }
        }

    }


    class Database
    {

        SQLiteConnection conn;
        bool firstRun = false;

        public bool FirstRun { get { return firstRun; } }


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

        public void Open()
        {
            conn.Open();
        }

        public void Close()
        {
            conn.Close();
        }

        public bool CheckForSchema()
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

        public void CreateSchema()
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
                        "last_access integer default 0" +
                    ")", conn
                )).ExecuteNonQuery();

                Close();
            }


            // admin : 0000
            CreateUser("admin", "0000", true);

        }

        private string SHA1Sum(string input)
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

                SQLiteCommand cmd = new SQLiteCommand("SELECT id, name, admin FROM users WHERE access_card=:access_card LIMIT 1", conn);
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
                SQLiteCommand cmd = new SQLiteCommand("SELECT id, name, admin, last_access FROM users", conn);
                SQLiteDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    User u = new User();
                    u.id = reader.GetInt64(0);
                    u.name = reader.GetString(1);
                    u.admin = reader.GetBoolean(2);
                    u.last_access = reader.GetInt64(3);
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

                SQLiteCommand cmd = new SQLiteCommand("UPDATE users SET name = :name WHERE id = :id LIMIT 1", conn);
                cmd.Parameters.Add(new SQLiteParameter("id", id));
                cmd.Parameters.Add(new SQLiteParameter("name", new_name));
                cmd.ExecuteNonQuery();

                Close();
            }
        }

        public void ChangeAccessKey(long id, string new_access_key)
        {
            string new_access_key_sha1 = SHA1Sum(new_access_key);
            lock (conn)
            {
                Open();

                SQLiteCommand cmd = new SQLiteCommand("UPDATE users SET access_card = :access_card WHERE id = :id LIMIT 1", conn);
                cmd.Parameters.Add(new SQLiteParameter("id", id));
                cmd.Parameters.Add(new SQLiteParameter("access_card", new_access_key_sha1));
                cmd.ExecuteNonQuery();

                Close();
            }
        }
    }
}
