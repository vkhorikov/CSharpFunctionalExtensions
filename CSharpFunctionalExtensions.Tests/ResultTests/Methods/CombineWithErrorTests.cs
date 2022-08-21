using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class CombineWithErrorTests : TestBase
    {
        private Error ComposeErrors(IEnumerable<Error> errors) =>
            new Error(errors.SelectMany(e => e.Errors).ToList());

        [Fact]
        public void Combine_all_UnitResults_errors_together()
        {
            IEnumerable<UnitResult<Error>> results = new UnitResult<Error>[]
            {
                UnitResult.Success<Error>(),
                UnitResult.Failure<Error>(new Error("Failure 1")),
                UnitResult.Failure<Error>(new Error("Failure 2")),
            };
            
            UnitResult<Error> result = Result.Combine(results, ComposeErrors);

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "Failure 1", "Failure 2" });
        }

        [Fact]
        public void Combine_UnitResults_returns_Ok_if_no_failures() {
            IEnumerable<UnitResult<Error>> results = new UnitResult<Error>[]
            {
                UnitResult.Success<Error>(),
                UnitResult.Success<Error>(),
                UnitResult.Success<Error>(),
            };

            UnitResult<Error> result = Result.Combine(results, ComposeErrors);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_array_UnitResults_compose_method_error_together()
        {
            UnitResult<Error> result1 = UnitResult.Success<Error>();
            UnitResult<Error> result2 = UnitResult.Failure<Error>(new Error("Failure 1"));
            UnitResult<Error> result3 = UnitResult.Failure<Error>(new Error("Failure 2"));

            UnitResult<Error> result = Result.Combine(ComposeErrors, result1, result2, result3);

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "Failure 1", "Failure 2" });
        }

        [Fact]
        public void Combine_array_UnitResults_compose_method_returns_Ok_if_no_failures()
        {
            UnitResult<Error> result1 = UnitResult.Success<Error>();
            UnitResult<Error> result2 = UnitResult.Success<Error>();
            UnitResult<Error> result3 = UnitResult.Success<Error>();

            UnitResult<Error> result = Result.Combine(ComposeErrors, result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_array_UnitResults_compose_method_error_generic_results_together()
        {
            Result<int, Error> result1 = Result.Success<int, Error>(7);
            Result<string, Error> result2 = Result.Failure<string, Error>(new Error("Failure 1"));
            Result<double, Error> result3 = Result.Failure<double, Error>(new Error("Failure 2"));

            UnitResult<Error> result = Result.Combine<Error>(ComposeErrors, result1, result2, result3);

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "Failure 1", "Failure 2" });
        }

        [Fact]
        public void Combine_array_UnitResults_compose_method_success_generic_results_together()
        {
            Result<int, Error> result1 = Result.Success<int, Error>(7);
            Result<string, Error> result2 = Result.Success<string, Error>("msg");
            Result<double, Error> result3 = Result.Success<double, Error>(60.54);

            UnitResult<Error> result = Result.Combine<Error>(ComposeErrors, result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_array_UnitResults_error_together()
        {
            UnitResult<Error> result1 = UnitResult.Success<Error>();
            UnitResult<Error> result2 = UnitResult.Failure<Error>(new Error("Failure 1"));
            UnitResult<Error> result3 = UnitResult.Failure<Error>(new Error("Failure 2"));

            UnitResult<Error> result = Result.Combine(result1, result2, result3);

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "Failure 1", "Failure 2" });
        }

        [Fact]
        public void Combine_array_UnitResults_returns_Ok_if_no_failures()
        {
            UnitResult<Error> result1 = UnitResult.Success<Error>();
            UnitResult<Error> result2 = UnitResult.Success<Error>();
            UnitResult<Error> result3 = UnitResult.Success<Error>();

            UnitResult<Error> result = Result.Combine(result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_array_UnitResults_error_generic_results_together()
        {
            Result<int, Error> result1 = Result.Success<int, Error>(7);
            Result<string, Error> result2 = Result.Failure<string, Error>(new Error("Failure 1"));
            Result<double, Error> result3 = Result.Failure<double, Error>(new Error("Failure 2"));

            UnitResult<Error> result = Result.Combine<Error>(result1, result2, result3);

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "Failure 1", "Failure 2" });
        }

        [Fact]
        public void Combine_array_UnitResults_success_generic_results_together()
        {
            Result<int, Error> result1 = Result.Success<int, Error>(7);
            Result<string, Error> result2 = Result.Success<string, Error>("msg");
            Result<double, Error> result3 = Result.Success<double, Error>(60.54);

            UnitResult<Error> result = Result.Combine<Error>(result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_combines_all_errors_together()
        {
            Result<bool, Error> result1 = Result.Success<bool, Error>(true);
            Result<bool, Error> result2 = Result.Failure<bool, Error>(new Error("Failure 1"));
            Result<bool, Error> result3 = Result.Failure<bool, Error>(new Error("Failure 2"));

            Result<bool, Error> result = Result.Combine(result1, result2, result3);

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "Failure 1", "Failure 2" });
        }

        [Fact]
        public void Combine_returns_Ok_if_no_failures()
        {
            Result<bool, Error> result1 = Result.Success<bool, Error>(true);
            Result<bool, Error> result2 = Result.Success<bool, Error>(true);
            Result<bool, Error> result3 = Result.Success<bool, Error>(false);

            Result<bool, Error> result = Result.Combine<bool, Error>(result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_works_with_array_of_Generic_results_success()
        {
            Result<string, Error>[] results = new Result<string, Error>[] { Result.Success<string, Error>(""), Result.Success<string, Error>("") };

            Result<bool, Error> result = Result.Combine(results);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_works_with_array_of_Generic_results_failure()
        {
            Result<string, Error>[] results = new Result<string, Error>[] { Result.Success<string, Error>(""), Result.Failure<string, Error>(new Error("m")) };

            Result<bool, Error> result = Result.Combine(results);

            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void Combine_combines_all_collection_errors_together()
        {
            IEnumerable<Result<bool, Error>> results = new Result<bool, Error>[]
            {
                Result.Success<bool,Error>(true),
                Result.Failure<bool,Error>(new Error("Failure 1")),
                Result.Failure<bool,Error>(new Error("Failure 2"))
            };

            Result<string, Error> result = results.Combine(b => b.ToString());

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "Failure 1", "Failure 2" });
        }

        [Fact]
        public void Combine_returns_Ok_if_no_failures_in_collection()
        {
            IEnumerable<Result<bool, Error>> results = new Result<bool, Error>[]
            {
                Result.Success<bool, Error>(false),
                Result.Success<bool, Error>(true),
                Result.Success<bool, Error>(false)
            };

            Result<IEnumerable<bool>, Error> result = results.Combine();

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_combines_all_Generic_results_collection_errors_together()
        {
            IEnumerable<Result<string, Error>> results = new Result<string, Error>[]
            {
                Result.Success<string,Error>("str 1"),
                Result.Failure<string,Error>(new Error("Failure 1")),
                Result.Failure<string,Error>(new Error("Failure 2"))
            };

            Result<IEnumerable<string>, Error> result = results.Combine();

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "Failure 1", "Failure 2" });
        }

        [Fact]
        public void Combine_returns_Ok_if_no_failures_in_Generic_results_collection()
        {
            IEnumerable<Result<int, Error>> results = new Result<int, Error>[]
            {
                Result.Success<int,Error>(21),
                Result.Success<int,Error>(34),
                Result.Success<int,Error>(55)
            };

            Result<IEnumerable<int>, Error> result = results.Combine();

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(new[] { 21, 34, 55 });
        }

        [Fact]
        public void Combine_works_with_collection_of_Generic_results_success()
        {
            IEnumerable<Result<string, Error>> results = new Result<string, Error>[]
            {
                Result.Success<string, Error>("one"),
                Result.Success<string, Error>("two"),
                Result.Success<string, Error>("three")
            };

            Result<IEnumerable<string>, Error> result = results.Combine();

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo("one", "two", "three");
        }

        [Fact]
        public void Combine_works_with_collection_of_Generic_results_failure()
        {
            IEnumerable<Result<string, Error>> results = new Result<string, Error>[]
            {
                Result.Success<string,Error>(""),
                Result.Failure<string,Error>(new Error("m")),
                Result.Failure<string,Error>(new Error("o"))
            };

            Result<IEnumerable<string>, Error> result = results.Combine();

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "m", "o" });
        }

        [Fact]
        public async Task Combine_works_with_collection_of_Tasks_combines_all_collection_errors_together()
        {
            IEnumerable<Task<Result<bool, Error>>> tasks = new Task<Result<bool, Error>>[]
            {
                Task.FromResult(Result.Success<bool, Error>(true)),
                Task.FromResult(Result.Failure<bool, Error>(new Error("e"))),
                Task.FromResult(Result.Failure<bool, Error>(new Error("r"))),
                Task.FromResult(Result.Failure<bool, Error>(new Error("r")))
            };

            Result<IEnumerable<bool>, Error> result = await tasks.Combine();

            result.IsFailure.Should().BeTrue();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "e", "r", "r" });
        }

        [Fact]
        public async Task Combine_combines_all_tasks_of_Generic_results_collection_errors_together()
        {
            IEnumerable<Task<Result<string, Error>>> tasks = new Task<Result<string, Error>>[]
            {
                Task.FromResult(Result.Success<string,Error>("str 1")),
                Task.FromResult(Result.Failure<string,Error>(new Error("Error 1"))),
                Task.FromResult(Result.Failure<string,Error>(new Error("Error 2")))
            };

            Result<IEnumerable<string>, Error> result = await tasks.Combine();

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "Error 1", "Error 2" });
        }

        [Fact]
        public async Task Combine_returns_Ok_if_no_failures_in_Generic_results_collection_of_tasks()
        {
            IEnumerable<Task<Result<int, Error>>> tasks = new Task<Result<int, Error>>[]
            {
                Task.FromResult(Result.Success<int,Error>(8)),
                Task.FromResult(Result.Success<int,Error>(16)),
                Task.FromResult(Result.Success<int,Error>(32))
            };

            Result<IEnumerable<int>, Error> result = await tasks.Combine();

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(new[] { 8, 16, 32 });
        }


        [Fact]
        public async Task Combine_works_with_task_with_collection_of_results_failure()
        {
            IEnumerable<Result<bool, Error>> results = new Result<bool, Error>[]
            {
                Result.Success<bool,Error>(true),
                Result.Failure<bool,Error>(new Error("b")),
                Result.Failure<bool,Error>(new Error("y"))
            };
            var task = Task.FromResult(results);

            Result<IEnumerable<bool>, Error> result = await task.Combine();

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "b", "y" });
        }

        [Fact]
        public async Task Combine_works_with_task_with_collection_of_Generic_results_success()
        {
            IEnumerable<Result<string, Error>> results = new Result<string, Error>[]
            {
                Result.Success<string,Error>("1"),
                Result.Success<string,Error>("3"),
                Result.Success<string,Error>("7")
            };
            var task = Task.FromResult(results);

            Result<IEnumerable<string>, Error> result = await task.Combine();

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo("1", "3", "7");
        }

        [Fact]
        public async Task Combine_works_with_task_of_collection_of_Generic_results_failure()
        {
            IEnumerable<Result<int, Error>> results = new Result<int, Error>[]
            {
                Result.Success<int, Error>(7),
                Result.Failure<int, Error>(new Error("b")),
                Result.Failure<int, Error>(new Error("2"))
            };
            var task = Task.FromResult(results);

            Result<IEnumerable<int>, Error> result = await task.Combine();

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "b", "2" });
        }

        [Fact]
        public async Task Combine_works_with_task_with_collection_of_tasks_of_results_failure()
        {
            IEnumerable<Task<Result<bool, Error>>> tasks = new Task<Result<bool, Error>>[]
            {
                Task.FromResult(Result.Success<bool, Error>(true)),
                Task.FromResult(Result.Failure<bool, Error>(new Error("x"))),
                Task.FromResult(Result.Failure<bool, Error>(new Error("y"))),
                Task.FromResult(Result.Failure<bool, Error>(new Error("z")))
            };
            Task<IEnumerable<Task<Result<bool, Error>>>> task = Task.FromResult(tasks);

            Result<IEnumerable<bool>, Error> result = await task.Combine();

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "x", "y", "z" });
        }

        [Fact]
        public async Task Combine_works_with_task_with_collection_of_tasks_of_Generic_results_success()
        {
            IEnumerable<Task<Result<int, Error>>> tasks = new Task<Result<int, Error>>[]
            {
                Task.FromResult(Result.Success<int, Error>(7)),
                Task.FromResult(Result.Success<int, Error>(77)),
                Task.FromResult(Result.Success<int, Error>(777))
            };
            Task<IEnumerable<Task<Result<int, Error>>>> task = Task.FromResult(tasks);

            Result<IEnumerable<int>, Error> result = await task.Combine();

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(7, 77, 777);
        }

        [Fact]
        public async Task Combine_works_with_task_with_collection_of_tasks_of_Generic_results_failure()
        {
            IEnumerable<Task<Result<int, Error>>> tasks = new Task<Result<int, Error>>[]
            {
                Task.FromResult(Result.Success<int,Error>(13)),
                Task.FromResult(Result.Failure<int,Error>(new Error("error"))),
                Task.FromResult(Result.Failure<int,Error>(new Error("fail")))
            };
            Task<IEnumerable<Task<Result<int, Error>>>> task = Task.FromResult(tasks);

            Result<IEnumerable<int>, Error> result = await task.Combine();

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "error", "fail" });
        }

        [Fact]
        public void Combine_works_with_collection_of_results_and_compose_to_new_result_success()
        {
            IEnumerable<Result<int, Error>> results = new Result<int, Error>[]
            {
                Result.Success<int,Error>(10),
                Result.Success<int,Error>(20),
                Result.Success<int,Error>(30),
            };

            Result<double, Error> result = results.Combine(values => (double)values.Max() / 100);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(.3);
        }

        [Fact]
        public void Combine_works_with_collection_of_results_and_compose_to_new_result_failure()
        {
            IEnumerable<Result<string, Error>> results = new Result<string, Error>[]
            {
                Result.Success<string,Error>("one"),
                Result.Success<string,Error>("five"),
                Result.Success<string,Error>("three"),
                Result.Failure<string,Error>(new Error("error 1")),
                Result.Failure<string,Error>(new Error("error 2"))
            };

            Result<string, Error> result = results.Combine(values => values.OrderBy(e => e.Length).First());

            result.IsFailure.Should().BeTrue();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "error 1", "error 2" });
        }

        [Fact]
        public async Task Combine_works_with_collection_of_tasks_of_results_and_compose_to_new_result_success()
        {
            IEnumerable<Task<Result<int, Error>>> tasks = new Task<Result<int, Error>>[]
            {
                Task.FromResult(Result.Success<int, Error>(90)),
                Task.FromResult(Result.Success<int, Error>(95)),
                Task.FromResult(Result.Success<int, Error>(99)),
            };

            Result<double, Error> result = await tasks.Combine(values => (double)values.Min() / 1000);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(.09);
        }

        [Fact]
        public async Task Combine_works_with_collection_of_tasks_of_results_and_compose_to_new_result_failure()
        {
            IEnumerable<Task<Result<string, Error>>> tasks = new Task<Result<string, Error>>[]
            {
                Task.FromResult(Result.Success<string,Error>("ho")),
                Task.FromResult(Result.Success<string,Error>("Hi")),
                Task.FromResult(Result.Success<string,Error>("No")),
                Task.FromResult(Result.Failure<string,Error>(new Error("exc 1"))),
                Task.FromResult(Result.Failure<string,Error>(new Error("exc 2")))
            };

            Result<string, Error> result = await tasks.Combine<string, string, Error>(values => values.Min());

            result.IsFailure.Should().BeTrue();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "exc 1", "exc 2" });
        }

        [Fact]
        public async Task Combine_works_with_task_of_collection_of_tasks_of_results_and_compose_to_new_result_success()
        {
            IEnumerable<Task<Result<int, Error>>> tasks = new Task<Result<int, Error>>[]
            {
                Task.FromResult(Result.Success<int, Error>(90)),
                Task.FromResult(Result.Success<int, Error>(95)),
                Task.FromResult(Result.Success<int, Error>(99)),
            };
            Task<IEnumerable<Task<Result<int, Error>>>> task = Task.FromResult(tasks);

            Result<double, Error> result = await task.Combine(values => (double)values.Max() / 100);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(.99);
        }

        [Fact]
        public async Task Combine_works_with_task_of_collection_of_tasks_of_results_and_compose_to_new_result_failure()
        {
            IEnumerable<Task<Result<string, Error>>> tasks = new Task<Result<string, Error>>[]
            {
                Task.FromResult(Result.Success<string,Error>("ho")),
                Task.FromResult(Result.Success<string,Error>("Hi")),
                Task.FromResult(Result.Success<string,Error>("No")),
                Task.FromResult(Result.Failure<string,Error>(new Error("e 1"))),
                Task.FromResult(Result.Failure<string,Error>(new Error("e 2")))
            };
            Task<IEnumerable<Task<Result<string, Error>>>> task = Task.FromResult(tasks);

            Result<string, Error> result = await task.Combine(composer: values => values.Max());

            result.IsFailure.Should().BeTrue();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "e 1", "e 2" });
        }
    }
}
