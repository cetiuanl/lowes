using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace LowesCN
{
    public class SHA
    {
        public static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
    }

    public static class IntegerExtensions
    {
        public static int ParseInt(this string value, int defaultValue = 0)
        {
            int parsedValue;
            if (int.TryParse(value, out parsedValue))
            {
                return parsedValue;
            }

            return defaultValue;
        }

        public static int? ParseNullableInt(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            return value.ParseInt();
        }
    }

    public static class DecimalExtensions
    {
        public static decimal ParseDecimal(this string value, decimal defaultValue = 0)
        {
            value = value.Replace("$", "");
            decimal parsedValue;
            if (decimal.TryParse(value, out parsedValue))
            {
                return parsedValue;
            }

            return defaultValue;
        }

    }
}
