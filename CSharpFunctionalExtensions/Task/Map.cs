using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class TaskExtensions
    {
        /// <summary>
        ///     Creates a new task from the return value of a given function.
        /// </summary>
        public static async Task<TR> Map<TR>(this Task task, Func<TR> func)
        {
            await task.ConfigureAwait(Result.DefaultConfigureAwait);
            return func();
        }

        /// <summary>
        ///     Creates a new task from the return value of a given function.
        /// </summary>
        public static async Task<TR> Map<T, TR>(this Task<T> task, Func<T, TR> func)
        {
            var value = await task.ConfigureAwait(Result.DefaultConfigureAwait);
            return func(value);
        }
    }
}