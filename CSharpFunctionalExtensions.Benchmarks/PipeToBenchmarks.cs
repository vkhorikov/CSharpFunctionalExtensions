using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using static CSharpFunctionalExtensions.Tests.FunctionalExtensionsHelper;

namespace CSharpFunctionalExtensionss.Benchmarks;

// [SimpleJob(RunStrategy.Monitoring, launchCount: 10, warmupCount: 3, targetCount: 100)]
[MemoryDiagnoser]
public class PipeToBenchmark
{
    [Benchmark]
    public void NativeCode()
    {
        SkipTake(ToString(Mul5(Plus2(10))));
    }
    
    [Benchmark]
    public void WithPipeTo()
    {
        10
            .PipeTo(Plus2)
            .PipeTo(Mul5)
            .PipeTo(ToString)
            .PipeTo(SkipTake);
    }
}
