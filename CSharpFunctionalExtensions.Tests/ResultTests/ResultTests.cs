using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class ResultTests
    {
        [Fact]
        public void Create_argument_is_true_Success_result_expected()
        {
            Result result = Result.Create(true, string.Empty);

            result.IsSuccess.Should().BeTrue();
        }
        
        [Fact]
        public void Create_argument_is_false_Failure_result_expected()
        {
            Result result = Result.Create(false, "simple result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("simple result error");
        }
        
        [Fact]
        public void Create_predicate_is_true_Success_result_expected()
        {
            var predicate = new Mock<Func<bool>>();
            predicate
                .Setup(x => x())
                .Returns(true);
            
            Result result = Result.Create(predicate.Object, string.Empty);

            result.IsSuccess.Should().BeTrue();
            predicate.Verify(x => x(), Times.Once);
        }
        
        [Fact]
        public void Create_predicate_is_false_Failure_result_expected()
        {
            var predicate = new Mock<Func<bool>>();

            predicate
                .Setup(x => x())
                .Returns(false);
            
            Result result = Result.Create(predicate.Object, "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }
        
        [Fact]
        public async Task Create_async_predicate_is_true_Success_result_expected()
        {
            var predicate = new Mock<Func<Task<bool>>>();
            predicate
                .Setup(x => x())
                .ReturnsAsync(true);
            
            Result result = await Result.Create(predicate.Object, string.Empty);

            result.IsSuccess.Should().BeTrue();
            predicate.Verify(x => x(), Times.Once);
        }
        
        [Fact]
        public async Task Create_async_predicate_is_false_Failure_result_expected()
        {
            var predicate = new Mock<Func<Task<bool>>>();

            predicate
                .Setup(x => x())
                .ReturnsAsync(false);
            
            Result result = await Result.Create(predicate.Object, "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }
        
        [Fact]
        public void Create_generic_argument_is_true_Success_result_expected()
        {
            byte val = 7;
            Result<byte> result = Result.Create(true, val, string.Empty);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }
        
        [Fact]
        public void Create_generic_argument_is_false_Failure_result_expected()
        {
            double val = .56;
            Result<double> result = Result.Create(false, val, "simple result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("simple result error");
        }
        
        [Fact]
        public void Create_generic_predicate_is_true_Success_result_expected()
        {
            var predicate = new Mock<Func<bool>>();
            predicate
                .Setup(x => x())
                .Returns(true);
            DateTime val = new DateTime(2000, 1, 1);
            
            Result<DateTime> result = Result.Create(predicate.Object, val, string.Empty);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
            predicate.Verify(x => x(), Times.Once);
        }
        
        [Fact]
        public void Create_generic_predicate_is_false_Failure_result_expected()
        {
            var predicate = new Mock<Func<bool>>();
            predicate
                .Setup(x => x())
                .Returns(false);
            string val = "string value";
            
            Result<string> result = Result.Create(predicate.Object, val, "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }
        
        [Fact]
        public async Task Create_generic_async_predicate_is_true_Success_result_expected()
        {
            var predicate = new Mock<Func<Task<bool>>>();
            predicate
                .Setup(x => x())
                .ReturnsAsync(true);
            int val = 42;
            
            Result<int> result = await Result.Create(predicate.Object, val, string.Empty);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
            predicate.Verify(x => x(), Times.Once);
        }
        
        [Fact]
        public async Task Create_generic_async_predicate_is_false_Failure_result_expected()
        {
            var predicate = new Mock<Func<Task<bool>>>();
            predicate
                .Setup(x => x())
                .ReturnsAsync(false);
            bool val = true;
            
            Result<bool> result = await Result.Create(predicate.Object, val, "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }
        
        
        [Fact]
        public void Create_error_generic_argument_is_true_Success_result_expected()
        {
            byte val = 7;
            Result<byte, Error> result = Result.Create(true, val, new Error());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }
        
        [Fact]
        public void Create_error_generic_argument_is_false_Failure_result_expected()
        {
            double val = .56;
            var error = new Error();
            
            Result<double, Error> result = Result.Create(false, val, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }
        
        [Fact]
        public void Create_error_generic_predicate_is_true_Success_result_expected()
        {
            var predicate = new Mock<Func<bool>>();
            predicate
                .Setup(x => x())
                .Returns(true);
            DateTime val = new DateTime(2000, 1, 1);
            
            Result<DateTime, Error> result = Result.Create(predicate.Object, val, new Error());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
            predicate.Verify(x => x(), Times.Once);
        }
        
        [Fact]
        public void Create_error_generic_predicate_is_false_Failure_result_expected()
        {
            var predicate = new Mock<Func<bool>>();
            predicate
                .Setup(x => x())
                .Returns(false);
            string val = "string value";
            var error = new Error();
            
            Result<string, Error> result = Result.Create(predicate.Object, val, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }
        
        [Fact]
        public async Task Create_error_generic_async_predicate_is_true_Success_result_expected()
        {
            var predicate = new Mock<Func<Task<bool>>>();
            predicate
                .Setup(x => x())
                .ReturnsAsync(true);
            int val = 42;
            
            Result<int, Error> result = await Result.Create(predicate.Object, val, new Error());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
            predicate.Verify(x => x(), Times.Once);
        }
        
        [Fact]
        public async Task Create_error_generic_async_predicate_is_false_Failure_result_expected()
        {
            var predicate = new Mock<Func<Task<bool>>>();
            predicate
                .Setup(x => x())
                .ReturnsAsync(false);
            bool val = true;
            var error = new Error();
            
            Result<bool, Error> result = await Result.Create(predicate.Object, val, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        private class Error
        {
        }
    }
}