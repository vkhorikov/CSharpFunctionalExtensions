Functional Extensions for C#
======================================================
[![Build Status](https://dev.azure.com/EnterpriseCraftsmanship/CSharpFunctionalExtensions/_apis/build/status/CSharpFunctionalExtensions?branchName=master)](https://dev.azure.com/EnterpriseCraftsmanship/CSharpFunctionalExtensions/_build/latest?definitionId=1&branchName=master)
[![Nuget downloads](https://img.shields.io/nuget/v/csharpfunctionalextensions.svg)](https://www.nuget.org/packages/CSharpFunctionalExtensions/)
[![GitHub license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/vkhorikov/CSharpFunctionalExtensions/blob/master/LICENSE)

This library helps write code in more functional way. To get to know more about the principles behind it, check out the [Applying Functional Principles in C# Pluralsight course](https://enterprisecraftsmanship.com/ps-func).

## Installation

Available on [nuget](https://www.nuget.org/packages/CSharpFunctionalExtensions/)

	PM> Install-Package CSharpFunctionalExtensions

## .NET 4.0 version Installation

~~.NET 4.0 version is available as a separate package on [nuget](https://www.nuget.org/packages/CSharpFunctionalExtensionsNet4.0/)~~

No need for a separate 4.0 package anymore! Use the regular CSharpFunctionalExtensions

## Testing

For extension methods on top of this library's `Result` and `Maybe` that you can use in tests, see [this nuget package](https://www.nuget.org/packages/FluentAssertions.CSharpFunctionalExtensions/) (GitHub link: https://github.com/pedromtcosta/FluentAssertions.CSharpFunctionalExtensions).

Example:

```csharp
// Arrange
var myClass = new MyClass();

// Act
Result result = myClass.TheMethod();

// Assert
result.Should().BeSuccess();
```

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
    .Tap(customer => customer.Promote())
    .Tap(customer => _emailGateway.SendPromotionNotification(customer.PrimaryEmail, customer.Status))
    .Finally(result => result.IsSuccess ? Ok() : Error(result.Error));
```

## Wrap multiple operations in a TransactionScope

```csharp
return _customerRepository.GetById(id)
    .ToResult("Customer with such Id is not found: " + id)
    .Ensure(customer => customer.CanBePromoted(), "The customer has the highest status possible")
    .WithTransactionScope(customer => Result.Success(customer)
        .Tap(customer => customer.Promote())
        .Tap(customer => customer.ClearAppointments()))
    .Tap(customer => _emailGateway.SendPromotionNotification(customer.PrimaryEmail, customer.Status))
    .Finally(result => result.IsSuccess ? Ok() : Error(result.Error));
```

## Readings and watchings

 * [Functional C#: Primitive obsession](http://enterprisecraftsmanship.com/2015/03/07/functional-c-primitive-obsession/)
 * [Functional C#: Non-nullable reference types](http://enterprisecraftsmanship.com/2015/03/13/functional-c-non-nullable-reference-types/)
 * [Functional C#: Handling failures, input errors](http://enterprisecraftsmanship.com/2015/03/20/functional-c-handling-failures-input-errors/)
 * [Applying Functional Principles in C# Pluralsight course](https://enterprisecraftsmanship.com/ps-func)
  
## Contributors
A big thanks to the project contributors!
 * [Ali Khalili](https://github.com/AliKhalili)
 * [Andrei Andreev](https://github.com/Razenpok)
 * [YudApps](https://github.com/YudApps)
 * [dataphysix](https://github.com/dataphysix)
 * [Laszlo Lueck](https://github.com/LaszloLueck)
 * [Sean G. Wright](https://github.com/seangwright)
 * [Samuel Viesselman](https://github.com/SamuelViesselman)
 * [Stian Kroknes](https://github.com/stiankroknes)
 * [dataneo](https://github.com/dataneodev)
 * [michaeldileo](https://github.com/michaeldileo)
 * [Renato Ramos Nascimento](https://github.com/renato04)
 * [Patrick Drechsler](https://github.com/draptik)
 * [Vadim Mingazhev](https://github.com/mingazhev)
 * [Darick Carpenter](https://github.com/darickc)
 * [Stéphane Mitermite](https://github.com/kakone)
 * [Markus Nißl](https://github.com/mnissl)
 * [Adrian Frielinghaus](https://github.com/freever)
 * [svroonland](https://github.com/svroonland)
 * [JvSSD](https://github.com/JvSSD)
 * [mnissl](https://github.com/mnissl)
 * [Vladimir Makaev](https://github.com/VladimirMakaev)
 * [Ben Smith](https://github.com/benprime)
 * [pedromtcosta](https://github.com/pedromtcosta)
 * [Michał Bator](https://github.com/MikelThief)
 * [mukmyash](https://github.com/mukmyash)
 * [azm102](https://github.com/azm102)
 * [ThomasDC](https://github.com/thomasdc)
 * [bopazyn](https://github.com/bopazyn)
 * [Joris Goovaerts](https://github.com/CommCody)
 * [Ivan Deev](https://github.com/BillyFromAHill)
 * [Damian Płaza](https://github.com/dpraimeyuu)
 * [ergwun](https://github.com/ergwun)
 * [Michael DiLeo](https://github.com/pilotMike)
 * [Jean-Claude](https://github.com/jcsonder)
 * [Matt Jenkins](https://github.com/space-alien)
 * [Michael Altmann](https://github.com/altmann)
 * [Steven Giesel](https://github.com/linkdotnet)
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
