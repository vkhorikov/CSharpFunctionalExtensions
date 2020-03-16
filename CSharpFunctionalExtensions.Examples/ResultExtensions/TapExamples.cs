using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Examples.ResultExtensions
{
    public class TapExamples
    {
        class Customer
        {
            public string Name { get; set; }
        }

        class Error
        {
        }


        // Action
        void RaiseAlert() { }

        // Func<Task>
        Task RaiseAlertAsync() => Task.CompletedTask;

        // Action<T>
        void DeleteCustomer(Customer customer) { }

        // Func<T, Task>
        Task DeleteCustomerAsync(Customer customer) => Task.CompletedTask;

        // Func<TResult>
        int GetTotal() => 11;

        // Func<Task<T>>
        Task<int> GetTotalAsync() => Task.FromResult(11);

        // Func<T, TResult>>
        int AppendLog(string entry) => 332;

        // Func<T, Task<TResult>>
        Task<int> AppendLogAsync(string entry) => Task.FromResult(332);


        // A method that returns a Result
        Result DoWork() => Result.Success();
        Task<Result> DoWorkAsync() => Task.FromResult(Result.Success());

        // A method that returns a Result<T>
        Result<Customer> GetCustomer(int customer) => Result.Success(new Customer());
        Task<Result<Customer>> GetCustomerAsync(int customer) => Task.FromResult(Result.Success(new Customer()));

        // A method that returns a Result<T, E>
        Result<Customer, Error> GetCustomerB(int customer) => Result.Success<Customer, Error>(new Customer());
        Task<Result<Customer, Error>> GetCustomerBAsync(int customer) => Task.FromResult(Result.Success<Customer, Error>(new Customer()));


        public void ResultExtensions()
        {
            var customer = new Customer();

            // Result
            DoWork()
                .Tap(RaiseAlert)
                .Tap(() => DeleteCustomer(customer))
                .Tap(() => GetTotal())                   // The int return value is ignored
                .Tap(() => AppendLog("log"))             // The int return value is ignored
                .Tap(() => customer.Name = "Matt")       // Inline lambda, external variable
                .Tap(() =>
                {                                        // Do whatever you want!
                    DeleteCustomer(customer);
                    GetTotal();
                });

            // Result<T>
            GetCustomer(21)                              // Result.Value contains the customer
                .Tap(RaiseAlert)
                .Tap(c => DeleteCustomer(c))             // Result.Value is passed as the parameter to the lambda
                .Tap(DeleteCustomer)                     // Shorthand version of the above line, using method group conversion.
                .Tap(() => GetTotal())
                // .Tap(GetTotal)                        // Method group conversion ONLY doesn't work for non-async parameterless Funcs.
                .Tap(() => AppendLog("log"))
                .Tap(c => c.Name = "Jenkins")
                .Tap(c =>
                {
                    DeleteCustomer(c);
                    GetTotal();
                });

            // Result<T, E>
            GetCustomerB(21)
                .Tap(RaiseAlert)
                .Tap(c => DeleteCustomer(c))
                .Tap(DeleteCustomer)
                .Tap(() => GetTotal())
                .Tap(() => AppendLog("log"))
                .Tap(c => c.Name = "Jenkins")
                .Tap(c =>
                {
                    DeleteCustomer(c);
                    GetTotal();
                });
        }

        public async Task AsyncResultExtensionsRightOperand()
        {
            var customer = new Customer();

            // Result
            await DoWork()                                   // await the entire chain
                .Tap(RaiseAlert)
                .Tap(() => RaiseAlertAsync())                // The first method to return a Task brings the entire chain into the Task<Result> space
                .Tap(() => DeleteCustomer(customer))         // Non-async methods can still be used interchangeably though
                .Tap(() => DeleteCustomerAsync(customer))
                .Tap(() => GetTotal())
                .Tap(() => GetTotalAsync())
                .Tap(GetTotalAsync)                          // Since this is a Func (GetTotalAsync() returns a Task),
                                                             // method group conversion works fine. The Task inner return value 
                                                             // is discarded, of course, as with all the Tap methods.
                .Tap(() => AppendLog("log"))
                .Tap(() => AppendLogAsync("log"))
                .Tap(() => customer.Name = "Matt")
                .Tap(() =>
                {
                    DeleteCustomer(customer);
                    GetTotal();
                })
                .Tap(async () =>                             // Even inline lambdas can be async!
                {
                    await DeleteCustomerAsync(customer);
                    await GetTotalAsync();
                });

            // Result<T>
            await GetCustomer(21)                            // Result.Value contains the customer
                .Tap(RaiseAlert)
                .Tap(RaiseAlertAsync)
                .Tap(c => DeleteCustomer(c))
                .Tap(DeleteCustomer)
                .Tap(c => DeleteCustomerAsync(c))
                .Tap(DeleteCustomerAsync)
                .Tap(() => GetTotal())
                .Tap(GetTotalAsync)
                .Tap(() => AppendLog("log"))
                .Tap(() => AppendLogAsync("log"))
                .Tap(() => customer.Name = "Jenkins")
                .Tap(c =>
                {
                    DeleteCustomer(c);
                    GetTotal();
                })
                .Tap(async c =>
                {
                    await DeleteCustomerAsync(c);
                    await GetTotalAsync();
                });

            // Result<T, E>
            await GetCustomerB(21)
                .Tap(RaiseAlert)
                .Tap(RaiseAlertAsync)
                .Tap(DeleteCustomer)
                .Tap(DeleteCustomerAsync)
                .Tap(() => GetTotal())
                .Tap(GetTotalAsync)
                .Tap(() => AppendLog("log"))
                .Tap(() => AppendLogAsync("log"))
                .Tap(() => customer.Name = "Jenkins")
                .Tap(c =>
                {
                    DeleteCustomer(c);
                    GetTotal();
                })
                .Tap(async c =>
                {
                    await DeleteCustomerAsync(c);
                    await GetTotalAsync();
                });


            // Result
            await DoWork()
                .Tap(RaiseAlertAsync);

            // Result<T>
            await GetCustomer(21)
                .Tap(RaiseAlertAsync);

            await GetCustomer(21)
                .Tap(DeleteCustomerAsync);

            // Result<T, E>
            await GetCustomerB(21)
                .Tap(RaiseAlertAsync);

            await GetCustomerB(21)
                .Tap(DeleteCustomerAsync);
        }

        public async Task AsyncResultExtensionsLeftOperand()
        {
            // Task<Result>
            await DoWorkAsync()
                .Tap(RaiseAlert);

            // Task<Result<T>>
            await GetCustomerAsync(21)
                .Tap(RaiseAlert);

            await GetCustomerAsync(21)
                .Tap(DeleteCustomer);

            // Task<Result<T, E>>
            await GetCustomerBAsync(21)
                .Tap(RaiseAlert);

            await GetCustomerBAsync(21)
                .Tap(DeleteCustomer);
        }

        public async Task AsyncResultExtensionsBothOperands()
        {
            // Task<Result>
            await DoWorkAsync()
                .Tap(RaiseAlertAsync);

            // Task<Result<T>>
            await GetCustomerAsync(21)
                .Tap(RaiseAlertAsync);

            await GetCustomerAsync(21)
                .Tap(DeleteCustomerAsync);

            // Task<Result<T, E>>
            await GetCustomerBAsync(21)
                .Tap(RaiseAlertAsync);

            await GetCustomerBAsync(21)
                .Tap(DeleteCustomerAsync);
        }
    }
}