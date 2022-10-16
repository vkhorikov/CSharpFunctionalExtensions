using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests;
using static FunctionalExtensionsHelper;

public class FunctionalExtensionsTests
{
    [Fact]
    public void PipeTo()
    {
        var res = 10
            .PipeTo(Plus2)
            .PipeTo(Mul5)
            .PipeTo(IntToString)
            .PipeTo(SkipTake);
        
        Assert.Equal("0", res);
    }

    private static HttpClient _httpClient = new();
    
    [Fact]
    public async Task PipeToAsync()
    {
        var res = await "https://google.com"
            .PipeTo(_httpClient.GetAsync)
            .PipeToAsync(x => x.Content.ReadAsStringAsync());
        
        Assert.StartsWith("<!doctype html>", res.ToLowerInvariant());
    }
}