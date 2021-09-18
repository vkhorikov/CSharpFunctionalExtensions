# Functional Extensions for C&#35;

[![Build Status](https://dev.azure.com/EnterpriseCraftsmanship/CSharpFunctionalExtensions/_apis/build/status/CSharpFunctionalExtensions?branchName=master)](https://dev.azure.com/EnterpriseCraftsmanship/CSharpFunctionalExtensions/_build/latest?definitionId=1&branchName=master)
[![NuGet downloads](https://img.shields.io/nuget/v/csharpfunctionalextensions.svg)](https://www.nuget.org/packages/CSharpFunctionalExtensions/)
[![GitHub license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/vkhorikov/CSharpFunctionalExtensions/blob/master/LICENSE)

This library helps write code in more functional way.
To get to know more about the principles behind it, check out the [Applying Functional Principles in C# Pluralsight course](https://enterprisecraftsmanship.com/ps-func).

## Installation

Available on [NuGet](https://www.nuget.org/packages/CSharpFunctionalExtensions/)

```bash
dotnet add package CSharpFunctionalExtensions
```

or

```powershell
PM> Install-Package CSharpFunctionalExtensions
```

## Core Concepts

### Get rid of primitive obsession

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

## API Examples

### Maybe

#### Explicit Construction

Use case: Creating a new Maybe containing a value

```csharp
Maybe<string> apple = Maybe<string>.From("apple");

// or

Maybe<string> apple = Maybe.From("apple"); // type inference

// or

var apple = Maybe.From("apple");
```

#### No Value

Use case: Replacing `null` or the
[Null Object Pattern](https://www.c-sharpcorner.com/article/null-object-design-pattern/) for representing 'missing' data.

```csharp
int storeInventory = ...

Maybe<string> fruit = storeInventory > 0
    ? Maybe<string>.From("apple")
    : Maybe<string>.None;
```

#### Implicit Conversion

Use case: Easily creating a Maybe from a value

```csharp
Maybe<string> apple = "apple"; // implicit conversion

Maybe<string> GetFruit(string fruit)
{
    if (string.IsNullOrWhiteSpace(fruit))
    {
        return Maybe<string>.None;
    }

    return fruit; // implicit conversion
}
```

#### Equality

Use case: Comparing Maybes or values without knowledge of the
value of the Maybes

```csharp
Maybe<string> apple = "apple";
Maybe<string> orange = "orange";
string alsoOrange = "orange";
Maybe<string> noFruit = Maybe<string>.None;

Console.WriteLine(apple == orange); // false
Console.WriteLine(apple != orange); // true
Console.WriteLine(orange == alsoOrange); // true
Console.WriteLine(alsoOrange == noFruit); // false
```

#### ToString

```csharp
Maybe<string> apple = "apple";
Maybe<string> noFruit = Maybe<string>.None;

Console.WriteLine(apple.ToString()); // "apple"
Console.WriteLine(noFruit.ToString()); // "No value"
```

#### Value

Use case: Procedurally accessing the inner value of the Maybe

**Note**: Accessing this property will throw a `InvalidOperationException` if there is no value

```csharp
Maybe<string> apple = "apple";
Maybe<string> noFruit = Maybe<string>.None;

Console.WriteLine(apple.Value); // "apple";
Console.WriteLine(noFruit.Value); // throws InvalidOperationException !!
```

#### HasValue and HasNoValue

Use case: Procedurally checking if the Maybe has a value,
usually before accessing it directly

```csharp
void Response(string fruit)
{
    Console.WriteLine($"Yum, a {fruit} 😀");
}

Maybe<string> apple = "apple";
Maybe<string> noFruit = Maybe<string>.None;

if (apple.HasValue)
{
    Response(apple.Value); // safe to access since we checked above
}

if (noFruit.HasNoValue)
{
    Response("We're all out of fruit 😢");
}
```

#### UnWrap

Use case: Accessing the inner value without a check by providing a fallback
if no value exists

```csharp
void Response(string fruit)
{
    Console.WriteLine($"It's a {fruit}");
}

Maybe<string> apple = "apple";
Maybe<string> unknownFruit = Maybe<string>.None;

string appleValue = apple.UnWrap("banana");
string unknownFruitValue = unknownFruit.UnWrap("banana");

Response(appleValue); // It's a apple
Response(unknownFruitValue); // It's a banana
```

#### Map

Use case: Transforming the value in the Maybe, if there is one, without
needing to check if the value is there

```csharp
string CreateMessage(string fruit)
{
    return $"The fruit is a {fruit}";
}

Maybe<string> apple = "apple";
Maybe<string> noFruit = Maybe<string>.None;

Console.WriteLine(apple.Map(CreateMessage).UnWrap("No fruit")); // "The fruit is a apple"
Console.WriteLine(noFruit.Map(CreateMessage).UnWrap("No fruit")); // "No fruit"
```

#### Bind

Use case: Transforming from one Maybe into another Maybe
(like `Maybe.Map` but it transforms the Maybe instead of the inner value)

```csharp
Maybe<string> MakeAppleSauce(Maybe<string> fruit)
{
    if (fruit == "apple") // we can only make applesauce from apples 🍎
    {
        return "applesauce";
    }

    return Maybe<string>.None;
}

Maybe<string> apple = "apple";
Maybe<string> banana = "banana";

Console.WriteLine(apple.Bind(MakeAppleSauce)); // "applesauce"
Console.WriteLine(banana.Bind(MakeAppleSauce)); // "No value"
```

#### Choose

Use case: Filter a collection of Maybes to only the ones that have a value,
and then return the value for each, or map that value to a new one

```csharp
IEnumerable<Maybe<string>> unknownFruits = new[] { "apple", Maybe<string>.None, "banana" };

IEnumerable<string> knownFruits = unknownFruits.Choose();
IEnumerable<string> fruitResponses = unknownFruits.Choose(fruit => $"Delicious {fruit}");

Console.WriteLine(string.Join(", ", fruits)) // "apple, banana"
Console.WriteLine(string.Join(", ", fruitResponses)) // "Delicious apple, Delicious banana"
```

### Result

// TODO

## Testing

For extension methods on top of this library's `Result` and `Maybe` that you can use in tests,
you can use [FluentAssertions](https://fluentassertions.com/)
with [this NuGet package](https://www.nuget.org/packages/FluentAssertions.CSharpFunctionalExtensions/) ([GitHub link](https://github.com/pedromtcosta/FluentAssertions.CSharpFunctionalExtensions)).

Example:

```csharp
// Arrange
var myClass = new MyClass();

// Act
Result result = myClass.TheMethod();

// Assert
result.Should().BeSuccess();
```

## Read or Watch more about these ideas

- [Functional C#: Primitive obsession](http://enterprisecraftsmanship.com/2015/03/07/functional-c-primitive-obsession/)
- [Functional C#: Non-nullable reference types](http://enterprisecraftsmanship.com/2015/03/13/functional-c-non-nullable-reference-types/)
- [Functional C#: Handling failures, input errors](http://enterprisecraftsmanship.com/2015/03/20/functional-c-handling-failures-input-errors/)
- [Applying Functional Principles in C# Pluralsight course](https://enterprisecraftsmanship.com/ps-func)

## Contributors

A big thanks to the project contributors!

- [Ali Khalili](https://github.com/AliKhalili)
- [Andrei Andreev](https://github.com/Razenpok)
- [YudApps](https://github.com/YudApps)
- [dataphysix](https://github.com/dataphysix)
- [Laszlo Lueck](https://github.com/LaszloLueck)
- [Sean G. Wright](https://github.com/seangwright)
- [Samuel Viesselman](https://github.com/SamuelViesselman)
- [Stian Kroknes](https://github.com/stiankroknes)
- [dataneo](https://github.com/dataneodev)
- [michaeldileo](https://github.com/michaeldileo)
- [Renato Ramos Nascimento](https://github.com/renato04)
- [Patrick Drechsler](https://github.com/draptik)
- [Vadim Mingazhev](https://github.com/mingazhev)
- [Darick Carpenter](https://github.com/darickc)
- [Stéphane Mitermite](https://github.com/kakone)
- [Markus Nißl](https://github.com/mnissl)
- [Adrian Frielinghaus](https://github.com/freever)
- [svroonland](https://github.com/svroonland)
- [JvSSD](https://github.com/JvSSD)
- [mnissl](https://github.com/mnissl)
- [Vladimir Makaev](https://github.com/VladimirMakaev)
- [Ben Smith](https://github.com/benprime)
- [pedromtcosta](https://github.com/pedromtcosta)
- [Michał Bator](https://github.com/MikelThief)
- [mukmyash](https://github.com/mukmyash)
- [azm102](https://github.com/azm102)
- [ThomasDC](https://github.com/thomasdc)
- [bopazyn](https://github.com/bopazyn)
- [Joris Goovaerts](https://github.com/CommCody)
- [Ivan Deev](https://github.com/BillyFromAHill)
- [Damian Płaza](https://github.com/dpraimeyuu)
- [ergwun](https://github.com/ergwun)
- [Michael DiLeo](https://github.com/pilotMike)
- [Jean-Claude](https://github.com/jcsonder)
- [Matt Jenkins](https://github.com/space-alien)
- [Michael Altmann](https://github.com/altmann)
- [Steven Giesel](https://github.com/linkdotnet)
- [Anton Hryshchanka](https://github.com/ahryshchanka)
- [Mikhail Bashurov](https://github.com/saitonakamura)
- [kostekk88](https://github.com/kostekk88)
- [Carl Abrahams](https://github.com/CarlHA)
- [golavr](https://github.com/golavr)
- [Sviataslau Hankovich](https://github.com/hankovich)
- [Chad Gilbert](https://github.com/freakingawesome)
- [Robert Sęk](https://github.com/robosek)
- [Sergey Solomentsev](https://github.com/SergAtGitHub)
- [Malcolm J Harwood](https://github.com/mjharwood)
- [Dragan Stepanovic](https://github.com/dragan-stepanovic)
- [Ivan Novikov](https://github.com/jonny-novikov)
- [Denis Molokanov](https://github.com/dmolokanov)
- [Gerald Wiltse](https://github.com/solvingJ)
- [yakimovim](https://github.com/yakimovim)
- [Alex Erygin](https://github.com/alex-erygin)
- [Omar Aloraini](https://github.com/omaraloraini)
