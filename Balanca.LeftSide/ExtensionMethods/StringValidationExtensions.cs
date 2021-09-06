using Balanca.Core.Exceptions;
using System.Linq;
using System.Text.RegularExpressions;

namespace Balanca.LeftSide.ExtensionMethods
{
    public static class StringValidationExtensions
    {
        public static bool IsCpfValid(this string value)
        {
            try
            {
                ValidateCpf(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsCnpjValid(this string value)
        {
            try
            {
                ValidateCnpj(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsCepValid(this string value)
        {
            try
            {
                ValidateCep(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void ValidateCpf(this string value)
        {
            if (!Regex.IsMatch(value, @"^\d{11}$"))
                throw new RegexException();

            if (!IsCpfPatternValid(value))
                throw new PatternException();
        }

        public static void ValidateCnpj(this string value)
        {
            if (!Regex.IsMatch(value, @"^\d{14}$"))
                throw new RegexException();
        }

        public static void ValidateCep(this string value)
        {
            if (!Regex.IsMatch(value, @"^\d{5}$"))
                throw new RegexException();
        }

        private static bool IsCpfPatternValid(this string value)
        {
            switch (value)
            {
                case "00000000000":
                    return false;
                case "11111111111":
                    return false;
                case "22222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
            }

            if (value.Length != 11)
                return false;

            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digit;
            int sum;
            int remainder;

            value = value.Trim();
            value = value.Replace(".", "").Replace("-", "");

            if (!value.All(char.IsNumber))
            {
                return false;
            }

            if (value.Length != 11)
                return false;

            tempCpf = value.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

            remainder = sum % 11;

            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;

            digit = remainder.ToString();
            tempCpf += digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

            remainder = sum % 11;
            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;

            digit += remainder.ToString();

            return value.EndsWith(digit);
        }

    }
}
