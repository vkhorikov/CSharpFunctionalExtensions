using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Examples.ResultExtensions
{
    public class ExampleWithOnFailureMethod
    {
        public string OnFailure_non_async(int customerId, decimal moneyAmount)
        {
            var paymentGateway = new PaymentGateway();
            var database = new Database();

            return GetById(customerId)
                .ToResult("Customer with such Id is not found: " + customerId)
                .OnSuccess(customer => customer.AddBalance(moneyAmount))
                .OnSuccess(customer => paymentGateway.ChargePayment(customer, moneyAmount).Map(() => customer))
                .OnSuccess(
                    customer => database.Save(customer)
                        .OnFailure(() => paymentGateway.RollbackLastTransaction()))
                .OnBoth(result => result.IsSuccess ? "OK" : result.Error);
        }

        public async Task<string> OnFailure_async(int customerId, decimal moneyAmount)
        {
            var paymentGateway = new PaymentGateway();
            var database = new Database();

            return await GetById(customerId)
                .ToResult("Customer with such Id is not found: " + customerId)
                .OnSuccess(customer => customer.AddBalance(moneyAmount))
                .OnSuccess(customer => paymentGateway.ChargePayment(customer, moneyAmount).Map(() => customer))
                .OnSuccess(
                    customer => database.Save(customer)
                        .OnFailure(() => paymentGateway.RollbackLastTransactionAsync()))
                .OnBoth(result => result.IsSuccess ? "OK" : result.Error);
        }

        private Maybe<Customer> GetById(long id)
        {
            return new Customer();
        }

        private class Customer
        {
            public void AddBalance(decimal moneyAmount)
            {
                
            }
        }

        private class PaymentGateway
        {
            public Result ChargePayment(Customer customer, decimal moneyAmount)
            {
                return Result.Ok();
            }

            public void RollbackLastTransaction()
            {
                
            }

            public Task RollbackLastTransactionAsync()
            {
                return Task.FromResult(1);
            }
        }

        private class Database
        {
            public Result Save(Customer customer)
            {
                return Result.Ok();
            }
        }
    }
}
