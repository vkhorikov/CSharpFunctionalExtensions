using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public readonly partial struct Result<T>
    {
        /// <summary>
        /// Bind operation for performing do-notation like LINQ operation.
        /// </summary>
        public Result<K> Select<K>(Func<T, K> func) =>
            IsFailure ? Result.Failure<K>(Error) : func(Value);

        /// <summary>
        /// Bind operation for performing do-notation like LINQ operation.
        /// </summary>
        public async Task<Result<K>> Select<K>(Func<T, Task<K>> func) {
            if (IsFailure)
            {
                return Result.Failure<K>(Error);
            }

            return await func(Value).DefaultAwait();
        }

        public Result<C> SelectMany<K, C>(
            Func<T, Result<K>> bind, Func<T, K, C> project
        ) {
            if (IsFailure)
            {
                return Result.Failure<C>(Error);
            }

            var resultToBind = bind(Value);

            return resultToBind.IsFailure
                ? Result.Failure<C>(resultToBind.Error)
                : project(Value, resultToBind.Value);
        }

        public async Task<Result<C>> SelectMany<B, C>(
            Func<T, Result<B>> bind, Func<T, B, Task<C>> project
        ) {
            if (IsFailure) {
                return Result.Failure<C>(Error);
            }

            var resultToBind = bind(Value);

            if (resultToBind.IsFailure)
            {
                return Result.Failure<C>(resultToBind.Error);
            }

            return await project(Value, resultToBind.Value).DefaultAwait();
        }
    }
}
