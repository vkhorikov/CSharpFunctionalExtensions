using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Map method.
        /// </summary>
        public static Result<K> Select<T, K>(in this Result<T> result, Func<T, K> selector)
        {
            return result.Map(selector);
        }
    }
}
