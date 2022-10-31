#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static async ValueTask<Result<T>> MapIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, T> valueTask)
        {
            var result = await resultTask;
            return result.MapIf(condition, valueTask);
        }

        public static async ValueTask<Result<T, E>> MapIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<T, T> valueTask)
        {
            var result = await resultTask;
            return result.MapIf(condition, valueTask);
        }

        public static async ValueTask<Result<T>> MapIf<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, T> valueTask)
        {
            var result = await resultTask;
            return result.MapIf(predicate, valueTask);
        }

        public static async ValueTask<Result<T, E>> MapIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, T> valueTask)
        {
            var result = await resultTask;
            return result.MapIf(predicate, valueTask);
        }
    }
}
#endif
