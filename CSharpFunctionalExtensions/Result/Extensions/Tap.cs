using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Result Tap(this Result result, Action action)
        {
            if (result.IsSuccess)
                action();

            return result;
        }

        public static Result<T> Tap<T>(this Result<T> result, Action action)
        {
            if (result.IsSuccess)
                action();

            return result;
        }

        public static Result<T> Tap<T>(this Result<T> result, Action<T> action)
        {
            if (result.IsSuccess)
                action(result.Value);

            return result;
        }

        public static Result<T, E> Tap<T, E>(this Result<T, E> result, Action action)
        {
            if (result.IsSuccess)
                action();

            return result;
        }

        public static Result<T, E> Tap<T, E>(this Result<T, E> result, Action<T> action)
        {
            if (result.IsSuccess)
                action(result.Value);

            return result;
        }

        public static Result Tap<K>(this Result result, Func<K> func)
        {
            if (result.IsSuccess)
                func();

            return result;
        }

        public static Result<T> Tap<T, K>(this Result<T> result, Func<K> func)
        {
            if (result.IsSuccess)
                func();

            return result;
        }

        public static Result<T> Tap<T, K>(this Result<T> result, Func<T, K> func)
        {
            if (result.IsSuccess)
                func(result.Value);

            return result;
        }

        public static Result<T, E> Tap<T, K, E>(this Result<T, E> result, Func<K> func)
        {
            if (result.IsSuccess)
                func();

            return result;
        }

        public static Result<T, E> Tap<T, K, E>(this Result<T, E> result, Func<T, K> func)
        {
            if (result.IsSuccess)
                func(result.Value);

            return result;
        }
    }
}
