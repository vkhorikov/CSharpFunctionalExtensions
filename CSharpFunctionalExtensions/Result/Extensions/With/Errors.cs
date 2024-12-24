namespace CSharpFunctionalExtensions
{
    public static class Errors
    {
        public static string Join(string e1, string e2)
        {
            return string.Join(Result.ErrorMessagesSeparator, e1, e2);
        }
    }
}