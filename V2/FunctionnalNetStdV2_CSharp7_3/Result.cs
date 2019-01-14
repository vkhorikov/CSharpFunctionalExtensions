namespace System {
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;

    /// <summary>
    /// Result OR Error
    /// The Golden rule to be followed is that Methods that return Result's CANNOT RETURN NULL as Result&lt;T&gtT; is a struct
    /// Futhermore no method that returns a Result&lt;T&gtT; is allowed throw errors. All errors must be captured and turned in to ResultError
    /// </summary>
    [DebuggerStepThrough]
    public static partial class Result {

        public static Result<T> Ok<T>(T value)
              => Result<T>.Ok(value);
    }

}
