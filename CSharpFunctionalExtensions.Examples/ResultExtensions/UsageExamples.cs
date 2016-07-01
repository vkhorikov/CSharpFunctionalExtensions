using System;


namespace CSharpFunctionalExtensions.Examples.ResultExtensions
{
    public class Passing_result_through_OnSuccess_methods
    {
        public void Example1()
        {
            Result<DateTime> result = FunctionInt()
                .OnSuccess(x => FunctionString(x))
                .OnSuccess(x => FunctionDateTime(x));
        }

        public void Example2()
        {
            Result<DateTime> result = FunctionInt()
                .OnSuccess(() => FunctionString())
                .OnSuccess(x => FunctionDateTime(x));
        }

        private Result<int> FunctionInt()
        {
            return Result.Ok(1);
        }

        private Result<string> FunctionString(int intValue)
        {
            return Result.Ok("Ok");
        }

        private Result<string> FunctionString()
        {
            return Result.Ok("Ok");
        }

        private Result<DateTime> FunctionDateTime(string stringValue)
        {
            return Result.Ok(DateTime.Now);
        }
    }


    public class Example_from_Pluralsight_course
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
