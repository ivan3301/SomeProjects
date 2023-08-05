using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace ProjectLib
{
    class ClassMD5
    {
        public static string encryptedPass(string pass)
        {
            MD5 md5 = MD5.Create();
            byte[] b = Encoding.ASCII.GetBytes(pass); //Кодирование в набор байтов
            byte[] hash = md5.ComputeHash(b); //Перевод в хэш-функцию
            StringBuilder sb = new StringBuilder();
            foreach (var a in hash)
                sb.Append(a.ToString("X2"));
            return Convert.ToString(sb);
        }
    }
}
