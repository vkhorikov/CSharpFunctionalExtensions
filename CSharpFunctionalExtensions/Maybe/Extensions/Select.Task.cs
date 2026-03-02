using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Map method.
        /// </summary>
        public static Task<Maybe<K>> Select<T, K>(this Task<Maybe<T>> maybe, Func<T, K> selector)
        {
            return maybe.Map(selector);
        }
    }
}
