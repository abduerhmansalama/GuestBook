using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guestbook.Core.Helper
{
   public static class HelperMethods
    {
         public static string Key = "bla@@##bla#@#@";
        public static string EncryPasswor(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            password += Key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }
        public static string DecryPasswor(string EncryptPass)
        {
            if (string.IsNullOrEmpty(EncryptPass)) return "";
            var base64EncodeBytes = Convert.FromBase64String(EncryptPass);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            result = result.Substring(0, result.Length - Key.Length);
            return result;
        }

    }
}
