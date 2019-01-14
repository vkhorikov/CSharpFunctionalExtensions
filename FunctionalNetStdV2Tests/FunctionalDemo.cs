using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalNetStdV2Tests {
    [TestClass]
    public class FunctionalDemo {
        //Demonstrates simplied use of sync and async functions 
        // in the elevated world of results.
        // Plus, shows uplifting the world of dotnet standard Result naive functions into the results world
        //Scott Wlashin Functional Programming style -- composition
        //https://www.youtube.com/watch?v=WhEkBCWpDas&t=1291s
        //# AIM TO SIMPLIFY 
        // 1. Method chaining railway track style
        // 2. asynchronous methods handled using async extensions and minimising the number of 'awaits' needed
        // 3. uplifting non Result<T> returning functions (both sync and async) to the world of results 
        //# Design is almost monadic (~95%)
        //# Use of CSharp 7.2 feature
        //# --> 'in' keyword on extensions Result parameters, to reduce size of call stack 

        [TestMethod]
        public void BindSync() {

            //chain three functions that each synchronously return a Result<'T> 

            //F# pipe forward equivalent
            // RGetHtml()
            //|>ProcessHtml
            //|>RGetLength

            Result<int> result = RGetHtml()
                .Bind(RChopHtml)     // note use of simplied version of    .Bind(stringval=>ProcessHtml(stringval))  i.e Function is used in place of lambda
                .Bind(RGetLength);
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("innerhtml".Length, result.Value);

        }

        [TestMethod]
        public async Task BindAsync() {
            //chain three functions that each asynchronously return Result<'T> 
            //note the simplified call with only one await statement 

            //F# pipe forward equivalent
            // await RGetHtmlAsync()
            //|>RChopHtmlAsync
            //|>RGetLengthAsync

            Result<int> result = await RGetHtmlAsync()
               .BindAsync(RChopHtmlAsync)
               .BindAsync(RGetLengthAsync);

            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("innerhtml".Length, result.Value);

        }
        [TestMethod]
        public async Task BindSyncAsync() {
            //chain 2 functions that return Result<'T> asynchronously with a synchronous function sandwiched betwween
            //note the simplified call with only one await statement 
            //Note the synchronous function is still within the BindAsync extension method 
            //the BindAsync extension method binds syncronous lambdas to asynchronous results and
            //the call chain retains just a single await call


            //F# pipe forward equivalent
            // await RGetHtmlAsync()
            //|>RChopHtml
            //|>RGetLengthAsync

            Result<int> result = await RGetHtmlAsync()
               .BindAsync(RChopHtml)
               .BindAsync(RGetLengthAsync);
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("innerhtml".Length, result.Value);

        }


        [TestMethod]
        public void MapSync() {
            //start with Result<string>
            //pass through two functions(Raw) that have not concept of Result<T> using Map
            //Note that Map is equivalent to convert return value to Result<T> then perform Bind
            //Map brings the world of dotnet funtions UP into the world of Results


            //chain 2 functions that return strings or ints synchronously

            //F# pipe forward equivalent
            // Result.Ok(..)
            //|>ChopHtml
            //|>GetLength

            Result<int> result = Result.Ok("<html>innerhtml</html>")
                .Map(ChopHtml)
                .Map(GetLength);
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("innerhtml".Length, result.Value);

        }
        [TestMethod]
        public async Task MapASync() {
            //start with Result<string>
            //pass through two functions(Raw) that have not concept of Result<T> using Map
            //Note that Map is equivalent to convert return value to Result<T> then perform Bind
            //Map brings the world of dotnet funtions UP into the world of Results


            //chain 2 functions that return strings or ints synchronously

            //F# pipe forward equivalent
            // await Result.Ok(GetHtmlAsync())
            //|>ChopHtmlAsync
            //|>GetLengthAsync

            Result<int> result = await Result.Ok(await GetHtmlAsync())
                .MapAsync(ChopHtmlAsync)
                .MapAsync(GetLengthAsync);
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("innerhtml".Length, result.Value);

        }

        [TestMethod]
        public void MapAndBindSync() {
            //start with Result<string>
            //pass through two functions 
            //First use map
            //Then use Bind

            //F# pipe forward equivalent
            // Result.Ok(..)
            //|>ChopHtml
            //|>RGetLength

            Result<int> result = Result.Ok("<html>innerhtml</html>")
                .Map(ChopHtml)
                .Bind(RGetLength);
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("innerhtml".Length, result.Value);

        }



        [TestMethod]
        public void Errors() {
            //Error values can be any Enum
            //Enums are a little better than magic strings
            //Error values can be tested
            //no more hacks of string enums
            Result<int> result = Result<int>.Fail(System.Net.HttpStatusCode.Unauthorized);

            if (result.IsFailure) {
                if (result.Error.Equals(System.Net.HttpStatusCode.Unauthorized)) {
                    //handle System.Net.HttpStatusCode.Unauthorized


                } else if (result.Error.Equals(System.IO.SeekOrigin.End)) {
                    //handle System.IO.SeekOrigin.End  just an example
                    //Note that we would usually not handle different Enum types from a single function
                    //But we can now process the result of multiple function chined
                    // all returning different error Enums.

                }
            }
        }
        [TestMethod]
        public void Exceptions() {
            //Map the World of Exceptions to an Enum on Result
           var result=  RGetHtml()
                .Map(s => throw new Exception(), e => ResultError.UnhandledExceptionDoingBenignAction);

            Assert.IsTrue(result.IsFailure);
            Assert.AreEqual(ResultError.UnhandledExceptionDoingBenignAction,result.Error);


            //check result error example
            if (result.Error.Equals(ResultError.UnhandledExceptionDoingBenignAction)) {
                //We called into a standard function that threw an error


            }

        }
        [TestMethod]
        public async Task  ExceptionsAsync() {
            //Map the World of Exceptions to an Enum on Result
            var result = await RGetHtmlAsync()
                 .MapAsync<string,int>(async s => throw new Exception(), e => ResultError.UnhandledExceptionDoingBenignAction);

            Assert.IsTrue(result.IsFailure);
            Assert.AreEqual(ResultError.UnhandledExceptionDoingBenignAction, result.Error);


            //check result error example
            if (result.Error.Equals(ResultError.UnhandledExceptionDoingBenignAction)) {
                //We called into a standard function that threw an error


            }

        }
        //----------------Called--Functions------------------------------------
        private Result<string> RGetHtml() => Result.Ok("<html>innerhtml</html>");
 

        private Result<string> RChopHtml(string html) => Result.Ok("innerhtml");
        private Result<int> RGetLength(string html) => Result.Ok(html.Length);




        private async Task<Result<string>> RGetHtmlAsync() {
            await Task.Delay(50);
            return RGetHtml();
        }

        private async Task<Result<string>> RChopHtmlAsync(string html) {
            await Task.Delay(50);
            return RChopHtml(html);
        }
        private async Task<Result<int>> RGetLengthAsync(string html) {
            await Task.Delay(50);
            return RGetLength(html);
        }







        private string GetHtml() => "<html>innerhtml</html>";
        private string ChopHtml(string html) => "innerhtml";

        private int GetLength(string html) => html.Length;

        private async Task<string> GetHtmlAsync() {
            await Task.Delay(50);

            return GetHtml();
        }
        private async Task<string> ChopHtmlAsync(string html) {
            await Task.Delay(50);
            return ChopHtml(html);
        }
        private async Task<int> GetLengthAsync(string html) {
            await Task.Delay(50);
            return GetLength(html);
        }


    }
}
