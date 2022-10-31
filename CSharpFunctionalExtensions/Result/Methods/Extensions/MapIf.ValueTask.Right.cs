#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static ValueTask<Result<T>> MapIf<T>(this Result<T> result, bool condition, Func<T, ValueTask<T>> valueTask)
        {
            if (!condition)
            {
                return result.AsCompletedValueTask();
            }

            return result.Map(valueTask);
        }

        public static ValueTask<Result<T, E>> MapIf<T, E>(this Result<T, E> result, bool condition, Func<T, ValueTask<T>> valueTask)
        {
            if (!condition)
            {
                return result.AsCompletedValueTask();
            }

            return result.Map(valueTask);
        }

        public static ValueTask<Result<T>> MapIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask<T>> valueTask)
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result.AsCompletedValueTask();
            }

            return result.Map(valueTask);
        }

        public static ValueTask<Result<T, E>> MapIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, ValueTask<T>> valueTask)
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result.AsCompletedValueTask();
            }

            return result.Map(valueTask);
        }
    }
}
#endif