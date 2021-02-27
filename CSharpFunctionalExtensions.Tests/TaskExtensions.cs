using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests
{
    internal static class TaskExtensions
    {
        public static Task<T> AsTask<T>(this T obj) => Task.FromResult(obj);
    }
}