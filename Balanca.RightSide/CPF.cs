using Balanca.Core.Exceptions;
using System.Linq;
using System.Text.RegularExpressions;

namespace Balanca.RightSide
{
    public class CPF : ValidableSingleBase<string>
    {
        public CPF()
        {

        }

        public CPF(string value) : base(value)
        {

        }

        public override void Validate(string value)
        {
            if (!Regex.IsMatch(value, @"^\d{11}$"))
                throw new RegexException();

            if (!IsPatternValid(value))
                throw new PatternException();
        }

        private bool IsPatternValid(string value)
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

        public override string ToString()
        {
            return ulong.TryParse(Value, out ulong cpf) ? cpf.ToString(@"000\.000\.000\-00") : string.Empty;
        }
    }
}
