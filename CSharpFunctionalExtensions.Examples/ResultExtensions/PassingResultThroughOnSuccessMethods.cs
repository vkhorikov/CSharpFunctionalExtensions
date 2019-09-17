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
            return Result.Success(1);
        }

        private Result<string> FunctionString(int intValue)
        {
            return Result.Success("Ok");
        }

        private Result<string> FunctionString()
        {
            return Result.Success("Ok");
        }

        private Result<DateTime> FunctionDateTime(string stringValue)
        {
            return Result.Success(DateTime.Now);
        }
    }
}
