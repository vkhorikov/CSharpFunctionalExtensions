using System;
using System.Threading.Tasks;
#if !TASKEX
using TaskEx = System.Threading.Tasks.Task;
#endif
namespace System {
    public static class ResultTAsyncExtensions {
        //#BindAsync
        public static Task<Result<T>> BindAsync<P1, T>(in this Result<P1> result, Func<P1, Task<Result<T>>> func) 
            => (result.IsFailure) ? TaskEx.FromResult(Result<T>.Fail(result.Error))
                            : func(result.Value)
                                .ContinueWith(completedtask =>
                                {
                                    if (completedtask.IsFaulted)
                                    {
                                        return Result<T>.Fail(ResultError.AsyncResultUnitError);
                                    }
                                    else if (completedtask.IsCanceled)
                                    {
                                        return Result<T>.Fail(ResultError.Cancelled);
                                    }
                                    
                                    return completedtask.Result;
                                });
        public static Task<Result<T>> BindAsync<P1, T>( this Task<Result<P1>> result, Func<P1, Result<T>> func) 
            => result.ContinueWith(z =>
                {
                    if (z.IsFaulted)
                    {
                        return Result<T>.Fail(ResultError.AsyncResultUnitError);
                    }
                    else if (z.IsCanceled)
                    {
                        return Result<T>.Fail(ResultError.Cancelled);
                    }
                    return z.Result.Bind(func);
                });

        public static Task<Result<T>> BindAsync<P1, T>( this Task<Result<P1>> result, Func<P1, Task<Result<T>>> func)
             => result.ContinueWith(z =>
             {
                 if (z.IsFaulted)
                 {
                     return Result<T>.Fail(ResultError.AsyncResultUnitError);
                 }
                 else if (z.IsCanceled)
                 {
                     return Result<T>.Fail(ResultError.Cancelled);
                 }
                 return BindAsync(z.Result, func).GetAwaiter().GetResult();
             });

        public static Task<Result<T>> BindAsync<P1, P2, T>( this Task<Result<P1>> task1, Task<Result<P2>> task2, Func<P1, P2, Task<Result<T>>> functask3) 
            => task1.ContinueWith(z =>
            {
                if (z.IsFaulted)
                {
                    return Result<T>.Fail(ResultError.AsyncResultExceptionUnexpected);
                }
                else if (z.IsCanceled)
                {
                    return Result<T>.Fail(ResultError.Cancelled);
                }
                if (z.Result.IsFailure)
                {
                    return Result<T>.Fail(z.Result.Error);
                }
                Result<P2> xx = task2.ConfigureAwait(false).GetAwaiter().GetResult();
                if (xx.IsFailure)
                {
                    return Result<T>.Fail(xx.Error);
                }
                return functask3(z.Result.Value, xx.Value).GetAwaiter().GetResult();
            });
        public static Task<Result<T>> BindAsync<P1, P2, T>( this Task<Result<P1>> task1, Task<Result<P2>> task2, Func<P1, P2, Result<T>> functask3) 
            => task1.ContinueWith(z =>
            {
                if (z.IsFaulted)
                {
                    return Result<T>.Fail(ResultError.AsyncResultExceptionUnexpected);
                }
                else if (z.IsCanceled)
                {
                    return Result<T>.Fail(ResultError.Cancelled);
                }
                if (z.Result.IsFailure)
                {
                    return Result<T>.Fail(z.Result.Error);
                }
                Result<P2> xx = task2.ConfigureAwait(false).GetAwaiter().GetResult();
                if (xx.IsFailure)
                {
                    return Result<T>.Fail(xx.Error);
                }
                return functask3(z.Result.Value, xx.Value);
            });

        //#MapAsync
        public static Task<Result<T>> MapAsync<P1, T>(in this Result<P1> result, Func<P1, Task<T>> func, Func<Exception, Enum> errorConvert = null) {
            if (result.IsFailure)
                return TaskEx.FromResult(Result<T>.Fail(result.Error));
            return func(result.Value).ContinueWith(completedtask => {
                if (completedtask.IsFaulted) {
                    return Result<T>.Fail(errorConvert is null ? ResultError.AsyncResultUnitError : errorConvert(completedtask.Exception));
                } else if (completedtask.IsCanceled) {
                    return Result<T>.Fail(ResultError.Cancelled);
                }
                return Result.Ok(completedtask.Result);
            });
        }
        public static Task<Result<T>> MapAsync<P1, T>(this Task<Result<P1>> result, Func<P1, T> func, Func<Exception, Enum> errorConvert = null) {
            return result.ContinueWith(completedtask => {
                if (completedtask.IsFaulted) {
                    return Result<T>.Fail(errorConvert is null ? ResultError.AsyncResultUnitError : errorConvert(completedtask.Exception));
                } else if (completedtask.IsCanceled) {
                    return Result<T>.Fail(ResultError.Cancelled);
                }
                return completedtask.Result.Map(func, errorConvert);
            });
        }
        public static Task<Result<T>> MapAsync<P1, T>(this Task<Result<P1>> result, Func<P1, Task<T>> func, Func<Exception, Enum> errorConvert = null) {
            return result.ContinueWith(completedtask => {
                if (completedtask.IsFaulted) {
                    return Result<T>.Fail(errorConvert is null ? ResultError.AsyncResultUnitError : errorConvert(completedtask.Exception));
                } else if (completedtask.IsCanceled) {
                    return Result<T>.Fail(ResultError.Cancelled);
                }
                if (completedtask.Result.IsFailure) {
                    return Result<T>.Fail(completedtask.Result.Error);
                }
                return MapAsync(completedtask.Result, func, errorConvert).GetAwaiter().GetResult();
            });
        }
        //#EnsureAsync
      
        public static Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> result,Func<T,Enum> errorfunc) {
            return result.ContinueWith(completedtask => {
                if (completedtask.IsFaulted) {
                    return Result<T>.Fail(ResultError.AsyncResultUnitError);
                } else if (completedtask.IsCanceled) {
                    return Result<T>.Fail(ResultError.Cancelled);
                }
                return completedtask.Result.Ensure( errorfunc);
            });
        }
        //#SelfAsync
        public static Task<Result<P1>> SelfAsync<P1, T>( this Result<P1> result, Func<P1, Task<Result<T>>> func) {
            return result.BindAsync(func).ContinueWith(z => {
                if (z.IsFaulted) {
                    return Result<P1>.Fail(ResultError.AsyncResultUnitError);
                } else if (z.IsCanceled) {
                    return Result<P1>.Fail(ResultError.Cancelled);
                } else if (z.Result.IsFailure) {
                    return Result<P1>.Fail(z.Result.Error);
                }
                return result;
            });
        }

    }
}
