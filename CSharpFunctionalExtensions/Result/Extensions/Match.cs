using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static TOutput Match<TOutput, TError, TValue>(this Result<TValue, TError> result, Func<TValue, TOutput> Ok, Func<TError, TOutput> Failure)
        {
            return result.IsSuccess
                ? Ok(result.Value)
                : Failure(result.Error);
        }

        public static TOutput Match<TOutput, TValue>(this Result<TValue> result, Func<TValue, TOutput> Ok, Func<string, TOutput> Failure)
        {
            return result.IsSuccess
                ? Ok(result.Value)
                : Failure(result.Error);
        }

        public static void Match<T>(this Result<T> result, Action<T> Ok, Action<string> Failure)
        {
            if (result.IsSuccess)
            {
                Ok(result.Value);
            }
            else
            {
                Failure(result.Error);
            }
        }

        public static void Match<TError, TValue>(this Result<TValue, TError> result, Action<TValue> Ok, Action<TError> Failure)
        {
            if (result.IsSuccess)
            {
                Ok(result.Value);
            }
            else
            {
                Failure(result.Error);
            }
        }

        public static T Match<T>(this Result result, Func<T> Ok, Func<string, T> Failure)
        {
            return result.IsSuccess
                ? Ok()
                : Failure(result.Error);
        }

        public static void Match(this Result result, Action Ok, Action<string> Failure)
        {
            if (result.IsSuccess)
            {
                Ok();
            }
            else
            {
                Failure(result.Error);
            }
        }
    }
}
