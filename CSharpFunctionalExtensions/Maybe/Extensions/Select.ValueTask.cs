#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Map method.
        /// </summary>
        public static ValueTask<Maybe<K>> Select<T, K>(in this ValueTask<Maybe<T>> maybe, Func<T, K> selector)
        {
            return maybe.Map(selector);
        }
    }
}
#endif
