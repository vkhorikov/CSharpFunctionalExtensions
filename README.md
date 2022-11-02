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

#### None/No Value

Use case: Replacing `null` or the
[Null Object Pattern](https://enterprisecraftsmanship.com/2015/03/13/functional-c-non-nullable-reference-types/) for representing 'missing' data.

```csharp
int storeInventory = ...

Maybe<string> fruit = storeInventory > 0
    ? Maybe<string>.From("apple")
    : Maybe<string>.None;

// or where the generic type is a reference type

Maybe<string> fruit = null;

// or where the generic type is a value type

Maybe<int> fruit = default;
```

#### Implicit Conversion

Use case: Easily creating a Maybe from a value

```csharp
// Constructing a Maybe
Maybe<string> apple = "apple"; // implicit conversion

// Or as a method return value
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
inner value of the Maybes

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

#### GetValueOrThrow

Use case: Procedurally accessing the inner value of the Maybe

**Note**: Call this will throw a `InvalidOperationException` if there is no value

```csharp
Maybe<string> apple = "apple";
Maybe<string> noFruit = Maybe<string>.None;

Console.WriteLine(apple.GetValueOrThrow()); // "apple";
Console.WriteLine(noFruit.GetValueOrThrow()); // throws InvalidOperationException !!
```

#### HasValue and HasNoValue

Use case: Procedurally checking if the Maybe has a value,
usually before accessing the value directly

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

#### GetValueOrDefault

Use case: Safely accessing the inner value, without checking if there is one, by providing a fallback
if no value exists

```csharp
void Response(string fruit)
{
    Console.WriteLine($"It's a {fruit}");
}

Maybe<string> apple = "apple";
Maybe<string> unknownFruit = Maybe<string>.None;

string appleValue = apple.GetValueOrDefault("banana");
string unknownFruitValue = unknownFruit.GetValueOrDefault("banana");

Response(appleValue); // It's a apple
Response(unknownFruitValue); // It's a banana
```

#### Where

Use case: Converting a Maybe with a value to a `Maybe.None` if a condition isn't met

**Note**: The predicate passed to `Where` (ex )

```csharp
bool IsMyFavorite(string fruit)
{
    return fruit == "papaya";
}

Maybe<string> apple = "apple";

Maybe<string> favoriteFruit = apple.Where(IsMyFavorite);

Console.WriteLine(favoriteFruit.ToString()); // "No value"
```

#### Map

Use case: Transforming the value in the Maybe, if there is one, without
needing to check if the value is there

**Note**: the delegate (ex `CreateMessage`) passed to `Maybe.Map()` is only executed if the Maybe has an inner value

```csharp
string CreateMessage(string fruit)
{
    return $"The fruit is a {fruit}";
}

Maybe<string> apple = "apple";
Maybe<string> noFruit = Maybe<string>.None;

Console.WriteLine(apple.Map(CreateMessage).Unwrap("No fruit")); // "The fruit is a apple"
Console.WriteLine(noFruit.Map(CreateMessage).Unwrap("No fruit")); // "No fruit"
```

#### Select

**Alias**: `Maybe.Select()` is an alias of `Maybe.Map()`

#### Bind

Use case: Transforming from one Maybe into another Maybe
(like `Maybe.Map` but it transforms the Maybe instead of the inner value)

**Note**: the delegate (ex `MakeAppleSauce`) passed to `Maybe.Bind()` is only executed if the Maybe has an inner value

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
Maybe<string> noFruit = Maybe<string>.None;

Console.WriteLine(apple.Bind(MakeAppleSauce).ToString()); // "applesauce"
Console.WriteLine(banana.Bind(MakeAppleSauce).ToString()); // "No value"
Console.WriteLine(noFruit.Bind(MakeAppleSauce).ToString()); // "No value"
```

#### SelectMany

**Alias**: `Maybe.SelectMany()` is an alias of `Maybe.Bind()`

#### Choose

Use case: Filter a collection of Maybes to only the ones that have a value,
and then return the value for each, or map that value to a new one

**Note**: the delegate passed to `Maybe.Choose()` is only executed on the Maybes of the collection with an inner value

```csharp
IEnumerable<Maybe<string>> unknownFruits = new[] { "apple", Maybe<string>.None, "banana" };

IEnumerable<string> knownFruits = unknownFruits.Choose();
IEnumerable<string> fruitResponses = unknownFruits.Choose(fruit => $"Delicious {fruit}");

Console.WriteLine(string.Join(", ", fruits)) // "apple, banana"
Console.WriteLine(string.Join(", ", fruitResponses)) // "Delicious apple, Delicious banana"
```

#### Execute

Use case: Safely executing a `void` (or `Task`) returning operation on the Maybe inner value
without checking if there is one

**Note**: the `Action` (ex `PrintFruit`) passed to `Maybe.Execute()` is only executed if the Maybe has an inner value

```csharp
void PrintFruit(string fruit)
{
    Console.WriteLine($"This is a {fruit}");
}

Maybe<string> apple = "apple";
Maybe<string> noFruit = Maybe<string>.None;

apple.Execute(PrintFruit); // "This is a apple"
noFruit.Execute(PrintFruit); // no output to the console
```

#### ExecuteNoValue

Use case: Executing a `void` (or `Task`) returning operation when the Maybe has no value

```csharp
void LogNoFruit(string fruit)
{
    Console.WriteLine($"There are no {fruit}");
}

Maybe<string> apple = "apple";
Maybe<string> banana = Maybe<string>.None;

apple.ExecuteNoValue(() => LogNoFruit("apple")); // no output to console
banana.ExecuteNoValue(() => LogNoFruit("banana")); // "There are no banana"
```

#### Or

Use case: Supplying a fallback value Maybe or value in the case that the Maybe has no inner value

**Note**: The fallback `Func<T>` (ex `() => "banana"`) will only be executed
if the Maybe has no inner value

```csharp
Maybe<string> apple = "apple";
Maybe<string> banana = "banana";
Maybe<string> noFruit = Maybe<string>.None;

Console.WriteLine(apple.Or(banana).ToString()); // "apple"
Console.WriteLine(noFruit.Or(() => banana)).ToString()); // "banana"
Console.WriteLine(noFruit.Or("banana").ToString()); // "banana"
Console.WriteLine(noFruit.Or(() => "banana").ToString()); // "banana"
```

#### Match

Use case: Defining two operations to perform on a Maybe.
One to be executed if there is an inner value, and the other to executed if there is not

```csharp
Maybe<string> apple = "apple";
Maybe<string> noFruit = Maybe<string>.None;

// Void returning Match
apple.Match(
    fruit => Console.WriteLine($"It's a {fruit}"),
    () => Console.WriteLine("There's no fruit"));

// Mapping Match
string fruitMessage = noFruit.Match(
    fruit => $"It's a {fruit}",
    () => "There's no fruit"));

Console.WriteLine(fruitMessage); // "There's no fruit"
```

#### TryFirst and TryLast

Use case: Replacing `.FirstOrDefault()` and `.LastOrDefault()` so that you can return a
Maybe instead of a `null` or value type default value (like `0`, `false`) when working with collections

```csharp
IEnumerable<string> fruits = new[] { "apple", "coconut", "banana" };

Maybe<string> firstFruit = fruits.TryFirst();
Maybe<string> probablyABanana = fruits.TryFirst(fruit => fruit.StartsWith("ba"));
Maybe<string> aPeachOrAPear = fruits.TryFirst(fruit => fruit.StartsWith("p"));

Console.WriteLine(firstFruit.ToString()); // "apple"
Console.WriteLine(probablyABanana.ToString()); // "banana"
Console.WriteLine(aPeachOrAPear.ToString()); // "No value"

Maybe<string> lastFruit = fruits.TryLast();
Maybe<string> anAppleOrApricot = fruits.TryLast(fruit => fruit.StartsWith("a"));

Console.WriteLine(lastFruit.ToString()); // "banana"
Console.WriteLine(anAppleOrApricot.ToString()); // "apple"
```

#### TryFind

Use case: Safely getting a value out of a Dictionary

```csharp
Dictionary<string, int> fruitInventory = new()
{
    { "apple", 10 },
    { "banana", 2 }
};

Maybe<int> appleCount = fruitInventory.TryFind("apple");
Maybe<int> kiwiCount = fruitInventory.TryFind("kiwi");

Console.WriteLine(appleCount.ToString()); // "10"
Console.WriteLine(kiwiCount.ToString()); // "No value"
```

#### ToResult

Use case: Representing the lack of an inner value in a Maybe as a failed operation

**Note**: See `Result` section below

```csharp
Maybe<string> fruit = "banana";
Maybe<string> noFruit = Maybe<string>.None;

string errorMessage = "There was no fruit to give";

Result<string> weGotAFruit = fruit.ToResult(errorMessage);
Result<string> failedToGetAFruit = noFruit.ToResult(errorMessage);

Console.WriteLine(weGotAFruit.Value); // "banana"
Console.WriteLine(failedToGetAFruit.Error); // "There was no fruit to give"
```

### Result

#### Explicit Construction: Success and Failure

Use case: Creating a new Result in a Success or Failure state

```csharp
record FruitInventory(string Name, int Count);

Result<FruitInventory> appleInventory = Result.Success(new FruitInventory("apple", 4));
Result<FruitInventory> failedOperation = Result.Failure<FruitInventory>("Could not find inventory");
Result successInventoryUpdate = Result.Success();
```

#### Conditional Construction: SuccessIf and FailureIf

Use case: Creating successful or failed Results based on expressions or delegates instead of if/else statements or ternary expressions

```csharp
bool onTropicalIsland = true;

Result foundCoconut = Result.SuccessIf(onTropicalIsland, "These trees seem bare 🥥");
Result foundGrapes = Result.FailureIf(() => onTropicalIsland, "No grapes 🍇 here");

// or

bool isNewShipmentDay = true;

Result<FruitInventory> appleInventory = Result.SuccessIf(isNewShipmentDay, new FruitInventory("apple", 4), "No 🍎 today");
Result<FruitInventory> bananaInventory = Result.SuccessIf(() => isNewShipmentDay, new FruitInventory("banana", 2), "All out of 🍌");

// or

bool afterBreakfast = true;

Result<FruitInventory> orangeInventory = Result.FailureIf(afterBreakfast, new FruitInventory("orange", 10), "No 🍊 today");
Result<FruitInventory> grapefruitInventory = Result.FailureIf(() => afterBreakfast, new FruitInventory("grapefruit", 5), "No grapefruit 😢");
```

#### Implicit Conversion

Use case: Easily creating a successful result from a value

```csharp
Result<FruitInventory> appleInventory = new FruitInventory("apple", 4);
Result failedInventoryUpdate = "Could not update inventory";
```

#### ToString

Use case: Printing out the state of a Result and its inner value or error

```csharp
Result<FruitInventory> appleInventory = new FruitInventory("apple", 4);
Result<FruitInventory> bananaInventory = Result.Failure<FruitInventory>("Could not find any bananas");
Result failedInventoryUpdate = "Could not update inventory";
Result successfulInventoryUpdate = Result.Success();

Console.WriteLine(appleInventory.ToString()); // "Success(FruitInventory { Name = apple, Count = 4 })"
Console.WriteLine(bananaInventory.ToString()); // "Failure(Could not find any bananas)"
Console.WriteLine(failedInventoryUpdate.ToString()); // "Failure(Could not update inventory)"
Console.WriteLine(successfulInventoryUpdate.ToString()); // "Success"
```

#### Map

Use case: Transforming the inner value of a successful Result, without needing to check on
the success/failure state of the Result

**Note**: the delegate (ex `CreateMessage`) passed to `Result.Map()` is only executed if the Result was successful

```csharp
string CreateMessage(FruitInventory inventory)
{
    return $"There are {inventory.Count} {inventory.Name}(s)";
}

Result<FruitInventory> appleInventory = new FruitInventory("apple", 4);
Result<FruitInventory> bananaInventory = Result.Failure<FruitInventory>("Could not find any bananas");

Console.WriteLine(appleInventory.Map(CreateMessage).ToString()); // "Success(There are 4 apple(s))"
Console.WriteLine(bananaInventory.Map(CreateMessage).ToString()); // "Failure(Could not find any bananas)"
```

#### MapError

Use case: Transforming the inner error of a failed Result, without needing to check on
the success/failure state of the Result

**Note**: the delegate (ex `ErrorEnhancer`) passed to `Result.MapError()` is only executed if the Result failed

```csharp
string ErrorEnhancer(string errorMessage)
{
    return $"Failed operation: {errorMessage}";
}

Console.WriteLine(appleInventory.MapError(ErrorEnhancer).ToString()); // "Success(FruitInventory { Name = apple, Count = 4 })"
Console.WriteLine(bananaInventory.MapError(ErrorEnhancer).ToString()); // "Failed operation: Could not find any bananas"
```

## Testing

### CSharpFunctionalExtensions.FluentAssertions

A small set of extensions to make test assertions more fluent when using CSharpFunctionalExtensions! Check out the [repo for this library](https://github.com/NitroDevs/CSharpFunctionalExtensions.FluentAssertions) more information!

Includes custom assertions for
- Maybe
- Result
- Result<T>
- Result<T, E>
- UnitResult

#### Example

```csharp
var result = Result.Success(420);

result.Should().Succeed(); // passes
result.Should().SucceedWith(420); // passes
result.Should().SucceedWith(69); // throws
result.Should().Fail(); // throws
```

## Read or Watch more about these ideas

- [Functional C#: Primitive obsession](https://enterprisecraftsmanship.com/2015/03/07/functional-c-primitive-obsession/)
- [Functional C#: Non-nullable reference types](https://enterprisecraftsmanship.com/2015/03/13/functional-c-non-nullable-reference-types/)
- [Functional C#: Handling failures, input errors](https://enterprisecraftsmanship.com/2015/03/20/functional-c-handling-failures-input-errors/)
- [Applying Functional Principles in C# Pluralsight course](https://enterprisecraftsmanship.com/ps-func)

## Related Projects

- [Typescript Functional Extensions](https://github.com/seangwright/typescript-functional-extensions)

## Contributors

A big thanks to the project contributors!

- [Kyle McMaster](https://github.com/KyleMcMaster)
- [Vinícius Beloni Cubas](https://github.com/vinibeloni)
- [rutkowskit](https://github.com/rutkowskit)
- [Giovanni Costagliola](https://github.com/MrBogomips)
- [Mark Wainwright](https://github.com/wainwrightmark)
- [ProphetLamb](https://github.com/ProphetLamb)
- [Paul Williams](https://github.com/Paul-Williams)
- [alexmurari](https://github.com/alexmurari)
- [ruud](https://github.com/ruudhe)
- [Tomasz Malinowski](https://github.com/Yaevh)
- [Staffan Wingren](https://github.com/staffanwingren)
- [Tim Schneider](https://github.com/DerStimmler)
- [Piotr Karasiński](https://github.com/Caleb9)
- [Marcel Roozekrans](https://github.com/MarcelRoozekrans)
- [guythetechie](https://github.com/guythetechie)
- [Logan Kahler](https://github.com/lqkahler)
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
