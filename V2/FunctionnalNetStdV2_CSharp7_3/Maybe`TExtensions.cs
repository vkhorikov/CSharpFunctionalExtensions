namespace System {
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Diagnostics;
   using System.Threading.Tasks;

   [DebuggerStepThrough]
   public static class MayBeTExtensions {
        public static Maybe<R> Map<T, R>(this Maybe<T> maybe, Func<T, R> func) 
      => (maybe.IsFull) ? Maybe<R>.Create(func(maybe.Value)) : Maybe<R>.Empty;


        public static Maybe<R> Bind<T, R>(this Maybe<T> maybe, Func<T, Maybe<R>> func) 
        => (maybe.IsFull) ? func(maybe.Value) : Maybe<R>.Empty;


        public static Result<T> ToResult<T>(this Maybe<T> maybe, Enum onNoValue) 
          => (maybe.IsFull)
              ? Result.Ok(maybe.Value)
              : Result<T>.Fail(onNoValue);

        public static  Task<Result<T>> ToResultAsync<T>(this Task<Maybe<T>> maybeTask, Enum errorMessage)
       {
            return maybeTask.ContinueWith(z => {
                if (z.IsFaulted) {
                    return Result<T>.Fail(ResultError.AsyncResultUnitError);
                } else if (z.IsCanceled) {
                    return Result<T>.Fail(ResultError.Cancelled);
                }
                return z.Result.ToResult(errorMessage);
            });
        }
        public static Maybe<T> Where<T>(this Maybe<T> maybe, Func<T, bool> predicate) 
            => (maybe.IsEmpty || !predicate(maybe.Value)) ? Maybe<T>.Empty : maybe;


        public static IEnumerable<T> SelectValues<T>(this IEnumerable<Maybe<T>> maybes) 
         => maybes
             .Where(m => m.IsFull)
             .Select(m => m.Value);

        public static T Terminate<T>(this Maybe<T> m, T defaultValue) 
            => m.IsFull ? m.Value : defaultValue;
        public static T Terminate<T>(this Maybe<T> m)
            => m.IsFull ? m.Value : default(T);

    }

}
