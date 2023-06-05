namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Deconstructs the given result into success and failure out parameters
        /// </summary>
        public static void Deconstruct(this Result result, out bool isSuccess, out bool isFailure)
        {
            isSuccess = result.IsSuccess;
            isFailure = result.IsFailure;
        }

        /// <summary>
        ///     Deconstructs the given result into success, failure and error out parameters
        /// </summary>
        public static void Deconstruct(this Result result, out bool isSuccess, out bool isFailure, out string error)
        {
            isSuccess = result.IsSuccess;
            isFailure = result.IsFailure;
            error = result.IsFailure ? result.Error : default;
        }

        /// <summary>
        ///     Deconstructs the given result into success and failure out parameters
        /// </summary>
        public static void Deconstruct<T>(this Result<T> result, out bool isSuccess, out bool isFailure)
        {
            isSuccess = result.IsSuccess;
            isFailure = result.IsFailure;
        }

        /// <summary>
        ///     Deconstructs the given result into success, failure and value out parameters
        /// </summary>
        public static void Deconstruct<T>(this Result<T> result, out bool isSuccess, out bool isFailure, out T value)
        {
            isSuccess = result.IsSuccess;
            isFailure = result.IsFailure;
            value = result.IsSuccess ? result.Value : default;
        }

        /// <summary>
        ///     Deconstructs the given result into success, failure, value and error out parameters
        /// </summary>
        public static void Deconstruct<T>(this Result<T> result, out bool isSuccess, out bool isFailure, out T value, out string error)
        {
            isSuccess = result.IsSuccess;
            isFailure = result.IsFailure;
            value = result.IsSuccess ? result.Value : default;
            error = result.IsFailure ? result.Error : default;
        }

        /// <summary>
        ///     Deconstructs the given result into success and failure out parameters
        /// </summary>
        public static void Deconstruct<T, E>(this Result<T, E> result, out bool isSuccess, out bool isFailure)
        {
            isSuccess = result.IsSuccess;
            isFailure = result.IsFailure;
        }

        /// <summary>
        ///     Deconstructs the given result into success, failure and value out parameters
        /// </summary>
        public static void Deconstruct<T, E>(this Result<T, E> result, out bool isSuccess, out bool isFailure, out T value)
        {
            isSuccess = result.IsSuccess;
            isFailure = result.IsFailure;
            value = result.IsSuccess ? result.Value : default;
        }

        /// <summary>
        ///     Deconstructs the given result into success, failure, value and error out parameters
        /// </summary>
        public static void Deconstruct<T, E>(this Result<T, E> result, out bool isSuccess, out bool isFailure, out T value, out E error)
        {
            isSuccess = result.IsSuccess;
            isFailure = result.IsFailure;
            value = result.IsSuccess ? result.Value : default;
            error = result.IsFailure ? result.Error : default;
        }
    }
    
}
