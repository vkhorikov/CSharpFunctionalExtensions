using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    { 
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static async Task<Maybe<V>> SelectMany<T, U, V>(
            this Task<Maybe<T>> maybeTask,
            Func<T, Maybe<U>> selector,
            Func<T, U, V> project)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();
            return maybe.SelectMany(selector, project);
        }
    }
}
