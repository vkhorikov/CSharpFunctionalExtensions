﻿using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static Task<Maybe<K>> Bind<T, K>(this Maybe<T> maybe, Func<T, Task<Maybe<K>>> selector)
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None.AsCompletedTask();

            return selector(maybe.GetValueOrThrow());
        }

        public static Task<Maybe<K>> Bind<T, K, TContext>(
                this Maybe<T> maybe,
                Func<T, TContext, Task<Maybe<K>>> selector,
                TContext context)
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None.AsCompletedTask();

            return selector(maybe.GetValueOrThrow(), context);
        }
    }
}
