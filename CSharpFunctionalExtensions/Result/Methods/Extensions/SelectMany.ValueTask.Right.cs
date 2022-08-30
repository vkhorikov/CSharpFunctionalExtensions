#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static ValueTask<Result<TR>> SelectMany<T, TK, TR>(
            this Result<T> result,
            Func<T, ValueTask<Result<TK>>> valueTask,
            Func<T, TK, TR> project)
        {
            return result
                .Bind(valueTask)
                .Map(x => project(result.Value, x));
        }

        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static ValueTask<Result<TR, TE>> SelectMany<T, TK, TE, TR>(
            this Result<T, TE> result,
            Func<T, ValueTask<Result<TK, TE>>> valueTask,
            Func<T, TK, TR> project)
        {
            return result
                .Bind(valueTask)
                .Map(x => project(result.Value, x));
        }
    }
}
#endif