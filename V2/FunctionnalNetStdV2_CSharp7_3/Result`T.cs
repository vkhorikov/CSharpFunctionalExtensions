namespace System {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Monad - Result with Value OR Error
    /// The Golden rule to be followed is that Methods that return Result's CANNOT RETURN NULL as Result&lt;T&gtT; is a struct
    /// Futhermore no method that returns a Result&lt;T&gtT; is allowed throw errors. All errors must be captured and turned in to ResultError
    /// Type of append Identity is Result&lt;Unit&gt;>
    /// The Golden rule to be followed is that Methods that return Result's 
    /// 1. CANNOT RETURN NULL 
    /// 2. CANNOT THROW ERRORS
    /// 3. Ctor param isSuccess if false, param resulterror SHOULD NOT BE ResultErrorValue.None
    /// 4. Ctor param isSuccess if true, param resulterror SHOULD BE ResultErrorValue.None
    /// </summary>

    [DebuggerStepThrough]

    public struct Result<T> {

        public static Result<T> Fail(Enum resulterror)
            => new Result<T>(default(T), false, resulterror);
        //This should ONLY BE CALLED BY Result.Ok(object).
        public static Result<T> Ok(T value)
              => new Result<T>(value, true, ResultError.None);

        public readonly bool IsSuccess;
        public readonly Enum Error;
        private readonly T _value;
        public bool IsFailure => !IsSuccess;

        public bool IsNotInit => IsFailure && Error==null;
        private Result(T value, bool isSuccess, Enum failure) {
            if (isSuccess && !failure.Equals(ResultError.None))
                throw new ArgumentException(nameof(failure), "error should be ResultError.None on success");
            else if (!isSuccess && failure.Equals(ResultError.None))
                throw new ArgumentException(nameof(failure), "Error should not be null and should not be None(zero) on failure");
            IsSuccess = isSuccess;
            Error = failure;
            _value = value;
        }
        public T Value {
            get {
                if (IsFailure)
                    throw new InvalidOperationException("success should be true when Result<T>.Value is accessed. Error was " + Error.ToString());
                return _value;
            }
        }
        //public T UnWrap() {...} // Using this leads to null errors cos we need to check the Result.IsSuUccess for clarity of code and a Result can be null, 
        public override string ToString()
         => IsFailure ? Error.ToString() : _value?.ToString();
    }
    //public class Result<T> : Result<T, ResultErrorValue> {
    //    public static new Result<T> Fail(ResultErrorValue resulterror)
    //             => new Result<T>(false,default,  resulterror);
    //    public static new Result<T> Ok(T value)
    //                => new Result<T>(true,value, ResultErrorValue.None);

    //    protected Result(bool isSuccess, T success, ResultErrorValue failure)
    //        : base(isSuccess, success, failure) {
    //        if (isSuccess && failure != ResultErrorValue.None)
    //            throw new ArgumentException(nameof(failure), "error should be ResultErrorValue.None on success");
    //        if (!isSuccess && failure == ResultErrorValue.None)
    //            throw new ArgumentException(nameof(failure), "success should be true when ResultErrorValue.None");

    //    }
    //    public override string ToString()
    //                => IsSuccess ? Value?.ToString():Error.ErrorString()  ;

    //}
}
