using System.Threading.Tasks;

#if NET40
using Task = System.Threading.Tasks.TaskEx;
#else
using Task = System.Threading.Tasks.Task;
#endif

namespace CSharpFunctionalExtensions.Tests
{
    internal static class TaskExtensions
    {
        public static Task<T> AsCompletedTask<T>(this T obj) => Task.FromResult(obj);
    }
}