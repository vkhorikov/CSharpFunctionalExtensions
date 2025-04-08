using System;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        /// Convert an optional value into a Result. The result, being optional, is of type Maybe.
        /// </summary>
        public static Result<Maybe<TOut>, TError> BindOptional<TIn, TOut, TError>(
            this Maybe<TIn> maybe,
            Func<TIn, Result<TOut, TError>> bind)
        {
            return maybe.Bind(v => Maybe.From(bind(v))).Optional();
        }
        
        /// <summary>
        /// Convert an optional value into a Result. The result, being optional, is of type Maybe.
        /// </summary>
        public static Result<Maybe<TOut>> BindOptional<TIn, TOut>(
            this Maybe<TIn> maybe,
            Func<TIn, Result<TOut>> bind)
        {
            return maybe.Bind(v => Maybe.From(bind(v))).Optional();
        }
    }
}
