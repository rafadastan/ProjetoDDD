using Projeto.Domain.Contracts.CrossCutting;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Projeto.CrossCutting
{
    public class MD5Cryptography : IMD5Cryptography
    {
        public string Encrypt(string value)
        {
            var hash = new MD5CryptoServiceProvider()
                .ComputeHash(Encoding.UTF8.GetBytes(value));

            var result = string.Empty;

            foreach (var item in hash)
            {
                result += item.ToString("x2");
            }
            return result;
        }
    }
}
