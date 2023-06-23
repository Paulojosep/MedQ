using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MedQ.Application.Utils
{
    public class Seguranca
    {
        public static string HashMd5(string valor)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(valor));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
