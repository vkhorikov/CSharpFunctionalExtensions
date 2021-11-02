using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public abstract class CheckTestsBase : TestBase
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

        protected Func<T, UnitResult<E>> Func_Result_TE(bool isSuccess)
        {
            return isSuccess
                ? new Func<T, UnitResult<E>>(t =>
                {
                    actionExecuted = true;
                    return UnitResult.Success<E>();
                })
                : t =>
                {
                    actionExecuted = true;
                    return FailedUnitResultE;
                };
        }

        protected Func<UnitResult<E>> Func_UnitResult_E(bool isSuccess)
        {
            return isSuccess
                ? new Func<UnitResult<E>>(() =>
                {
                    actionExecuted = true;
                    return UnitResult.Success<E>();
                })
                : () =>
                {
                    actionExecuted = true;
                    return FailedUnitResultE;
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

        protected Func<T, Task<UnitResult<E>>> Func_Task_Result_TE(bool isSuccess)
        {
            return isSuccess
                ? new Func<T, Task<UnitResult<E>>>(t =>
                {
                    actionExecuted = true;
                    return UnitResult.Success<E>().AsTask();
                })
                : t =>
                {
                    actionExecuted = true;
                    return FailedUnitResultE.AsTask();
                };
        }

        protected Func<Task<UnitResult<E>>> Func_Task_UnitResult_E(bool isSuccess)
        {
            return isSuccess
                ? new Func<Task<UnitResult<E>>>(() =>
                {
                    actionExecuted = true;
                    return UnitResult.Success<E>().AsTask();
                })
                : () =>
                {
                    actionExecuted = true;
                    return FailedUnitResultE.AsTask();
                };
        }

        protected Func<T, ValueTask<Result<K>>> Func_ValueTask_Result_K(bool isSuccess)
        {
            return isSuccess
                ? new Func<T, ValueTask<Result<K>>>(t =>
                {
                    actionExecuted = true;
                    return Result.Success(K.Value).AsValueTask();
                })
                : t =>
                {
                    actionExecuted = true;
                    return FailedResultK.AsValueTask();
                };
        }

        protected Func<T, ValueTask<Result<K, E>>> Func_ValueTask_Result_KE(bool isSuccess)
        {
            return isSuccess
                ? new Func<T, ValueTask<Result<K, E>>>(t =>
                {
                    actionExecuted = true;
                    return Result.Success<K, E>(K.Value).AsValueTask();
                })
                : t =>
                {
                    actionExecuted = true;
                    return FailedResultKE.AsValueTask();
                };
        }

        protected Func<T, ValueTask<UnitResult<E>>> Func_ValueTask_Result_TE(bool isSuccess)
        {
            return isSuccess
                ? new Func<T, ValueTask<UnitResult<E>>>(t =>
                {
                    actionExecuted = true;
                    return UnitResult.Success<E>().AsValueTask();
                })
                : t =>
                {
                    actionExecuted = true;
                    return FailedUnitResultE.AsValueTask();
                };
        }

        protected Func<ValueTask<UnitResult<E>>> Func_ValueTask_UnitResult_E(bool isSuccess)
        {
            return isSuccess
                ? new Func<ValueTask<UnitResult<E>>>(() =>
                {
                    actionExecuted = true;
                    return UnitResult.Success<E>().AsValueTask();
                })
                : () =>
                {
                    actionExecuted = true;
                    return FailedUnitResultE.AsValueTask();
                };
        }
        
        protected Result<T> FailedResultT => Result.Failure<T>(ErrorMessage);
        protected Result<K> FailedResultK => Result.Failure<K>(ErrorMessage);
        protected Result<K, E> FailedResultKE => Result.Failure<K, E>(E.Value);
        protected UnitResult<E> FailedUnitResultE => UnitResult.Failure(E.Value);
        protected Result FailedResult => Result.Failure(ErrorMessage);
    }
}