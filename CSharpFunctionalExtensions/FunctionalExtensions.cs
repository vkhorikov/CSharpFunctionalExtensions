using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace System
{
    public static class FunctionalExtensions
    {
        public static TResult PipeTo<TSource, TResult>(
            this TSource source, Func<TSource, TResult> func)
            => func(source);

        public static async Task<TResult> PipeToAsync<TSource, TResult>(
            this Task<TSource> source, Func<TSource, Task<TResult>> func)
            => await func(await source);
        
        public static async Task<TResult> PipeToAsync<TSource, TResult>(
            this Task<TSource> source, Func<TSource, TResult> func)
            => func(await source);
        
        public static TOutput EitherOr<TInput, TOutput>(this TInput o, Func<TInput, TOutput> ifTrue,
            Func<TInput, TOutput> ifFalse)
            => o.EitherOr(x => x != null, ifTrue, ifFalse);

        public static TOutput EitherOr<TInput, TOutput>(this TInput o, Func<TInput, bool> condition,
            Func<TInput, TOutput> ifTrue, Func<TInput, TOutput> ifFalse)
            => condition(o) ? ifTrue(o) : ifFalse(o);

        public static TOutput EitherOr<TInput, TOutput>(this TInput o, bool condition,
            Func<TInput, TOutput> ifTrue, Func<TInput, TOutput> ifFalse)
            => condition ? ifTrue(o) : ifFalse(o);
    }
}