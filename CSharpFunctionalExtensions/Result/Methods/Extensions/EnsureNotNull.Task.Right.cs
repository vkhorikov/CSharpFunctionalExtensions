#nullable enable

using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Task<Result<T>> EnsureNotNull<T>(this Result<T?> result, Func<Task<string>> errorFactory)
            where T : class
        {
            return result.Ensure(value => Task.FromResult(value != null), _ => errorFactory()).Map(value => value!);
        }

        public static Task<Result<T>> EnsureNotNull<T>(this Result<T?> result, Func<Task<string>> errorFactory)
            where T : struct
        {
            return result.Ensure(value => Task.FromResult(value != null), _ => errorFactory()).Map(value => value!.Value);
        }

        public static Task<Result<T, E>> EnsureNotNull<T, E>(this Result<T?, E> result, Func<Task<E>> errorFactory)
            where T : class
        {
            return result.Ensure(value => Task.FromResult(value != null), _ => errorFactory()).Map(value => value!);
        }

        public static Task<Result<T, E>> EnsureNotNull<T, E>(this Result<T?, E> result, Func<Task<E>> errorFactory)
            where T : struct
        {
            return result.Ensure(value => Task.FromResult(value != null), _ => errorFactory()).Map(value => value!.Value);
        }
    }
}
