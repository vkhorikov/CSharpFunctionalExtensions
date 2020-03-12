using System.Threading.Tasks;

#if NET40
using Task = System.Threading.Tasks.TaskEx;
using Microsoft.Runtime.CompilerServices;
#else
using Task = System.Threading.Tasks.Task;
using System.Runtime.CompilerServices;
#endif

namespace CSharpFunctionalExtensions
{
    internal static class TaskExtensions
    {
        public static Task<T> AsCompletedTask<T>(this T obj) => Task.FromResult(obj);

        public static ConfiguredTaskAwaitable DefaultAwait(this System.Threading.Tasks.Task task) => task.ConfigureAwait(Result.DefaultConfigureAwait);

        public static ConfiguredTaskAwaitable<T> DefaultAwait<T>(this Task<T> task) => task.ConfigureAwait(Result.DefaultConfigureAwait);
    }
}