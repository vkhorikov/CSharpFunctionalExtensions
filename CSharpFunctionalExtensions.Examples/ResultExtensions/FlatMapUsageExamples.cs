using System;
using System.Threading.Tasks;
using System.IO;

namespace CSharpFunctionalExtensions.Examples.ResultExtensions
{
    public class FlatMapUsageExamples
    {
        //"TryParseInt" is a common example of wrapping a native unsafe function into a result
        //
        //When using TryParseInt inside Map(), would end up with a nested result (Result<Result<int>>)
        //This creates a challenge when chaining the next function with OnSuccess or OnFailure
        //Instead, we can use FlatMap to "lift" the inner Result out of the enclosing Result

        public static void Main()
        {
            //In many cases, we might start off with a Result of some primitive type
            Result<string> NumberInAString = Result.Ok("123");
            Result<string> NotANumberInAString = Result.Ok("abc");

            //Flatmap ensures the OnFailure logic works as expected in these scenarios
            Result<int> ResultOfInt = NumberInAString
                .FlatMap(myNumStr => TryParseInt(myNumStr));
            
            ResultOfInt
                .OnFailure(message => { /*message is the message from TryParseInt*/})
                .OnSuccess(actualInt => { /*actualInt is the raw value we wanted*/});

            //Here's what Map would have returned:
            Result<Result<int>> NestedResult = NumberInAString
                .Map(myNumStr => TryParseInt(myNumStr));

            //Chaining this would require nested OnSuccess, which undermines the OnFailure logic
            NestedResult
                .OnSuccess(resultOfInt => resultOfInt
                    .OnFailure(message => { /*message is the message from TryParseInt*/})
                    .OnSuccess(actualInt => { /*actualInt is the raw value we wanted*/}));

            //We can't get back to the top level pipeline with our inner result effectively
            //This is one of the reasons FlatMap exists in Functional Programming
        }

        public static Result<int> TryParseInt(string value)
        {
            bool Status = Int32.TryParse(value, out int Number);
            if (Status)
            {
                return Result.Ok(Number);
            }
            else
            {
                return Result.Fail<int>("Could not parse string as number");
            }
        }
    }
}
