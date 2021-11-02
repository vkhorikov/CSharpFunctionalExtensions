namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Flattens nested <see cref="Maybe{T}" />s into a single <see cref="Maybe{T}" />.
        /// </summary>
        /// <returns>The flattened <see cref="Maybe{T}" />.</returns>
        public static Maybe<T> Flatten<T>(in this Maybe<Maybe<T>> maybe)
        {
            return maybe.GetValueOrDefault();
        }
    }
}