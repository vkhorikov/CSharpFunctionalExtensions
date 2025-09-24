#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static ValueTask<Maybe<V>> SelectMany<T, U, V>(
            this Maybe<T> maybe,
            Func<T, ValueTask<Maybe<U>>> selector,
            Func<T, U, V> project)
        {
            return maybe
                .Bind(selector)
                .Map(x => project(maybe.Value, x));
        }
    }
}
#endif
