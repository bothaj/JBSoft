using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Tangent.Web.Helpers
{
    public class CommonHelper
    {
        public static string NewHashedPassword()
        {
            var guid = Guid.NewGuid();
            var random = guid.ToString();
            return random.Substring(0, 9).Replace("-", "");

            //return GetPasswordHash(random).ToString();
        }

        public static byte[] GetPasswordHash(string password)
        {
            using (MD5 csp = new MD5CryptoServiceProvider())
            {
                return csp.ComputeHash(new ASCIIEncoding().GetBytes(password));
            }
        }

        //Returns the first 8 chars of a Guid as a random user id
        public static string UserIdGuid(Guid userId)
        {
            var random = userId.ToString();
            return random.Substring(0, 9).Replace("-", "");
        }
    }
}
