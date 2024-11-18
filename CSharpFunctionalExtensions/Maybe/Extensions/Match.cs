using System;
using System.Collections.Generic;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static TE Match<TE, T>(in this Maybe<T> maybe, Func<T, TE> Some, Func<TE> None)
        {
            return maybe.HasValue ? Some(maybe.GetValueOrThrow()) : None();
        }

        public static TE Match<TE, T, TContext>(
            in this Maybe<T> maybe,
            Func<T, TContext, TE> Some,
            Func<TContext, TE> None,
            TContext context
        )
        {
            return maybe.HasValue ? Some(maybe.GetValueOrThrow(), context) : None(context);
        }

        public static void Match<T>(in this Maybe<T> maybe, Action<T> Some, Action None)
        {
            if (maybe.HasValue)
                Some(maybe.GetValueOrThrow());
            else
                None();
        }

        public static void Match<T, TContext>(
            in this Maybe<T> maybe,
            Action<T, TContext> Some,
            Action<TContext> None,
            TContext context
        )
        {
            if (maybe.HasValue)
                Some(maybe.GetValueOrThrow(), context);
            else
                None(context);
        }

        public static TE Match<TE, TKey, TValue>(
            in this Maybe<KeyValuePair<TKey, TValue>> maybe,
            Func<TKey, TValue, TE> Some,
            Func<TE> None
        )
        {
            return maybe.HasValue
                ? Some.Invoke(maybe.GetValueOrThrow().Key, maybe.GetValueOrThrow().Value)
                : None.Invoke();
        }

        public static TE Match<TE, TKey, TValue, TContext>(
            in this Maybe<KeyValuePair<TKey, TValue>> maybe,
            Func<TKey, TValue, TContext, TE> Some,
            Func<TContext, TE> None,
            TContext context
        )
        {
            return maybe.HasValue
                ? Some.Invoke(maybe.GetValueOrThrow().Key, maybe.GetValueOrThrow().Value, context)
                : None.Invoke(context);
        }

        public static void Match<TKey, TValue>(
            in this Maybe<KeyValuePair<TKey, TValue>> maybe,
            Action<TKey, TValue> Some,
            Action None
        )
        {
            if (maybe.HasValue)
                Some.Invoke(maybe.GetValueOrThrow().Key, maybe.GetValueOrThrow().Value);
            else
                None.Invoke();
        }

        public static void Match<TKey, TValue, TContext>(
            in this Maybe<KeyValuePair<TKey, TValue>> maybe,
            Action<TKey, TValue, TContext> Some,
            Action<TContext> None,
            TContext context
        )
        {
            if (maybe.HasValue)
                Some.Invoke(maybe.GetValueOrThrow().Key, maybe.GetValueOrThrow().Value, context);
            else
                None.Invoke(context);
        }
    }
}
