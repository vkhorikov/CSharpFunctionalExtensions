using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Examples.ResultExtensions
{
    public class TapExamples
    {
        public void ResultExtensions()
        {
            var value = 0;

            Result.Success()
                .Tap(Do)
                .Tap(GetId)
                .Tap(() => value = 1)
                .Tap(() => { });

            Result.Success(new Customer())
                .Tap(Do)
                .Tap(GetId)
                .Tap(() => value = 1)
                .Tap(c => Do())
                .Tap(c => GetId())
                .Tap(c => value = 1)
                .Map(cs => cs.Email);

            Result.Success<Customer, Error>(new Customer())
                .Tap(Do)
                .Tap(GetId)
                .Tap(() => value = 1)
                .Tap(c => Do())
                .Tap(c => GetId())
                .Tap(c => value = 1)
                .Map(cs => cs.Email);
        }

        public async Task AsyncResultExtensionsRightOperand()
        {
            await Result.Success()
                .Tap(DoAsync)
                .Tap(() => { });

            await Result.Success()
                .Tap(GetIdAsync)
                .Tap(() => { });

            await Result.Success(new Customer())
                .Tap(DoAsync)
                .Map(cs => cs.Email);

            await Result.Success(new Customer())
                .Tap(c => DoAsync())
                .Map(cs => cs.Email);

            await Result.Success(new Customer())
                .Tap(GetIdAsync)
                .Map(cs => cs.Email);

            await Result.Success(new Customer())
                .Tap(c => GetIdAsync())
                .Map(cs => cs.Email);

            await Result.Success<Customer, Error>(new Customer())
                .Tap(DoAsync)
                .Map(c => c.Email);

            await Result.Success<Customer, Error>(new Customer())
                .Tap(GetIdAsync)
                .Map(c => c.Email);

            await Result.Success<Customer, Error>(new Customer())
                .Tap(c => DoAsync())
                .Map(c => c.Email);

            await Result.Success<Customer, Error>(new Customer())
                .Tap(c => GetIdAsync())
                .Map(c => c.Email);
        }

        public async Task AsyncResultExtensionsLeftOperand()
        {
            var value = 0;

            await Task.FromResult(Result.Success())
                .Tap(Do)
                .Tap(GetId)
                .Tap(() => value = 1)
                .Tap(() => { });

            await Task.FromResult(Result.Success(new Customer()))
                .Tap(Do)
                .Tap(GetId)
                .Tap(() => value = 1)
                .Tap(c => Do())
                .Tap(c => GetId())
                .Tap(c => value = 1)
                .Map(cs => cs.Email);

            await Task.FromResult(Result.Success<Customer, Error>(new Customer()))
                .Tap(Do)
                .Tap(GetId)
                .Tap(() => value = 1)
                .Tap(c => Do())
                .Tap(c => GetId())
                .Tap(c => value = 1)
                .Map(cs => cs.Email);
        }

        public async Task AsyncResultExtensionsBothOperands()
        {
            await Task.FromResult(Result.Success())
                .Tap(DoAsync)
                .Tap(GetIdAsync)
                .Tap(() => { });

            await Task.FromResult(Result.Success(new Customer()))
                .Tap(DoAsync)
                .Tap(GetIdAsync)
                .Tap(c => DoAsync())
                .Tap(c => GetIdAsync())
                .Map(cs => cs.Email);

            await Task.FromResult(Result.Success<Customer, Error>(new Customer()))
                .Tap(DoAsync)
                .Tap(GetIdAsync)
                .Tap(c => DoAsync())
                .Tap(c => GetIdAsync())
                .Map(cs => cs.Email);
        }

        void Do() { }
        int GetId() => 1;
        Task DoAsync() => Task.FromResult(1);
        Task<int> GetIdAsync() => Task.FromResult(GetId());

        public class Customer
        {
            public string Email { get; }
        }

        private class Error
        {
        }
    }
}