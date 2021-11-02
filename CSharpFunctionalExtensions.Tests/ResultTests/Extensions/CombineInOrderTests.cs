using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class CombineInOrderTests
    {
        [Fact]
        public async Task CombineInOrder_works_with_collection_of_Tasks_results_success()
        {
            StringBuilder builder = new StringBuilder();
            IEnumerable<Task<Result>> tasks = 
                new [] { "a", "b", "c" }
                .Select( s => TaskOfResult(builder, s));

            Result result = await tasks.CombineInOrder(";");

            result.IsSuccess.Should().BeTrue();
            builder.ToString().Should().Be("abc");
        }

        [Fact]
        public async Task CombineInOrder_works_with_collection_of_Tasks_combines_all_collection_errors_together()
        {
            StringBuilder builder = new StringBuilder();
            IEnumerable<Task<Result>> tasks =
                new[] { ("a", true), ("e", false), ("b", true), ("r", false) }
                .Select(s => TaskOfResult(builder, s.Item1, s.Item2));

            Result result = await tasks.CombineInOrder(";");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("e;r");
        }

        [Fact]
        public async Task CombineInOrder_works_with_collection_of_Tasks_aggregates_all_identical_collection_errors_together_with_count()
        {
            StringBuilder builder = new StringBuilder();
            IEnumerable<Task<Result>> tasks =
                new[] { ("a", true), ("e", false), ("r", false), ("b", true), ("r", false) }
                .Select(s => TaskOfResult(builder, s.Item1, s.Item2));

            Result result = await tasks.CombineInOrder(";");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("e;r (2×)");
        }

        [Fact]
        public async Task CombineInOrder_combines_all_tasks_of_Generic_results_collection_errors_together()
        {
            StringBuilder builder = new StringBuilder();
            IEnumerable<Task<Result<string>>> tasks =
                new[] { ("a", true), ("e", false), ("b", true), ("r", false) }
                .Select(s => TaskOfResultOfT(builder, s.Item1, s.Item2));

            Result<IEnumerable<string>> result = await tasks.CombineInOrder(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("e;r");
        }

        [Fact]
        public async Task CombineInOrder_returns_Ok_if_no_failures_in_Generic_results_collection_of_tasks()
        {
            string[] stringArr = new[] { "a", "b", "c" };
            StringBuilder builder = new StringBuilder();
            IEnumerable<Task<Result<string>>> tasks =
                stringArr
                .Select(s => TaskOfResultOfT(builder, s));

            Result<IEnumerable<string>> result = await tasks.CombineInOrder(";");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(stringArr);
            builder.ToString().Should().Be("abc");
        }

        [Fact]
        public async Task CombineInOrder_works_with_task_with_collection_of_tasks_of_results_success()
        {
            StringBuilder builder = new StringBuilder();
            IEnumerable<Task<Result>> tasks =
                new[] { "a", "b", "c" }
                .Select(s => TaskOfResult(builder, s));
            Task<IEnumerable<Task<Result>>> task = Task.FromResult(tasks);

            Result result = await task.CombineInOrder(";");

            result.IsSuccess.Should().BeTrue();
            builder.ToString().Should().Be("abc");
        }

        [Fact]
        public async Task CombineInOrder_works_with_task_with_collection_of_tasks_of_results_failure()
        {
            StringBuilder builder = new StringBuilder();
            IEnumerable<Task<Result>> tasks =
                new[] { ("a", true), ("e", false), ("b", true), ("r", false) }
                .Select(s => TaskOfResult(builder, s.Item1, s.Item2));
            Task<IEnumerable<Task<Result>>> task = Task.FromResult(tasks);

            Result result = await task.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("e;r");
        }

        [Fact]
        public async Task CombineInOrder_works_with_task_with_collection_of_tasks_of_Generic_results_success()
        {
            string[] stringArr = new[] { "a", "b", "c" };
            StringBuilder builder = new StringBuilder();
            IEnumerable<Task<Result<string>>> tasks =
                stringArr
                .Select(s => TaskOfResultOfT(builder, s));

            Task<IEnumerable<Task<Result<string>>>> task = Task.FromResult(tasks);

            Result<IEnumerable<string>> result = await task.CombineInOrder(";");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(stringArr);
            builder.ToString().Should().Be("abc");
        }

        [Fact]
        public async Task CombineInOrder_works_with_task_with_collection_of_tasks_of_Generic_results_failure()
        {
            StringBuilder builder = new StringBuilder();
            IEnumerable<Task<Result<string>>> tasks =
                new[] { ("a", true), ("e", false), ("b", true), ("r", false) }
                .Select(s => TaskOfResultOfT(builder, s.Item1, s.Item2));

            Task<IEnumerable<Task<Result<string>>>> task = Task.FromResult(tasks);

            Result<IEnumerable<string>> result = await task.CombineInOrder(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("e;r");
        }

        [Fact]
        public async Task CombineInOrder_works_with_task_with_collection_of_tasks_of_Generic_results_failure_with_identical_errors_aggregated_with_count()
        {
            StringBuilder builder = new StringBuilder();
            IEnumerable<Task<Result<string>>> tasks =
                new[] { ("a", true), ("e", false), ("b", true), ("e", false), ("r", false) }
                .Select(s => TaskOfResultOfT(builder, s.Item1, s.Item2));
            Task<IEnumerable<Task<Result<string>>>> task = Task.FromResult(tasks);

            Result<IEnumerable<string>> result = await task.CombineInOrder(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("e (2×);r");
        }

        [Fact]
        public async Task CombineInOrder_works_with_collection_of_tasks_of_results_and_compose_to_new_result_success()
        {
            string[] stringArr = new[] { "a", "b", "c" };
            StringBuilder builder = new StringBuilder();
            IEnumerable<Task<Result<string>>> tasks =
                stringArr
                .Select(s => TaskOfResultOfT(builder, s));

            Result<string> result = await tasks.CombineInOrder(values => string.Join(';', values));

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be("a;b;c");
            builder.ToString().Should().Be("abc");
        }

        [Fact]
        public async Task CombineInOrder_works_with_collection_of_tasks_of_results_and_compose_to_new_result_failure()
        {
            StringBuilder builder = new StringBuilder();
            IEnumerable<Task<Result<string>>> tasks =
                new[] { ("a", true), ("e", false), ("b", true), ("e", false), ("r", false) }
                .Select(s => TaskOfResultOfT(builder, s.Item1, s.Item2));
            Task<IEnumerable<Task<Result<string>>>> task = Task.FromResult(tasks);

            Result<string> result = await tasks.CombineInOrder(values => string.Join(';', values), ";");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("e (2×);r");
        }

        [Fact]
        public async Task Combine_works_with_task_of_collection_of_tasks_of_results_and_compose_to_new_result_success()
        {
            IEnumerable<Task<Result<int>>> tasks = new Task<Result<int>>[]
            {
                Task.FromResult(Result.Success(90)),
                Task.FromResult(Result.Success(95)),
                Task.FromResult(Result.Success(99)),
            };
            Task<IEnumerable<Task<Result<int>>>> task = Task.FromResult(tasks);

            Result<double> result = await task.Combine(values => (double)values.Max() / 100, ";");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(.99);
        }

        [Fact]
        public async Task CombineInOrder_works_with_task_of_collection_of_tasks_of_results_and_compose_to_new_result_failure()
        {
            string[] stringArr = new[] { "a", "b", "c" };
            StringBuilder builder = new StringBuilder();
            IEnumerable<Task<Result<string>>> tasks =
                stringArr
                .Select(s => TaskOfResultOfT(builder, s));

            Task<IEnumerable<Task<Result<string>>>> task = Task.FromResult(tasks);
            Result<string> result = await task.CombineInOrder(values => string.Join(';', values));

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be("a;b;c");
            builder.ToString().Should().Be("abc");
        }

        private async Task<Result> TaskOfResult(StringBuilder stringBuilder, string s, bool success = true)
        {
            await Task.Yield();
            if (success)
            {
                stringBuilder.Append(s);
            }
            return success ? Result.Success() : Result.Failure(s);
        }

        private async Task<Result<string>> TaskOfResultOfT(StringBuilder stringBuilder, string s, bool success = true)
        {
            await Task.Yield();
            if (success)
            {
                stringBuilder.Append(s);
            }
            return success ? Result.Success(s) : Result.Failure<string>(s);
        }
    }
}
