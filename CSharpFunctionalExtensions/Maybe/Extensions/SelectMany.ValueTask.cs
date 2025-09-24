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
        public static ValueTask<Maybe<K>> SelectMany<T, K>(
            this Maybe<T> maybe,
            Func<T, ValueTask<Maybe<K>>> selector)
        {
            return maybe.Bind(selector);
        } 
        
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static ValueTask<Maybe<K>> SelectMany<T, K>(
            this ValueTask<Maybe<T>> maybeTask,
            Func<T, ValueTask<Maybe<K>>> selector)
        {
            return maybeTask.Bind(selector);
        }
        
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static async ValueTask<Maybe<V>> SelectMany<T, U, V>(
            this ValueTask<Maybe<T>> maybeTask,
            Func<T, ValueTask<Maybe<U>>> selector,
            Func<T, U, V> project)
        {
            var maybe = await maybeTask;
            return await maybe.SelectMany(selector, project);
        }
    }
}
#endif
