using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Result<T, E> OnFailureCompensate<T, E>(this Result<T, E> result,
            Func<Result<T, E>> func)
        {
            if (result.IsFailure)
                return func();

            return result;
        }
        
        public static Result<T> OnFailureCompensate<T>(this Result<T> result, Func<Result<T>> func)
        {
            if (result.IsFailure)
                return func();

            return result;
        }
        
        public static Result OnFailureCompensate(this Result result, Func<Result> func)
        {
            if (result.IsFailure)
                return func();

            return result;
        }
        
        public static Result<T, E> OnFailureCompensate<T, E>(this Result<T, E> result,
            Func<E, Result<T, E>> func)
        {
            if (result.IsFailure)
                return func(result.Error);

            return result;
        }
        
        public static Result<T> OnFailureCompensate<T>(this Result<T> result, Func<string, Result<T>> func)
        {
            if (result.IsFailure)
                return func(result.Error);

            return result;
        }

        public static Result OnFailureCompensate(this Result result, Func<string, Result> func)
        {
            if (result.IsFailure)
                return func(result.Error);

            return result;
        }
    }
}
