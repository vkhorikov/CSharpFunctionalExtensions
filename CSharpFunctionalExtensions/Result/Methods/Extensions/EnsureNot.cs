using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Returns a new failure result if the predicate is true. Otherwise returns the starting result.
        /// </summary>
        public static Result<T> EnsureNot<T>(this Result<T> result, Func<T, bool> test, string error) =>
            result.Ensure(v => !test(v), error);
        
        /// <summary>
        ///     Returns a new failure result if the predicate is true. Otherwise returns the starting result.
        /// </summary>
        public static Result<T, E> EnsureNot<T, E>(this Result<T, E> result, Func<T, bool> test, E error) =>
            result.Ensure(v => !test(v), error);
    }
}
