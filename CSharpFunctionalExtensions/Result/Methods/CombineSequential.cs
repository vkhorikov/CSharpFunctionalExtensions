using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public  partial struct  Result
    {

        /// <summary>
        ///     Combines several results (and any error messages) into a single result.
        ///     The returned result will be a failure if any of the input <paramref name="results"/> are failures.
        ///     Error message will have the first value of the failure operation
        /// </summary>
        /// <typeparam name="TReturnData">Type we will map</typeparam>
        /// <typeparam name="TDataA">Type of the function  <paramref name="a"/></typeparam>
        /// <typeparam name="TDataB">>Type of the function  <paramref name="b"/></typeparam>
        /// <param name="a">First function that we want to execute</param>
        /// <param name="b">Second function that we want to execute</param>
        /// <param name="combineFunction">Functional to map all the result into <paramref name="TReturnData"/> </param>
        /// <returns></returns>
        public static async Task<Result<TReturnData>> CombineSequential<TReturnData, TDataA, TDataB>(
            Func<Task<Result<TDataA>>> a,
            Func<Task<Result<TDataB>>> b,
            Func<(TDataA DataA, TDataB DataB), TReturnData> combineFunction)
            => await (await a())
                  .Bind(async resultA => (await b()).Map(resultB => combineFunction((resultA, resultB))));
    }
}