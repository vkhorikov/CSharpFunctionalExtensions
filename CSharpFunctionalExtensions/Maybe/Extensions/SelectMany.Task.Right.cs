using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static Task<Maybe<V>> SelectMany<T, U, V>(
            this Maybe<T> maybe,
            Func<T, Task<Maybe<U>>> selector,
            Func<T, U, V> project)
        {
            return maybe
                .Bind(selector)
                .Map(x => project(maybe.Value, x));
        }
    }
}
