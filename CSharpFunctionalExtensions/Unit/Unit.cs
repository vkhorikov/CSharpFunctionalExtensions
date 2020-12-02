using System;
using System.Diagnostics.Contracts;

namespace CSharpFunctionalExtensions
{
    /// <summary>
    ///     A unit type is a type that allows only one value (and thus can hold no information)
    /// </summary>
    [Serializable]
    public struct Unit : IEquatable<Unit>, IComparable<Unit>
    {
        public static readonly Unit Default = new Unit();

        [Pure] public override int GetHashCode() => 0;
        [Pure] public override bool Equals(object obj) => obj is Unit;
        [Pure] public override string ToString() => "()";
        [Pure] public bool Equals(Unit other) => true;
        [Pure] public static bool operator ==(Unit lhs, Unit rhs) => true;
        [Pure] public static bool operator !=(Unit lhs, Unit rhs) => false;
        [Pure] public static bool operator >(Unit lhs, Unit rhs) => false;
        [Pure] public static bool operator >=(Unit lhs, Unit rhs) => true;
        [Pure] public static bool operator <(Unit lhs, Unit rhs) => false;
        [Pure] public static bool operator <=(Unit lhs, Unit rhs) => true;
        [Pure] public T Return<T>(T anything) => anything;
        [Pure] public T Return<T>(Func<T> anything) => anything();
        [Pure] public int CompareTo(Unit other) => 0;
        [Pure] public static Unit operator +(Unit a, Unit b) => Default;
    }
}