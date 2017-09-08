using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Examples.ResultExtensions
{
    public class AsyncUsageExamples
    {
        public async Task<string> Promote_with_async_methods_in_the_beginning_of_the_chain(long id)
        {
            var gateway = new EmailGateway();

            return await GetByIdAsync(id)
                .ToResult("Customer with such Id is not found: " + id)
                .Ensure(customer => customer.CanBePromoted(), "The customer has the highest status possible")
                .OnSuccess(customer => customer.Promote())
                .OnSuccess(customer => gateway.SendPromotionNotification(customer.Email))
                .OnBoth(result => result.IsSuccess ? "Ok" : result.Error);
        }

        public async Task<string> Promote_with_async_methods_in_the_beginning_and_in_the_middle_of_the_chain(long id)
        {
            var gateway = new EmailGateway();

            return await GetByIdAsync(id)
                .ToResult("Customer with such Id is not found: " + id)
                .Ensure(customer => customer.CanBePromoted(), "The customer has the highest status possible")
                .OnSuccess(customer => customer.PromoteAsync())
                .OnSuccess(customer => gateway.SendPromotionNotificationAsync(customer.Email))
                .OnBoth(result => result.IsSuccess ? "Ok" : result.Error);
        }

        public Task<Maybe<Customer>> GetByIdAsync(long id)
        {
            return Task.FromResult((Maybe<Customer>)new Customer());
        }

        public Maybe<Customer> GetById(long id)
        {
            return new Customer();
        }

        public class Customer
        {
            public string Email { get; }

            public Customer()
            {
            }

            public bool CanBePromoted()
            {
                return true;
            }

            public void Promote()
            {
            }

            public Task PromoteAsync()
            {
                return Task.FromResult(1);
            }
        }

        public class EmailGateway
        {
            public Result SendPromotionNotification(string email)
            {
                return Result.Ok();
            }

            public Task<Result> SendPromotionNotificationAsync(string email)
            {
                return Task.FromResult(Result.Ok());
            }
        }
    }
}
