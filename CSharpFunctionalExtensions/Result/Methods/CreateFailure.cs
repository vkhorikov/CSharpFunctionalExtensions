using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        public static Result CreateFailure(bool isFailure, string error)
            => Create(!isFailure, error);

        public static Result CreateFailure(Func<bool> failurePredicate, string error)
            => Create(!failurePredicate(), error);

        public static async Task<Result> CreateFailure(Func<Task<bool>> failurePredicate, string error)
        {
            bool isFailure = await failurePredicate().ConfigureAwait(DefaultConfigureAwait);
            return Create(!isFailure, error);
        }

        public static Result<T> CreateFailure<T>(bool isFailure, T value, string error)
            => Create(!isFailure, value, error);

        public static Result<T> CreateFailure<T>(Func<bool> failurePredicate, T value, string error)
            => Create(!failurePredicate(), value, error);

        public static async Task<Result<T>> CreateFailure<T>(Func<Task<bool>> failurePredicate, T value, string error)
        {
            bool isFailure = await failurePredicate().ConfigureAwait(DefaultConfigureAwait);
            return Create(!isFailure, value, error);
        }

        public static Result<T, E> CreateFailure<T, E>(bool isFailure, T value, E error)
            => Create(!isFailure, value, error);

        public static Result<T, E> CreateFailure<T, E>(Func<bool> failurePredicate, T value, E error)
            => Create(!failurePredicate(), value, error);

        public static async Task<Result<T, E>> CreateFailure<T, E>(Func<Task<bool>> failurePredicate, T value, E error)
        {
            bool isFailure = await failurePredicate().ConfigureAwait(DefaultConfigureAwait);
            return Create(!isFailure, value, error);
        }
    }
}
