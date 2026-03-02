#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Map method.
        /// </summary>
        public static ValueTask<Result<K>> Select<T, K>(in this ValueTask<Result<T>> result, Func<T, K> selector)
        {
            return result.Map(selector);
        } 
        
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Map method.
        /// </summary>
        public static ValueTask<Result<K, E>> Select<T, E, K>(in this ValueTask<Result<T, E>> result, Func<T, K> selector)
        {
            return result.Map(selector);
        }
    }
}
#endif
