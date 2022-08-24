using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests;

public class AmbiguityTests
{
    [Fact]
    public void The_following_method_calls_should_compile_without_raising_ambiguity_errors()
    {
        GetProfileAsync();
        GetProfileWithErrorAsync();
    }

    [Fact]
    public async Task The_following_code_should_compile_without_raising_ambiguity_errors()
    {
        Result<T1, E> result = Result.Success<T1, E>(new());

        Task<Result<T2, E>> GetTask() => Task.FromResult(Result.Success<T2, E>(new()));

        await result
            .Bind(async _ => await GetTask());
    }

    private Task<Result<Profile>> GetProfileAsync() =>
        Result.Try(async () =>
        {
            await Task.Yield();

            return new Profile();
        });

    private Task<Result<Profile, Error>> GetProfileWithErrorAsync() =>
        Result.Try(async () =>
        {
            await Task.Yield();

            return new Profile();
        }, _ => new Error());

    private class Profile
    {
    }

    private class Error
    {
    }

    class T1
    {
    }

    class T2
    {
    }

    class E
    {
    }
}
