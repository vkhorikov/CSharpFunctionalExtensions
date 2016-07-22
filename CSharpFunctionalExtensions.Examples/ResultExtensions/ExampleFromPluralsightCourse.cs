namespace CSharpFunctionalExtensions.Examples.ResultExtensions
{
    public class ExampleFromPluralsightCourse
    {
        public string Promote(long id)
        {
            var gateway = new EmailGateway();

            return GetById(id)
                .ToResult("Customer with such Id is not found: " + id)
                .Ensure(customer => customer.CanBePromoted(), "The customer has the highest status possible")
                .OnSuccess(customer => customer.Promote())
                .OnSuccess(customer => gateway.SendPromotionNotification(customer.Email))
                .OnBoth(result => result.IsSuccess ? "Ok" : result.Error);
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
        }

        public class EmailGateway
        {
            public Result SendPromotionNotification(string email)
            {
                return Result.Ok();
            }
        }
    }
}