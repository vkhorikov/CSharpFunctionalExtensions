#if NET5_0_OR_GREATER
#nullable enable

using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static ValueTask<Result<T>> EnsureNotNull<T>(this Result<T?> result, Func<ValueTask<string>> errorFactory)
            where T : class
        {
            return result.Ensure(value => ValueTask.FromResult(value != null), _ => errorFactory()).Map(value => value!);
        }

        public static ValueTask<Result<T>> EnsureNotNull<T>(this Result<T?> result, Func<ValueTask<string>> errorFactory)
            where T : struct
        {
            return result.Ensure(value => ValueTask.FromResult(value != null), _ => errorFactory()).Map(value => value!.Value);
        }

        public static ValueTask<Result<T, E>> EnsureNotNull<T, E>(this Result<T?, E> result, Func<ValueTask<E>> errorFactory)
            where T : class
        {
            return result.Ensure(value => ValueTask.FromResult(value != null), _ => errorFactory()).Map(value => value!);
        }

        public static ValueTask<Result<T, E>> EnsureNotNull<T, E>(this Result<T?, E> result, Func<ValueTask<E>> errorFactory)
            where T : struct
        {
            return result.Ensure(value => ValueTask.FromResult(value != null), _ => errorFactory()).Map(value => value!.Value);
        }
    }
}
#endif