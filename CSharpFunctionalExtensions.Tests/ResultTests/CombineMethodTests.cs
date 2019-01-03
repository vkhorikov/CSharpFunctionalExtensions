using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;


namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class CombineMethodTests
    {
        [Fact]
        public void FirstFailureOrSuccess_returns_the_first_failed_result()
        {
            Result result1 = Result.Ok();
            Result result2 = Result.Fail("Failure 1");
            Result result3 = Result.Fail("Failure 2");

            Result result = Result.FirstFailureOrSuccess(result1, result2, result3);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("Failure 1");
        }

        [Fact]
        public void FirstFailureOrSuccess_returns_Ok_if_no_failures()
        {
            Result result1 = Result.Ok();
            Result result2 = Result.Ok();
            Result result3 = Result.Ok();

            Result result = Result.FirstFailureOrSuccess(result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_combines_all_errors_together()
        {
            Result result1 = Result.Ok();
            Result result2 = Result.Fail("Failure 1");
            Result result3 = Result.Fail("Failure 2");

            Result result = Result.Combine(";", result1, result2, result3);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Failure 1;Failure 2");
        }

        [Fact]
        public void Combine_returns_Ok_if_no_failures()
        {
            Result result1 = Result.Ok();
            Result result2 = Result.Ok();
            Result<string> result3 = Result.Ok("Some string");

            Result result = Result.Combine(";", result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_works_with_array_of_Generic_results_success()
        {
            Result<string>[] results = new Result<string>[]{ Result.Ok(""), Result.Ok("") };

            Result result = Result.Combine(";", results);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_works_with_array_of_Generic_results_failure()
        {
            Result<string>[] results = new Result<string>[] { Result.Ok(""), Result.Fail<string>("m") };

            Result result = Result.Combine(";", results);

            result.IsSuccess.Should().BeFalse();
        }
        
        [Fact]
        public void Combine_combines_all_collection_errors_together()
        {
            IEnumerable<Result> results = new Result[]
            {
                Result.Ok(),
                Result.Fail("Failure 1"),
                Result.Fail("Failure 2")
            };

            Result result = results.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Failure 1;Failure 2");
        }

        [Fact]
        public void Combine_returns_Ok_if_no_failures_in_collection()
        {
            IEnumerable<Result> results = new Result[]
            {
                Result.Ok(),
                Result.Ok(),
                Result.Ok("Some string")
            };

            Result result = results.Combine(";");

            result.IsSuccess.Should().BeTrue();
        }
        
        [Fact]
        public void Combine_combines_all_Generic_results_collection_errors_together()
        {
            IEnumerable<Result<string>> results = new Result<string>[]
            {
                Result.Ok<string>("str 1"),
                Result.Fail<string>("Failure 1"),
                Result.Fail<string>("Failure 2")
            };

            Result<IEnumerable<string>> result = results.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Failure 1;Failure 2");
        }

        [Fact]
        public void Combine_returns_Ok_if_no_failures_in_Generic_results_collection()
        {
            IEnumerable<Result<int>> results = new Result<int>[]
            {
                Result.Ok(21),
                Result.Ok(34),
                Result.Ok(55)
            };

            Result<IEnumerable<int>> result = results.Combine(";");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(new[] { 21, 34, 55 });
        }

        [Fact]
        public void Combine_works_with_collection_of_Generic_results_success()
        {
            IEnumerable<Result<string>> results = new Result<string>[]
            {
                Result.Ok("one"),
                Result.Ok("two"),
                Result.Ok("three")
            };

            Result<IEnumerable<string>> result = results.Combine(";");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo("one", "two", "three");
        }

        [Fact]
        public void Combine_works_with_collection_of_Generic_results_failure()
        {
            IEnumerable<Result<string>> results = new Result<string>[]
            {
                Result.Ok(""),
                Result.Fail<string>("m"),
                Result.Fail<string>("o")
            };

            Result result = results.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("m;o");
        }

        [Fact]
        public async Task Combine_works_with_collection_of_Tasks_results_success()
        {
            IEnumerable<Task<Result>> tasks = new Task<Result>[]
            {
                Task.FromResult(Result.Ok()),
                Task.FromResult(Result.Ok()),
                Task.FromResult((Result)Result.Ok("some text")),
            };

            Result result = await tasks.Combine(";");

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Combine_works_with_collection_of_Tasks_combines_all_collection_errors_together()
        {
            IEnumerable<Task<Result>> tasks = new Task<Result>[]
            {
                Task.FromResult(Result.Ok()),
                Task.FromResult(Result.Fail("e")),
                Task.FromResult(Result.Fail("r")),
                Task.FromResult(Result.Fail("r"))
            };

            Result result = await tasks.Combine(";");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("e;r;r");
        }
        
        [Fact]
        public async Task Combine_combines_all_tasks_of_Generic_results_collection_errors_together()
        {
            IEnumerable<Task<Result<string>>> tasks = new Task<Result<string>>[]
            {
                Task.FromResult(Result.Ok<string>("str 1")),
                Task.FromResult(Result.Fail<string>("Error 1")),
                Task.FromResult(Result.Fail<string>("Error 2"))
            };

            Result<IEnumerable<string>> result = await tasks.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Error 1;Error 2");
        }
        
        [Fact]
        public async Task Combine_returns_Ok_if_no_failures_in_Generic_results_collection_of_tasks()
        {
            IEnumerable<Task<Result<int>>> tasks = new Task<Result<int>>[]
            {
                Task.FromResult(Result.Ok(8)),
                Task.FromResult(Result.Ok(16)),
                Task.FromResult(Result.Ok(32))
            };

            Result<IEnumerable<int>> result = await tasks.Combine(";");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(new[] { 8, 16, 32 });
        }
        
        [Fact]
        public async Task Combine_works_with_task_with_collection_of_results_success()
        {
            IEnumerable<Result> results = new Result[]
            {
                Result.Ok(),
                Result.Ok(),
                Result.Ok("some-text")
            };
            var task = Task.FromResult(results);

            Result result = await task.Combine(";");

            result.IsSuccess.Should().BeTrue();
        }
        
        [Fact]
        public async Task Combine_works_with_task_with_collection_of_results_failure()
        {
            IEnumerable<Result> results = new Result[]
            {
                Result.Ok(),
                Result.Fail<string>("b"),
                Result.Fail<string>("y")
            };
            var task = Task.FromResult(results);

            Result result = await task.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("b;y");
        }
        
        [Fact]
        public async Task Combine_works_with_task_with_collection_of_Generic_results_success()
        {
            IEnumerable<Result<string>> results = new Result<string>[]
            {
                Result.Ok("1"),
                Result.Ok("3"),
                Result.Ok("7")
            };
            var task = Task.FromResult(results);

            Result<IEnumerable<string>> result = await task.Combine(";");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo("1", "3", "7");
        }
        
        [Fact]
        public async Task Combine_works_with_task_of_collection_of_Generic_results_failure()
        {
            IEnumerable<Result<int>> results = new Result<int>[]
            {
                Result.Ok<int>(7),
                Result.Fail<int>("b"),
                Result.Fail<int>("2")
            };
            var task = Task.FromResult(results);

            Result<IEnumerable<int>> result = await task.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("b;2");
        }
        
        [Fact]
        public async Task Combine_works_with_task_with_collection_of_tasks_of_results_success()
        {
            IEnumerable<Task<Result>> tasks = new Task<Result>[]
            {
                Task.FromResult(Result.Ok()),
                Task.FromResult(Result.Ok()),
                Task.FromResult((Result)Result.Ok("some-text"))
            };
            Task<IEnumerable<Task<Result>>> task = Task.FromResult(tasks);

            Result result = await task.Combine(";");

            result.IsSuccess.Should().BeTrue();
        }
        
        [Fact]
        public async Task Combine_works_with_task_with_collection_of_tasks_of_results_failure()
        {
            IEnumerable<Task<Result>> tasks = new Task<Result>[]
            {
                Task.FromResult(Result.Ok()),
                Task.FromResult(Result.Fail("x")),
                Task.FromResult(Result.Fail("y")),
                Task.FromResult(Result.Fail("z"))
            };
            Task<IEnumerable<Task<Result>>> task = Task.FromResult(tasks);

            Result result = await task.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("x;y;z");
        }
        
        [Fact]
        public async Task Combine_works_with_task_with_collection_of_tasks_of_Generic_results_success()
        {
            IEnumerable<Task<Result<int>>> tasks = new Task<Result<int>>[]
            {
                Task.FromResult(Result.Ok(7)),
                Task.FromResult(Result.Ok(77)),
                Task.FromResult(Result.Ok(777))
            };
            Task<IEnumerable<Task<Result<int>>>> task = Task.FromResult(tasks);

            Result<IEnumerable<int>> result = await task.Combine(";");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(7, 77, 777);
        }
        
        [Fact]
        public async Task Combine_works_with_task_with_collection_of_tasks_of_Generic_results_failure()
        {
            IEnumerable<Task<Result<int>>> tasks = new Task<Result<int>>[]
            {
                Task.FromResult(Result.Ok(13)),
                Task.FromResult(Result.Fail<int>("error")),
                Task.FromResult(Result.Fail<int>("fail"))
            };
            Task<IEnumerable<Task<Result<int>>>> task = Task.FromResult(tasks);

            Result<IEnumerable<int>> result = await task.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("error;fail");
        }

        [Fact]
        public void Combine_works_with_collection_of_results_and_compose_to_new_result_success()
        {
            IEnumerable<Result<int>> results = new Result<int>[]
            {
                Result.Ok(10),
                Result.Ok(20),
                Result.Ok(30),
            };

            Result<double> result = results.Combine(values => (double)values.Max() / 100, ";");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(.3);
        }

        [Fact]
        public void Combine_works_with_collection_of_results_and_compose_to_new_result_failure()
        {
            IEnumerable<Result<string>> results = new Result<string>[]
            {
                Result.Ok("one"),
                Result.Ok("five"),
                Result.Ok("three"),
                Result.Fail<string>("error 1"),
                Result.Fail<string>("error 2")
            };

            Result<string> result = results.Combine(values => values.OrderBy(e => e.Length).First(), ";");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("error 1;error 2");
        }
        
        [Fact]
        public async Task Combine_works_with_collection_of_tasks_of_results_and_compose_to_new_result_success()
        {
            IEnumerable<Task<Result<int>>> tasks = new Task<Result<int>>[]
            {
                Task.FromResult(Result.Ok(90)),
                Task.FromResult(Result.Ok(95)),
                Task.FromResult(Result.Ok(99)),
            };

            Result<double> result = await tasks.Combine(values => (double)values.Min() / 1000, ";");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(.09);
        }

        [Fact]
        public async Task Combine_works_with_collection_of_tasks_of_results_and_compose_to_new_result_failure()
        {
            IEnumerable<Task<Result<string>>> tasks = new Task<Result<string>>[]
            {
                Task.FromResult(Result.Ok("ho")),
                Task.FromResult(Result.Ok("Hi")),
                Task.FromResult(Result.Ok("No")),
                Task.FromResult(Result.Fail<string>("exc 1")),
                Task.FromResult(Result.Fail<string>("exc 2"))
            };

            Result<string> result = await tasks.Combine(values => values.Min(), ";");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("exc 1;exc 2");
        }
        
        [Fact]
        public async Task Combine_works_with_task_of_collection_of_tasks_of_results_and_compose_to_new_result_success()
        {
            IEnumerable<Task<Result<int>>> tasks = new Task<Result<int>>[]
            {
                Task.FromResult(Result.Ok(90)),
                Task.FromResult(Result.Ok(95)),
                Task.FromResult(Result.Ok(99)),
            };
            Task<IEnumerable<Task<Result<int>>>> task = Task.FromResult(tasks);

            Result<double> result = await task.Combine(values => (double)values.Max() / 100, ";");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(.99);
        }

        [Fact]
        public async Task Combine_works_with_task_of_collection_of_tasks_of_results_and_compose_to_new_result_failure()
        {
            IEnumerable<Task<Result<string>>> tasks = new Task<Result<string>>[]
            {
                Task.FromResult(Result.Ok("ho")),
                Task.FromResult(Result.Ok("Hi")),
                Task.FromResult(Result.Ok("No")),
                Task.FromResult(Result.Fail<string>("e 1")),
                Task.FromResult(Result.Fail<string>("e 2"))
            };
            Task<IEnumerable<Task<Result<string>>>> task = Task.FromResult(tasks);

            Result<string> result = await task.Combine(values => values.Max(), ";");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("e 1;e 2");
        }
    }
}
