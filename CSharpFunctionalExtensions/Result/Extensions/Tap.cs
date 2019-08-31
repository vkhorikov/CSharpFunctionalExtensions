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

        public static Result Tap<_>(this Result result, Func<_> func)
        {
            if (result.IsSuccess)
                func();

            return result;
        }

        public static Result<T> Tap<T, _>(this Result<T> result, Func<_> func)
        {
            if (result.IsSuccess)
                func();

            return result;
        }

        public static Result<T> Tap<T, _>(this Result<T> result, Func<T, _> func)
        {
            if (result.IsSuccess)
                func(result.Value);

            return result;
        }

        public static Result<T, E> Tap<T, E, _>(this Result<T, E> result, Func<_> func)
        {
            if (result.IsSuccess)
                func();

            return result;
        }

        public static Result<T, E> Tap<T, E, _>(this Result<T, E> result, Func<T, _> func)
        {
            if (result.IsSuccess)
                func(result.Value);

            return result;
        }
    }
}
