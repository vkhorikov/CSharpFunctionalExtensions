using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Result TapIf(this Result result, bool condition, Action action)
        {
            if (condition)
                return result.Tap(action);
            else
                return result;
        }

        public static Result<T> TapIf<T>(this Result<T> result, bool condition, Action action)
        {
            if (condition)
                return result.Tap(action);
            else
                return result;
        }

        public static Result<T> TapIf<T>(this Result<T> result, bool condition, Action<T> action)
        {
            if (condition)
                return result.Tap(action);
            else
                return result;
        }

        public static Result<T, E> TapIf<T, E>(this Result<T, E> result, bool condition, Action action)
        {
            if (condition)
                return result.Tap(action);
            else
                return result;
        }

        public static Result<T, E> TapIf<T, E>(this Result<T, E> result, bool condition, Action<T> action)
        {
            if (condition)
                return result.Tap(action);
            else
                return result;
        }

        public static Result TapIf<_>(this Result result, bool condition, Func<_> action)
        {
            if (condition)
                return result.Tap(action);
            else
                return result;
        }

        public static Result<T> TapIf<T, _>(this Result<T> result, bool condition, Func<_> action)
        {
            if (condition)
                return result.Tap(action);
            else
                return result;
        }

        public static Result<T> TapIf<T, _>(this Result<T> result, bool condition, Func<T, _> action)
        {
            if (condition)
                return result.Tap(action);
            else
                return result;
        }

        public static Result<T, E> TapIf<T, E, _>(this Result<T, E> result, bool condition, Func<_> action)
        {
            if (condition)
                return result.Tap(action);
            else
                return result;
        }

        public static Result<T, E> TapIf<T, E, _>(this Result<T, E> result, bool condition, Func<T, _> action)
        {
            if (condition)
                return result.Tap(action);
            else
                return result;
        }
    }
}
