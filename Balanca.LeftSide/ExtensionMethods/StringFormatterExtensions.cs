namespace Balanca.LeftSide.ExtensionMethods
{
    public static class StringFormatterExtensions
    {
        public static string FormatCpf(this string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !ulong.TryParse(value, out ulong cpf)) return string.Empty;
            return cpf.ToString(@"000\.000\.000\-00");
        }

        public static string FormatCnpj(this string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !ulong.TryParse(value, out ulong cnpj)) return string.Empty;
            return cnpj.ToString(@"00\.000\.000\.000\-00");
        }

        public static string FormatCep(this string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !uint.TryParse(value, out uint cep)) return string.Empty;
            return cep.ToString(@"00000\-00");
        }
    }
}
