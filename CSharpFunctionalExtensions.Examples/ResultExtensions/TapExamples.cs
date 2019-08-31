using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Examples.ResultExtensions
{
    public class TapExamples
    {
        public void ResultExtensions()
        {
            var value = 0;

            Result.Ok()
                .Tap(Do)
                .Tap(GetId)
                .Tap(() => value = 1)
                .Tap(() => { });

            Result.Ok(new Customer())
                .Tap(Do)
                .Tap(GetId)
                .Tap(() => value = 1)
                .Tap(c => Do())
                .Tap(c => GetId())
                .Tap(c => value = 1)
                .Map(cs => cs.Email);

            Result.Ok<Customer, Error>(new Customer())
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
            await Result.Ok()
                .Tap(DoAsync)
                .Tap(() => { });

            await Result.Ok()
                .Tap(GetIdAsync)
                .Tap(() => { });

            await Result.Ok(new Customer())
                .Tap(DoAsync)
                .Map(cs => cs.Email);

            await Result.Ok(new Customer())
                .Tap(c => DoAsync())
                .Map(cs => cs.Email);

            await Result.Ok(new Customer())
                .Tap(GetIdAsync)
                .Map(cs => cs.Email);

            await Result.Ok(new Customer())
                .Tap(c => GetIdAsync())
                .Map(cs => cs.Email);

            await Result.Ok<Customer, Error>(new Customer())
                .Tap(DoAsync)
                .Map(c => c.Email);

            await Result.Ok<Customer, Error>(new Customer())
                .Tap(GetIdAsync)
                .Map(c => c.Email);

            await Result.Ok<Customer, Error>(new Customer())
                .Tap(c => DoAsync())
                .Map(c => c.Email);

            await Result.Ok<Customer, Error>(new Customer())
                .Tap(c => GetIdAsync())
                .Map(c => c.Email);
        }

        public async Task AsyncResultExtensionsLeftOperand()
        {
            var value = 0;

            await Task.FromResult(Result.Ok())
                .Tap(Do)
                .Tap(GetId)
                .Tap(() => value = 1)
                .Tap(() => { });

            await Task.FromResult(Result.Ok(new Customer()))
                .Tap(Do)
                .Tap(GetId)
                .Tap(() => value = 1)
                .Tap(c => Do())
                .Tap(c => GetId())
                .Tap(c => value = 1)
                .Map(cs => cs.Email);

            await Task.FromResult(Result.Ok<Customer, Error>(new Customer()))
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
            await Task.FromResult(Result.Ok())
                .Tap(DoAsync)
                .Tap(GetIdAsync)
                .Tap(() => { });

            await Task.FromResult(Result.Ok(new Customer()))
                .Tap(DoAsync)
                .Tap(GetIdAsync)
                .Tap(c => DoAsync())
                .Tap(c => GetIdAsync())
                .Map(cs => cs.Email);

            await Task.FromResult(Result.Ok<Customer, Error>(new Customer()))
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