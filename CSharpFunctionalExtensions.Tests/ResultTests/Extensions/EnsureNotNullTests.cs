#nullable enable

using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class EnsureNotNullTests : EnsureNotNullTests_Base
    {
        [Fact]
        public void EnsureNotNull_T_with_class_returns_failed_return_for_failed_result()
        {
            Result<T?> result = Result.Failure<T?>(ErrorMessage);

            Result<T> returned = result.EnsureNotNull(ErrorMessage2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage);
        }

        [Fact]
        public void EnsureNotNull_V_with_struct_returns_failed_return_for_failed_result()
        {
            Result<V?> result = Result.Failure<V?>(ErrorMessage);

            Result<V> returned = result.EnsureNotNull(ErrorMessage2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage);
        }

        [Fact]
        public void EnsureNotNull_T_with_class_returns_original_success_result_if_value_is_not_null()
        {
            Result<T?> result = Result.Success<T?>(T.Value);

            Result<T> returned = result.EnsureNotNull(ErrorMessage2);

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(T.Value);
        }

        [Fact]
        public void EnsureNotNull_V_with_struct_returns_original_success_result_if_value_is_not_null()
        {
            Result<V?> result = Result.Success<V?>(V.Value);

            Result<V> returned = result.EnsureNotNull(ErrorMessage2);

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(V.Value);
        }

        [Fact]
        public void EnsureNotNull_T_with_class_returns_failed_result_for_success_result_if_value_is_null()
        {
            Result<T?> result = Result.Success<T?>(null);

            Result<T> returned = result.EnsureNotNull(ErrorMessage2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage2);
        }

        [Fact]
        public void EnsureNotNull_V_with_struct_returns_failed_result_for_success_result_if_value_is_null()
        {
            Result<V?> result = Result.Success<V?>(null);

            Result<V> returned = result.EnsureNotNull(ErrorMessage2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage2);
        }

        [Fact]
        public void EnsureNotNull_T_factory_with_class_returns_failed_return_for_failed_result()
        {
            Result<T?> result = Result.Failure<T?>(ErrorMessage);

            Result<T> returned = result.EnsureNotNull(GetErrorFactory(ErrorMessage2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public void EnsureNotNull_V_factory_with_struct_returns_failed_return_for_failed_result()
        {
            Result<V?> result = Result.Failure<V?>(ErrorMessage);

            Result<V> returned = result.EnsureNotNull(GetErrorFactory(ErrorMessage2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public void EnsureNotNull_T_factory_with_class_returns_original_success_result_if_value_is_not_null()
        {
            Result<T?> result = Result.Success<T?>(T.Value);

            Result<T> returned = result.EnsureNotNull(GetErrorFactory(ErrorMessage2));

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(T.Value);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public void EnsureNotNull_V_factory_with_struct_returns_original_success_result_if_value_is_not_null()
        {
            Result<V?> result = Result.Success<V?>(V.Value);

            Result<V> returned = result.EnsureNotNull(GetErrorFactory(ErrorMessage2));

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(V.Value);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public void EnsureNotNull_T_factory_with_class_returns_failed_result_for_success_result_if_value_is_null()
        {
            Result<T?> result = Result.Success<T?>(null);

            Result<T> returned = result.EnsureNotNull(GetErrorFactory(ErrorMessage2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage2);
            factoryExecuted.Should().BeTrue();
        }

        [Fact]
        public void EnsureNotNull_V_factory_with_struct_returns_failed_result_for_success_result_if_value_is_null()
        {
            Result<V?> result = Result.Success<V?>(null);

            Result<V> returned = result.EnsureNotNull(GetErrorFactory(ErrorMessage2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage2);
            factoryExecuted.Should().BeTrue();
        }

        [Fact]
        public void EnsureNotNull_T_E_with_class_returns_failed_return_for_failed_result()
        {
            Result<T?, E> result = Result.Failure<T?, E>(E.Value);

            Result<T, E> returned = result.EnsureNotNull(E.Value2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value);
        }

        [Fact]
        public void EnsureNotNull_V_E_with_struct_returns_failed_return_for_failed_result()
        {
            Result<V?, E> result = Result.Failure<V?, E>(E.Value);

            Result<V, E> returned = result.EnsureNotNull(E.Value2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value);
        }

        [Fact]
        public void EnsureNotNull_T_E_with_class_returns_original_success_result_if_value_is_not_null()
        {
            Result<T?, E> result = Result.Success<T?, E>(T.Value);

            Result<T, E> returned = result.EnsureNotNull(E.Value2);

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(T.Value);
        }

        [Fact]
        public void EnsureNotNull_V_E_with_struct_returns_original_success_result_if_value_is_not_null()
        {
            Result<V?, E> result = Result.Success<V?, E>(V.Value);

            Result<V, E> returned = result.EnsureNotNull(E.Value2);

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(V.Value);
        }

        [Fact]
        public void EnsureNotNull_T_E_with_class_returns_failed_result_for_success_result_if_value_is_null()
        {
            Result<T?, E> result = Result.Success<T?, E>(null);

            Result<T, E> returned = result.EnsureNotNull(E.Value2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value2);
        }

        [Fact]
        public void EnsureNotNull_V_E_with_struct_returns_failed_result_for_success_result_if_value_is_null()
        {
            Result<V?, E> result = Result.Success<V?, E>(null);

            Result<V, E> returned = result.EnsureNotNull(E.Value2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value2);
        }

        [Fact]
        public void EnsureNotNull_T_E_factory_with_class_returns_failed_return_for_failed_result()
        {
            Result<T?, E> result = Result.Failure<T?, E>(E.Value);

            Result<T, E> returned = result.EnsureNotNull(GetErrorFactory(E.Value2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public void EnsureNotNull_V_E_factory_with_struct_returns_failed_return_for_failed_result()
        {
            Result<V?, E> result = Result.Failure<V?, E>(E.Value);

            Result<V, E> returned = result.EnsureNotNull(GetErrorFactory(E.Value2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public void EnsureNotNull_T_E_factory_with_class_returns_original_success_result_if_value_is_not_null()
        {
            Result<T?, E> result = Result.Success<T?, E>(T.Value);

            Result<T, E> returned = result.EnsureNotNull(GetErrorFactory(E.Value2));

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(T.Value);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public void EnsureNotNull_V_E_factory_with_struct_returns_original_success_result_if_value_is_not_null()
        {
            Result<V?, E> result = Result.Success<V?, E>(V.Value);

            Result<V, E> returned = result.EnsureNotNull(GetErrorFactory(E.Value2));

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(V.Value);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public void EnsureNotNull_T_E_factory_with_class_returns_failed_result_for_success_result_if_value_is_null()
        {
            Result<T?, E> result = Result.Success<T?, E>(null);

            Result<T, E> returned = result.EnsureNotNull(GetErrorFactory(E.Value2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value2);
            factoryExecuted.Should().BeTrue();
        }

        [Fact]
        public void EnsureNotNull_V_E_factory_with_struct_returns_failed_result_for_success_result_if_value_is_null()
        {
            Result<V?, E> result = Result.Success<V?, E>(null);

            Result<V, E> returned = result.EnsureNotNull(GetErrorFactory(E.Value2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value2);
            factoryExecuted.Should().BeTrue();
        }
    }
}