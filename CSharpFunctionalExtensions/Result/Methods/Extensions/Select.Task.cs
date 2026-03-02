using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Map method.
        /// </summary>
        public static Task<Result<K>> Select<T, K>(this Task<Result<T>> result, Func<T, K> selector)
        {
            return result.Map(selector);
        } 
        
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Map method.
        /// </summary>
        public static Task<Result<K, E>> Select<T, E, K>(this Task<Result<T, E>> result, Func<T, K> selector)
        {
            return result.Map(selector);
        }
    }
}
