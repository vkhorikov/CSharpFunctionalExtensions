namespace System {
    using System.Diagnostics;
#if !TASKEX
#endif
    /// <summary>
    /// THIS FUNCTIONS RELY ON THE action/predicate/func NEVER throwing errors, unless a errorconvert is  passed in
    ///  **NEED C# 7.3** for correct overload resolution on some of these
    /// </summary>
    [DebuggerStepThrough]
    public static class ResultExtensions {
        #region Just to Satisfy Monadic laws
        //### Two **Methods** of the Monoid Type
        //         A append(A a, A b)
        //         A identity;   // identity of Result<T> is Result<Unit>
        // Two Properties
        //1.        Identity(no-op value - does not do anything when used with the** append** method on the Type)
        //2.        **Associativity**: Grouping of append does not matter(Two types coming together to make another of the same type.)
        //
        //these methods are not needed because wea are nearly always using Funcs to append within the Bind/Map ops
        //Append is implemented and handles Identity
        //Identity  is Result<Unit> , or actions rather than funcs in arguements
        //Map is implemented
        //FlatMap is Bind in this class 
        //Pure (lift) is Result.OK(a), or Result<T>.Fail(resultError)
        public static Result<T2> Append<T1, T2>(this Result<T1> result, Result<T2> result2)
                => result.IsFailure ? Result<T2>.Fail(result.Error) : result2;
        public static Result<T1> Append<T1>(this Result<Unit> result, Result<T1> result2)
            => result.IsFailure ? Result<T1>.Fail(result.Error) : result2;
        public static Result<T1> Append<T1>(this Result<T1> result, Result<Unit> result2)
            => result.IsFailure ? result : result2.IsFailure ? Result<T1>.Fail(result2.Error) : result;
        #endregion
        //public static Result<T> AsFail<T>(this Result<T> value, ResultErrorValue error)
        //    => Result<T>.Fail(error);
        //#Map
        public static Result<T> Map<P, T>(in this Result<P> result, Func<P, T> func, Func<Exception, Enum> errorConvert = null) {
            Debug.Assert((result is Result<Result<P>>) == false);
            try {
                return result.IsFailure ? Result<T>.Fail(result.Error) : Result.Ok(func(result.Value));
            } catch (Exception ex) when (errorConvert != null) {
                return Result<T>.Fail(errorConvert(ex));
            }
        }
        public static Result<T> Map<T>(in this Result<T> result, Action<T> action, Func<Exception, Enum> errorConvert = null) {
            Debug.Assert((result is Result<Result<T>>) == false);
            try {
                if (result.IsSuccess) {
                    action(result.Value);
                }
                return result;
            } catch (Exception ex) {
                if (errorConvert is null) {
                    return Result<T>.Fail(ResultError.UnhandledExceptionDoingBenignAction);
                }
                return Result<T>.Fail(errorConvert(ex));
            }
        }
        //#BIND
        public static Result<T> Bind<P, T>(in this Result<P> result, Func<P, Result<T>> func) {
            Debug.Assert((result is Result<Result<P>>) == false);
            return result.IsFailure ? Result<T>.Fail(result.Error) : func(result.Value);
        }
        public static Result<T> Bind<P1, P2, T>(in this Result<P1> p1, Func<Result<P2>> funcp2, Func<P1, P2, Result<T>> funcResult)
            => p1.Bind(p => funcp2().Bind(r2 => funcResult(p, r2)));
        public static Result<T> Bind<P1, P2, P3, T>(in this Result<P1> p1, Func<Result<P2>> funcp2, Func<Result<P3>> funcp3, Func<P1, P2, P3, Result<T>> func)
            => p1.Bind(p => funcp2().Bind(r2 => funcp3().Bind(r3 => func(p, r2, r3))));
   
        public static Result<T> Ensure<T>(in this Result<T> result,  Func<T, Enum> errorfunc) {
            if (result.IsFailure )
                return result;
            Enum err = errorfunc(result.Value);
            if(err.Equals(ResultError.None))
                return result;
            return Result<T>.Fail(err);
        }
        //#SelfBind
        public static Result<T> SelfBind<P, T>(in this Result<T> r, Func<Result<P>> f, Action<T, P> s = null) {
            if (!r.IsSuccess) {
                return r;
            }
            Result<P> p = f();
            if (p.IsSuccess) {
                s?.Invoke(r.Value, p.Value);
                return r;
            }
            return Result<T>.Fail(p.Error);
        }
        public static Result<T> SelfBind<P, T>(in this Result<T> r, Func<T, Result<P>> f, Action<T, P> s = null) {
            if (!r.IsSuccess) {
                return r;
            }
            Result<P> p = f(r.Value);
            if (p.IsSuccess) {
                s?.Invoke(r.Value, p.Value);
                return r;
            }
            return Result<T>.Fail(p.Error);
        }
        public static Maybe<T> ToMaybe<T>(in this Result<T> result) where T : class {
            return result.IsSuccess ? Maybe.Create(result.Value) : Maybe<T>.Empty;
        }
    }
}
