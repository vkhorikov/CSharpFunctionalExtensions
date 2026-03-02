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
        public static async ValueTask<Maybe<V>> SelectMany<T, U, V>(
            this ValueTask<Maybe<T>> maybeTask,
            Func<T, Maybe<U>> selector,
            Func<T, U, V> project)
        {
            Maybe<T> maybe = await maybeTask;
            return maybe.SelectMany(selector, project);
        }
    }
}
#endif
