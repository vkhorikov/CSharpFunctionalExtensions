using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FluentAssertions;

using Xunit;

using static CSharpFunctionalExtensions.Tests.ResultTests.CombineWithErrorMethodTests;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class CombineSequentialMethodTests
    {
        [Fact]
        public async Task CombineSequential_execute_all_functions_when_all_are_success()
        {
            var firstReturnValue = 12;
            var secondReturnValue = "value";
            Task<Result<int>> FirstFunction() => Task.FromResult(Result.Success(firstReturnValue));

            Task<Result<string>> SecondFunction() => Task.FromResult(Result.Success(secondReturnValue));

            var result = await Result.CombineSequential(FirstFunction,
                                                       SecondFunction,
                                                       values => new
                                                       {
                                                           values.DataA,
                                                           values.DataB
                                                       });

            result.IsSuccess.Should().BeTrue();
            result.Value.DataA.Should().Be(firstReturnValue);
            result.Value.DataB.Should().Be(secondReturnValue);
        }
        [Fact]
        public async Task CombineSequential_execute_first_functions_when_it_fails()
        {
            var errorValue = "First function error";
            Task<Result<int>> FirstFunction() => Task.FromResult(Result.Failure<int>(errorValue));

            Task<Result<string>> SecondFunction() => Task.FromResult(Result.Success("value"));

            var result = await Result.CombineSequential(FirstFunction,
                                                        SecondFunction,
                                                        values => new
                                                                  {
                                                                      values.DataA,
                                                                      values.DataB
                                                                  });
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(errorValue);
        }
        [Fact]
        public async Task CombineSequential_execute_all_functions_when_second_fails()
        {
            var errorValue = "Second function error";

            Task<Result<string>> FirstFunction() => Task.FromResult(Result.Success("value"));


            Task<Result<int>> SecondFunction() => Task.FromResult(Result.Failure<int>(errorValue));


            var result = await Result.CombineSequential(FirstFunction,
                                                        SecondFunction,
                                                        values => new
                                                                  {
                                                                      values.DataA,
                                                                      values.DataB
                                                                  });
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(errorValue);
        }
    }
}