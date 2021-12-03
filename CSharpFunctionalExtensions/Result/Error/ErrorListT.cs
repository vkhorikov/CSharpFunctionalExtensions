namespace CSharpFunctionalExtensions
{
    using System.Collections.Generic;

    public sealed class ErrorList<T> : List<T>, ICombine
    {
        public ErrorList() { }
        public ErrorList(IEnumerable<T> errors) : base(errors) { }

        public bool HasErrors => Count > 0;

        public void Add(ErrorList<T> ec) => AddRange(ec);


        ICombine ICombine.Combine(ICombine value)
        {
            var errorList = new ErrorList<T>(this);
            errorList.AddRange((ErrorList<T>)value);
            return new ErrorList<T>(errorList);
        }

        public static implicit operator ErrorList<T>(T e) => new(new List<T>() { e });
    }
}
