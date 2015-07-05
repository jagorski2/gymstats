using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace StartingStatsWeb
{
    public class crypto
    {
        public static string sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }


        internal static string validateCookies(HttpCookieCollection cook)
        {
            if ((cook["username"] != null) && cook["secureCookie"] != null)
            {
                gymstatDB mydb = new gymstatDB();
                crypto mycrypto = new crypto();
                string username = cook["username"].Value;
                string hashedpw = mydb.getHashedPassword(username);
                string trueHashed = crypto.sha256_hash(hashedpw + username);

                if (cook["secureCookie"].Value.StartsWith(trueHashed))
                {
                    return username;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        internal static bool validateCookies(HttpCookieCollection cook, bool test)
        {
            if ((cook["username"] != null) && cook["secureCookie"] != null)
            {
                gymstatDB mydb = new gymstatDB();
                string username = cook["username"].Value;
                string hashedpw = mydb.getHashedPassword(username);
                string trueHashed = crypto.sha256_hash(hashedpw + username);

                if (cook["secureCookie"].Value == trueHashed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            else
            {
                return false;
            }
        }

        internal static void installCookies(HttpCookieCollection httpCookieCollection, string username, string password)
        {
            httpCookieCollection["username"].Value = username;
            httpCookieCollection["username"].Expires = DateTime.Now.AddDays(1);
            httpCookieCollection["secureCookie"].Value = crypto.sha256_hash(password + username);
            httpCookieCollection["secureCookie"].Expires = DateTime.Now.AddDays(1);
        }
    }
}