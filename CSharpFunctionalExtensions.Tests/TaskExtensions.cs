using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests
{
    internal static class TaskExtensions
    {
        public static Task<T> AsTask<T>(this T obj) => Task.FromResult(obj);
        public static Task AsTask(this Exception exception) => Task.FromException(exception);
        public static Task<T> AsTask<T>(this Exception exception) => Task.FromException<T>(exception);
    }
}