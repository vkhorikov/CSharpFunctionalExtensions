using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Examples.LinqQuery
{
    /// <summary>
    /// Demonstrates using LINQ query syntax (sugar) as an alternative to
    /// fluent method chaining to compose operations in a monadic style,
    /// analogous to F# computation expressions or Haskell's do-notation.
    /// </summary>
    public class ResultQueryExamples
    {
        public async Task Demo()
        {
            // Using the LINQ query syntax:
            var validCustomer =
                from name in CustomerName.Create("jsmith")
                from email in Email.Create("jsmith@example.com")
                select new Customer(name, email);

            // Equivalent to:

            var validCustomer_ = CustomerName
                .Create("jsmith")
                .Bind(name =>
                    Email.Create("jsmith@example.com").Map(email => new Customer(name, email))
                );

            // Success(Customer(Name: jsmith, Email: jsmith@example.com))
            Console.WriteLine(validCustomer);

            var invalidCustomer =
                from name in CustomerName.Create("jsmith")
                from email in Email.Create("no email")
                select new Customer(name, email);

            // Failure(E-mail is invalid)
            Console.WriteLine(invalidCustomer);

            //------------------------------------------------------------------------------
            // Also works with async methods.

            var billing = await (
                from customer in CustomerRepository.GetByIdAsync(1) // Task<Result<Customer>>
                from billingInfo in PaymentGateway.ChargeCustomerAsync(customer, 1_000) // Task<Result<BillingInfo>>
                select billingInfo
            );

            // Equivalent to:
            var billing_ = await CustomerRepository
                .GetByIdAsync(1)
                .Bind(customer => PaymentGateway.ChargeCustomerAsync(customer, 1_000));

            // Success(BillingInfo(Customer: jsmith@example.com, ChargeAmount: 1000))
            Console.WriteLine(billing);

            var failedBilling = await (
                from customer in CustomerRepository.GetByIdAsync(1)
                from billingInfo in PaymentGateway.ChargeCustomerAsync(customer, 5_000_000)
                select billingInfo
            );

            // Failure(Insufficient balance.)
            Console.WriteLine(failedBilling);
        }
    }

    public class Email
    {
        private readonly string _value;

        private Email(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }

        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return Result.Failure<Email>("E-mail can't be empty");

            if (email.Length > 100)
                return Result.Failure<Email>("E-mail is too long");

            if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                return Result.Failure<Email>("E-mail is invalid");

            return Result.Success(new Email(email));
        }
    }

    public class CustomerName
    {
        private readonly string _value;

        private CustomerName(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }

        public static Result<CustomerName> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<CustomerName>("Name can't be empty");

            if (name.Length > 50)
                return Result.Failure<CustomerName>("Name is too long");

            return Result.Success(new CustomerName(name));
        }
    }

    public class Customer
    {
        public CustomerName Name { get; private set; }
        public Email Email { get; private set; }

        public Customer(CustomerName name, Email email)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (email == null)
                throw new ArgumentNullException("email");

            Name = name;
            Email = email;
        }

        public override string ToString()
        {
            return $"{nameof(Customer)}({nameof(Name)}: {Name}, {nameof(Email)}: {Email})";
        }
    }

    public class CustomerRepository
    {
        public static async Task<Result<Customer>> GetByIdAsync(int id)
        {
            var customer =
                from email in Email.Create("jsmith@example.com")
                from name in CustomerName.Create("jsmith")
                select new Customer(name, email);

            return customer;
        }
    }

    public class BillingInfo
    {
        public Customer Customer { get; set; }
        public decimal ChargeAmount { get; set; }

        public override string ToString()
        {
            return $"{nameof(BillingInfo)}({nameof(Customer)}: {Customer.Email}, {nameof(ChargeAmount)}: {ChargeAmount})";
        }
    }

    public class PaymentGateway
    {
        public static async Task<Result<BillingInfo>> ChargeCustomerAsync(
            Customer customer,
            decimal chargeAmount
        )
        {
            if (chargeAmount > 1_000_000)
                return Result.Failure<BillingInfo>("Insufficient balance");

            return Result.Success(
                new BillingInfo { Customer = customer, ChargeAmount = chargeAmount }
            );
        }
    }
}
