/*
 * Lloyd - An alcohol and tab monitoring program.
 * Copyright 2011-2012 Michael Farrell <http://micolous.id.au/>.
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
using System.Security.Cryptography;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace Lloyd.Database.Entities
{
    public class User
    {
        public virtual int Id { get; private set; }

        /// <summary>
        /// The user's name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// The user's access key, in a hashed (SHA1) form.  Use EncodeAccessKey() in order to
        /// set this to a new value.
        /// </summary>
        public virtual string AccessKey { get; set; }

        /// <summary>
        /// Is the user an administrator of the system?
        /// </summary>
        public virtual bool IsAdmin { get; set; }

        /// <summary>
        /// When did the user last log in to the system?
        /// </summary>
        public virtual DateTime LastAccess { get; set; }

        /// <summary>
        /// Is the user's account active?
        /// </summary>
        public virtual bool IsEnabled { get; set; }

        /// <summary>
        /// Is the user biologically male?  This is used to approximate BAC.
        /// </summary>
        public virtual bool IsBiologicallyMale { get; set; }

        /// <summary>
        /// The user's weight, in kilograms.
        /// </summary>
        public virtual int Weight { get; set; }

        /// <summary>
        /// The user's height, in centimetres.
        /// </summary>
        public virtual int Height { get; set; }

        /// <summary>
        /// Computes an SHA1 checksum of the input string.
        /// </summary>
        /// <param name="input">The string to compute the checksum for.</param>
        /// <returns>A base16 encoding of the checksum.</returns>
        static string SHA1Sum(string input)
        {
            SHA1 s = SHA1.Create();
            byte[] b = s.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input));

            return BitConverter.ToString(b).Replace("-", string.Empty);
        }

        /// <summary>
        /// Sets a new access key for the user.  This performs an SHA1 hash of the inputted code.
        /// </summary>
        /// <param name="input"></param>
        public virtual void EncodeAccessKey(string input)
        {
            AccessKey = SHA1Sum(input);
        }

        /// <summary>
        /// Looks up a user by their access key.
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static User GetUserByAccessKey(ISessionFactory factory, string key)
        {
            key = SHA1Sum(key);
            using (var session = factory.OpenSession())
            {
                var r = session.CreateCriteria(typeof(User))
                    .Add(
                        Restrictions.Eq("AccessKey", key)
                    ).List<User>();

                if (r.Count == 1)
                {
                    return r[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
