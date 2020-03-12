using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests
{
    internal static class TaskExtensions
    {
        public static async Task<T> AsTask<T>(this T obj) => obj;
    }
}