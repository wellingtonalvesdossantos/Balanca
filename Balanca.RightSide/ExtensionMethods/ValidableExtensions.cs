namespace Balanca.RightSide.ExtensionMethods
{
    public static class ValidableExtensions
    {
        public static bool IsValid<T>(this IValidable<T> validable, T value)
        {
            try
            {
                validable.Validate(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
