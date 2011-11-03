using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using NHibernate;
using NHibernate.Criterion;

namespace Lloyd.Database.Entities
{
    public class User
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string AccessKey { get; set; }
        public virtual bool IsAdmin { get; set; }
        public virtual DateTime LastAccess { get; set; }
        public virtual bool IsEnabled { get; set; }

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

        public virtual void EncodeAccessKey(string input)
        {
            AccessKey = SHA1Sum(input);
        }

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

        
    }
}
