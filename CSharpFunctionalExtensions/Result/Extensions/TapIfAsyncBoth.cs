using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        public static Task<Result> TapIf(this Task<Result> resultTask, bool condition, Func<Task> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        public static Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, bool condition, Func<Task> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        public static Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        public static Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<Task> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        public static Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<T, Task> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }
    }
}
