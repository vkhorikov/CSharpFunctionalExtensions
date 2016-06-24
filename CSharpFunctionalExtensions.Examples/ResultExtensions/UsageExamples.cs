using System;


namespace CSharpFunctionalExtensions.Examples.ResultExtensions
{
    public class Passing_result_through_OnSuccess_methods
    {
        public void Example1()
        {
            Result<DateTime> result = FunctionInt()
                .OnSuccess(x => FunctionString(x))
                .OnSuccess(x => FunctionDateTime(x));
        }

        public void Example2()
        {
            Result<DateTime> result = FunctionInt()
                .OnSuccess(() => FunctionString())
                .OnSuccess(x => FunctionDateTime(x));
        }

        private Result<int> FunctionInt()
        {
            return Result.Ok(1);
        }

        private Result<string> FunctionString(int intValue)
        {
            return Result.Ok("Ok");
        }

        private Result<string> FunctionString()
        {
            return Result.Ok("Ok");
        }

        private Result<DateTime> FunctionDateTime(string stringValue)
        {
            return Result.Ok(DateTime.Now);
        }
    }
}
