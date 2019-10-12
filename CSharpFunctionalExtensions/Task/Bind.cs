using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class TaskExtensions
    {
        /// <summary>
        ///     Selects task from a given function.
        /// </summary>
        public static async Task Bind(this Task task, Func<Task> func)
        {
            await task.ConfigureAwait(Result.DefaultConfigureAwait);
            await func().ConfigureAwait(Result.DefaultConfigureAwait);
        }

        /// <summary>
        ///     Selects task from a given function.
        /// </summary>
        public static async Task Bind<T>(this Task<T> task, Func<T, Task> func)
        {
            var value = await task.ConfigureAwait(Result.DefaultConfigureAwait);
            await func(value).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        /// <summary>
        ///     Selects task from a given function.
        /// </summary>
        public static async Task<TR> Bind<TR>(this Task task, Func<Task<TR>> func)
        {
            await task.ConfigureAwait(Result.DefaultConfigureAwait);
            return await func().ConfigureAwait(Result.DefaultConfigureAwait);
        }

        /// <summary>
        ///     Selects task from a given function.
        /// </summary>
        public static async Task<TR> Bind<T, TR>(this Task<T> task, Func<T, Task<TR>> func)
        {
            var value = await task.ConfigureAwait(Result.DefaultConfigureAwait);
            return await func(value).ConfigureAwait(Result.DefaultConfigureAwait);
        }
    }
}