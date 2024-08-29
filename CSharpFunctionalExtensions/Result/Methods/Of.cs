using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        /// <summary>
        ///     Creates a successful <see cref="Result{T}" /> containing the given value.
        /// </summary>
        public static Result<T> Of<T>(T value) where T : notnull
        {
            return new Result<T>(false, default, value);
        }

        /// <summary>
        ///     Creates a successful <see cref="Result{T}" /> containing the given value from a <see cref="Func{T}" />.
        /// </summary>
        public static Result<T> Of<T>(Func<T> func) where T : notnull
        {
            T value = func();

            return new Result<T>(false, default, value);
        }

        /// <summary>
        ///     Creates a successful <see cref="Result{T}" /> containing the given async value.
        /// </summary>
        public static async Task<Result<T>> Of<T>(Task<T> valueTask) where T : notnull
        {
            T value = await valueTask;

            return new Result<T>(false, default, value);
        }

        /// <summary>
        ///     Creates a successful <see cref="Result{T}" /> containing the given value from an async <see cref="Func{T}" />.
        /// </summary>
        public static async Task<Result<T>> Of<T>(Func<Task<T>> valueTaskFunc) where T : notnull
        {
            T value = await valueTaskFunc();

            return new Result<T>(false, default, value);
        }

        /// <summary>
        ///     Creates a successful <see cref="Result{T}" /> containing the given value.
        /// </summary>
        public static Result<T, E> Of<T, E>(T value) where T : notnull
        {
            return new Result<T, E>(false, default, value);
        }

        /// <summary>
        ///     Creates a successful <see cref="Result{T}" /> containing the given value from a <see cref="Func{T}" />.
        /// </summary>
        public static Result<T, E> Of<T, E>(Func<T> func) where T : notnull
        {
            T value = func();

            return new Result<T, E>(false, default, value);
        }

        /// <summary>
        ///     Creates a successful <see cref="Result{T}" /> containing the given async value.
        /// </summary>
        public static async Task<Result<T, E>> Of<T, E>(Task<T> valueTask) where T : notnull
        {
            T value = await valueTask;

            return new Result<T, E>(false, default, value);
        }

        /// <summary>
        ///     Creates a successful <see cref="Result{T}" /> containing the given value from an async <see cref="Func{T}" />.
        /// </summary>
        public static async Task<Result<T, E>> Of<T, E>(Func<Task<T>> valueTaskFunc) where T : notnull
        {
            T value = await valueTaskFunc();

            return new Result<T, E>(false, default, value);
        }
    }
}
