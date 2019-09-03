using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        public static Task<Result> TapIf(this Task<Result> resultTask, bool condition, Action action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        public static Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, bool condition, Action action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        public static Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, bool condition, Action<T> action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        public static Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Action action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        public static Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Action<T> action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        public static Task<Result> TapIf<_>(this Task<Result> resultTask, bool condition, Func<_> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        public static Task<Result<T>> TapIf<T, _>(this Task<Result<T>> resultTask, bool condition, Func<_> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        public static Task<Result<T>> TapIf<T, _>(this Task<Result<T>> resultTask, bool condition, Func<T, _> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        public static Task<Result<T, E>> TapIf<T, E, _>(this Task<Result<T, E>> resultTask, bool condition, Func<_> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        public static Task<Result<T, E>> TapIf<T, E, _>(this Task<Result<T, E>> resultTask, bool condition, Func<T, _> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }
    }
}
