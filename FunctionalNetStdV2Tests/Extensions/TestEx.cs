using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalNetStdV2Tests {
   static  class TestEx {
        public static T AssertValue<T>( this Result<T> r) {
            Assert.IsTrue(r.IsSuccess, $"Result Error {r.Error}");
            return r.Value;
        }
        public static T AssertValue<T>( this Result<Maybe<T>> r) {
            Assert.IsTrue(r.IsSuccess, $"Result Error {r.Error}");
            Assert.IsTrue(r.Value.IsFull, "Maybe is Empty "+typeof(T).Name);
            return r.Value.Value;
        }
        public static Result<T> AssertError<T>( this Result<T> r) {
            Assert.IsTrue(r.IsFailure);
            return r;
        }
        public static IEnumerable<T> AssertCount<T>(this IEnumerable<T> r, int c,string message = null) {
            Assert.AreEqual<int>(c,r.Count(),$"Count expected {c}, found {r.Count()} {message}");
            return r;
        }
    }
}
