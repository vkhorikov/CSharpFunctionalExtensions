using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests
{
    internal static class ValueTaskExtensions
    {
        public static ValueTask<T> AsValueTask<T>(this T obj) => obj.AsCompletedValueTask();
        public static ValueTask AsValueTask(this Exception exception) => ValueTask.FromException(exception);
        public static ValueTask<T> AsValueTask<T>(this Exception exception) => ValueTask.FromException<T>(exception);
    }
}