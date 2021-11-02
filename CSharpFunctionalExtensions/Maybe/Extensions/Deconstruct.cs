namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static void Deconstruct<T>(in this Maybe<T> result, out bool hasValue, out T value)
        {
            hasValue = result.HasValue;
            value = result.GetValueOrDefault();
        }
    }
}