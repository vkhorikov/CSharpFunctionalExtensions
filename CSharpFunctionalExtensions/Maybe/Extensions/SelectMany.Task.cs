using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static Task<Maybe<K>> SelectMany<T, K>(
            this Maybe<T> maybe,
            Func<T, Task<Maybe<K>>> selector)
        {
            return maybe.Bind(selector);
        } 
        
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static Task<Maybe<K>> SelectMany<T, K>(
            this Task<Maybe<T>> maybeTask,
            Func<T, Task<Maybe<K>>> selector)
        {
            return maybeTask.Bind(selector);
        }
        
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static async Task<Maybe<V>> SelectMany<T, U, V>(
            this Task<Maybe<T>> maybeTask,
            Func<T, Task<Maybe<U>>> selector,
            Func<T, U, V> project)
        {
            var maybe = await maybeTask.DefaultAwait();
            return await maybe.SelectMany(selector, project).DefaultAwait();
        }
    }
}
