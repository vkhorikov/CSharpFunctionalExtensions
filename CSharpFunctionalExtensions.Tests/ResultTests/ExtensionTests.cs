﻿using System;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class ExtensionTests
    {
        private static readonly string _errorMessage = "this failed";

        [Fact]
        public void Should_execute_action_on_failure()
        {
            bool myBool = false;

            Result myResult = Result.Fail(_errorMessage);
            myResult.OnFailure(() => myBool = true);

            myBool.Should().Be(true);
        }

        [Fact]
        public void Should_execute_action_on_generic_failure()
        {
            bool myBool = false;

            Result<MyClass> myResult = Result.Fail<MyClass>(_errorMessage);
            myResult.OnFailure(() => myBool = true);

            myBool.Should().Be(true);
        }

        [Fact]
        public void Should_exexcute_action_with_result_on_generic_failure()
        {
            string myError = string.Empty;

            Result<MyClass> myResult = Result.Fail<MyClass>(_errorMessage);
            myResult.OnFailure(error => myError = error);

            myError.Should().Be(_errorMessage);
        }

        [Fact]
        public void Should_exexcute_action_with_error_object_on_generic_failure()
        {
            string myError = string.Empty;

            Result<MyClass, MyClass> myResult = Result.Fail<MyClass, MyClass>(new MyClass {Property = _errorMessage});
            myResult.OnFailure(error => myError = error.Property);

            myError.Should().Be(_errorMessage);
        }

        [Fact]
        public void Should_execute_compensate_func_on_failure_returns_Ok()
        {
            var myResult = Result.Fail(_errorMessage);
            var newResult = myResult.OnFailureCompensate(() => Result.Ok());

            newResult.IsSuccess.Should().Be(true);
        }

        [Fact]
        public void Should_execute_compensate_func_on_generic_failure_returns_Ok()
        {
            var expectedValue = new MyClass();

            var myResult = Result.Fail<MyClass>(_errorMessage);
            var newResult = myResult.OnFailureCompensate(() => Result.Ok(expectedValue));

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(expectedValue);
        }

        [Fact]
        public void Should_execute_compensate_func_with_result_on_generic_failure_returns_Ok()
        {
            var expectedValue = new MyClass();

            var myResult = Result.Fail<MyClass>(_errorMessage);
            var newResult = myResult.OnFailureCompensate(error => Result.Ok(expectedValue));

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(expectedValue);
        }

        [Fact]
        public void Should_execute_compensate_func_with_error_object_on_generic_failure_returns_Ok()
        {
            var expectedValue = new MyClass();

            var myResult = Result.Fail<MyClass, MyClass>(new MyClass {Property = _errorMessage});
            var newResult = myResult.OnFailureCompensate(error => Result.Ok<MyClass, MyClass>(expectedValue));

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(expectedValue);
        }

        [Fact]
        public void OnSuccessTry_failed_result_execute_action_original_failed_result_expected()
        {
            var originalResult = Result.Fail("error");

            var result = originalResult.OnSuccessTry(() => { });

            result.IsFailure.Should().BeTrue();
            result.Should().Be(originalResult);
        }
        
        [Fact]
        public void OnSuccessTry_success_result_execute_action_success_result_expected()
        {
            var originalResult = Result.Ok();
            bool isExecuted = false;

            var result = originalResult.OnSuccessTry(() =>
            {
                isExecuted = true;
            });

            result.IsSuccess.Should().BeTrue();

            isExecuted.Should().BeTrue();
        }
        
        [Fact]
        public void OnSuccessTry_success_result_execute_action_throw_exception_failed_result_expected()
        {
            var originalResult = Result.Ok();

            var result = originalResult.OnSuccessTry(() => throw new Exception("execute action exception."));

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("execute action exception.");
        }

        [Fact]
        public void OnSuccessTry_failed_result_execute_function_new_failed_result_expected()
        {
            var originalResult = Result.Fail("original result error message");

            Result<int> result = originalResult.OnSuccessTry(() => 3);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("original result error message");
        }
        
        [Fact]
        public void OnSuccessTry_success_result_execute_function_success_result_expected()
        {
            var originalResult = Result.Ok();

            Result<int> result = originalResult.OnSuccessTry(() => 7);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(7);
        }
        
        [Fact]
        public void OnSuccessTry_success_result_execute_function_throw_exception_failed_result_expected()
        {
            var originalResult = Result.Ok();
            Func<DateTime> func = () => throw new Exception("execute action exception.");

            Result<DateTime> result = originalResult.OnSuccessTry(func);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("execute action exception.");
        }
        
        [Fact]
        public void OnSuccessTry_failed_result_execute_function_with_argument_new_failed_result_expected()
        {
            var originalResult = Result.Fail<DateTime>("original result error message");

            Result<int> result = originalResult.OnSuccessTry(date => date.Day);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("original result error message");
        }
        
        [Fact]
        public void OnSuccessTry_success_result_execute_function_with_argument_success_result_expected()
        {
            var originalResult = Result.Ok<byte>(2);

            Result<int> result = originalResult.OnSuccessTry(val => val * val);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(4);
        }
        
        [Fact]
        public void OnSuccessTry_success_result_execute_function_with_argument_throw_exception_failed_result_expected()
        {
            var originalResult = Result.Ok(2);
            Func<int, DateTime> func = val => throw new Exception("execute action exception");

            Result<DateTime> result = originalResult.OnSuccessTry(func);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("execute action exception");
        }
        
        [Fact]
        public void OnSuccessTry_failed_result_execute_action_with_argument_new_failed_result_expected()
        {
            var originalResult = Result.Fail<DateTime>("original result error message");

            Result result = originalResult.OnSuccessTry(date => { });

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("original result error message");
        }
        
        [Fact]
        public void OnSuccessTry_success_result_execute_action_with_argument_success_result_expected()
        {
            var originalResult = Result.Ok<byte>(2);
            bool isExecuted = false;

            Result result = originalResult.OnSuccessTry(val => { isExecuted = true; });

            result.IsSuccess.Should().BeTrue();

            isExecuted.Should().BeTrue();
        }
        
        [Fact]
        public void OnSuccessTry_success_result_execute_action_with_argument_throw_exception_failed_result_expected()
        {
            var originalResult = Result.Ok(2);
            Action<int> action = val => throw new Exception("execute action exception");

            Result result = originalResult.OnSuccessTry(action);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("execute action exception");
        }
        
        private class MyClass
        {
            public string Property { get; set; }
        }
    }
}
