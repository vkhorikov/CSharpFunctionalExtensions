using System;


namespace CSharpFunctionalExtensions.Examples.ResultExtensions
{
    public class PassingResultThroughOnSuccessMethods
    {
        public void Example1()
        {
            Result<DateTime> result = FunctionInt()
                .Bind(x => FunctionString(x))
                .Bind(x => FunctionDateTime(x));
        }

        public void Example2()
        {
            Result<DateTime> result = FunctionInt()
                .Bind(_ => FunctionString())
                .Bind(x => FunctionDateTime(x));
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
