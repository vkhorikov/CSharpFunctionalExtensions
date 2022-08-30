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
        public static async ValueTask<Result<TR>> SelectMany<T, TK, TR>(
            this ValueTask<Result<T>> resultTask,
            Func<T, Result<TK>> valueTask,
            Func<T, TK, TR> project)
        {
            Result<T> result = await resultTask;
            return result.SelectMany(valueTask, project);
        }

        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static async ValueTask<Result<TR, TE>> SelectMany<T, TK, TE, TR>(
            this ValueTask<Result<T, TE>> resultTask,
            Func<T, Result<TK, TE>> valueTask,
            Func<T, TK, TR> project)
        {
            Result<T, TE> result = await resultTask;
            return result.SelectMany(valueTask, project);
        }
    }
}
#endif