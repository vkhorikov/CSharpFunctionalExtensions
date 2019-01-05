Functional Extensions for C#
======================================================
[![Nuget downloads](https://img.shields.io/nuget/v/csharpfunctionalextensions.svg)](https://www.nuget.org/packages/CSharpFunctionalExtensions/)
[![GitHub license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/vkhorikov/CSharpFunctionalExtensions/blob/master/LICENSE)

This library helps write code in more functional way. To get to know more about the principles behind it, check out the [Applying Functional Principles in C# Pluralsight course](http://pluralsight.com/courses/csharp-applying-functional-principles).

## Installation

Available on [nuget](https://www.nuget.org/packages/CSharpFunctionalExtensions/)

	PM> Install-Package CSharpFunctionalExtensions

## .NET 4.0 version Installation

.NET 4.0 version is available as a separate package on [nuget](https://www.nuget.org/packages/CSharpFunctionalExtensionsNet4.0/)

	PM> Install-Package CSharpFunctionalExtensionsNet4.0

## Get rid of primitive obsession

```csharp
Result<CustomerName> name = CustomerName.Create(model.Name);
Result<Email> email = Email.Create(model.PrimaryEmail);

Result result = Result.Combine(name, email);
if (result.IsFailure)
    return Error(result.Error);

var customer = new Customer(name.Value, email.Value);
```

## Make nulls explicit with the Maybe type

```csharp
Maybe<Customer> customerOrNothing = _customerRepository.GetById(id);
if (customerOrNothing.HasNoValue)
    return Error("Customer with such Id is not found: " + id);
```

## Compose multiple operations in a single chain

```csharp
return _customerRepository.GetById(id)
    .ToResult("Customer with such Id is not found: " + id)
    .Ensure(customer => customer.CanBePromoted(), "The customer has the highest status possible")
    .OnSuccess(customer => customer.Promote())
    .OnSuccess(customer => _emailGateway.SendPromotionNotification(customer.PrimaryEmail, customer.Status))
    .OnBoth(result => result.IsSuccess ? Ok() : Error(result.Error));
```

## Wrap multiple operations in a TransactionScope

```csharp
return _customerRepository.GetById(id)
    .ToResult("Customer with such Id is not found: " + id)
    .Ensure(customer => customer.CanBePromoted(), "The customer has the highest status possible")
    .OnSuccessWithTransactionScope(customer => Result.Ok(customer)
        .OnSuccess(customer => customer.Promote())
        .OnSuccess(customer => customer.ClearAppointments()))
    .OnSuccess(customer => _emailGateway.SendPromotionNotification(customer.PrimaryEmail, customer.Status))
    .OnBoth(result => result.IsSuccess ? Ok() : Error(result.Error));
```

## Readings and watchings

 * [Functional C#: Primitive obsession](http://enterprisecraftsmanship.com/2015/03/07/functional-c-primitive-obsession/)
 * [Functional C#: Non-nullable reference types](http://enterprisecraftsmanship.com/2015/03/13/functional-c-non-nullable-reference-types/)
 * [Functional C#: Handling failures, input errors](http://enterprisecraftsmanship.com/2015/03/20/functional-c-handling-failures-input-errors/)
 * [Applying Functional Principles in C# Pluralsight course](http://pluralsight.com/courses/csharp-applying-functional-principles)
  
## Contributors
A big thanks to the project contributors!
 * [Anton Hryshchanka](https://github.com/ahryshchanka)
 * [Mikhail Bashurov](https://github.com/saitonakamura)
 * [kostekk88](https://github.com/kostekk88)
 * [Carl Abrahams](https://github.com/CarlHA)
 * [golavr](https://github.com/golavr)
 * [Sviataslau Hankovich](https://github.com/hankovich)
 * [Chad Gilbert](https://github.com/freakingawesome)
 * [Robert Sęk](https://github.com/robosek)
 * [Sergey Solomentsev](https://github.com/SergAtGitHub)
 * [Malcolm J Harwood](https://github.com/mjharwood)
 * [Dragan Stepanovic](https://github.com/dragan-stepanovic)
 * [Ivan Novikov](https://github.com/jonny-novikov)
 * [Denis Molokanov](https://github.com/dmolokanov)
 * [Gerald Wiltse](https://github.com/solvingJ)
 * [yakimovim](https://github.com/yakimovim)
 * [Alex Erygin](https://github.com/alex-erygin)
 * [Omar Aloraini](https://github.com/omaraloraini)
