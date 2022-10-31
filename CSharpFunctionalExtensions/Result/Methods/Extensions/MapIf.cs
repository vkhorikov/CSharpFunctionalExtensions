using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Result<T> MapIf<T>(this Result<T> result, bool condition, Func<T, T> func)
        {
            if (!condition)
            {
                return result;
            }

            return result.Map(func);
        }

        public static Result<T, E> MapIf<T, E>(this Result<T, E> result, bool condition, Func<T, T> func)
        {
            if (!condition)
            {
                return result;
            }

            return result.Map(func);
        }

        public static Result<T> MapIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, T> func)
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result;
            }

            return result.Map(func);
        }

        public static Result<T, E> MapIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, T> func)
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result;
            }

            return result.Map(func);
        }
    }
}
