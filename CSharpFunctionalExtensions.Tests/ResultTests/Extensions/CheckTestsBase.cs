using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class CheckTestsBase : TestBase
    {
        protected bool actionExecuted;
        
        protected Result GetResult(bool isSuccess)
        {
            actionExecuted = true;
            return isSuccess
                ? Result.Success()
                : FailedResult;
        }
        
        protected Func<T, Result<K>> Func_Result_K(bool isSuccess)
        {
            return isSuccess
                ? new Func<T, Result<K>>(t =>
                {
                    actionExecuted = true;
                    return Result.Success(K.Value);
                })
                : t =>
                {
                    actionExecuted = true;
                    return FailedResultK;
                };
        }

        protected Func<T, Result<K, E>> Func_Result_KE(bool isSuccess)
        {
            return isSuccess
                ? new Func<T, Result<K, E>>(t =>
                {
                    actionExecuted = true;
                    return Result.Success<K, E>(K.Value);
                })
                : t =>
                {
                    actionExecuted = true;
                    return FailedResultKE;
                };
        }
        
        protected Func<T, Task<Result<K>>> Func_Task_Result_K(bool isSuccess)
        {
            return isSuccess
                ? new Func<T, Task<Result<K>>>(t =>
                {
                    actionExecuted = true;
                    return Result.Success(K.Value).AsTask();
                })
                : t =>
                {
                    actionExecuted = true;
                    return FailedResultK.AsTask();
                };
        }

        protected Func<T, Task<Result<K, E>>> Func_Task_Result_KE(bool isSuccess)
        {
            return isSuccess
                ? new Func<T, Task<Result<K, E>>>(t =>
                {
                    actionExecuted = true;
                    return Result.Success<K, E>(K.Value).AsTask();
                })
                : t =>
                {
                    actionExecuted = true;
                    return FailedResultKE.AsTask();
                };
        }
        
        protected Result<T> FailedResultT => Result.Failure<T>(ErrorMessage);
        protected Result<K> FailedResultK => Result.Failure<K>(ErrorMessage);
        protected Result<K, E> FailedResultKE => Result.Failure<K, E>(E.Value);
        protected Result FailedResult => Result.Failure(ErrorMessage);
    }
}