namespace CSharpFunctionalExtensions
{
    using System.Collections.Generic;

    public sealed class ErrorList : List<Error>, ICombine
    {
        public ErrorList() { }
        public ErrorList(IEnumerable<Error> errors) : base(errors) { }

        public bool HasErrors => Count > 0;

        public void Add(ErrorList ec) => AddRange(ec);


        ICombine ICombine.Combine(ICombine value)
        {
            var errorList = new ErrorList((ErrorList)value);
            errorList.AddRange(this);
            return new ErrorList(errorList);
        }

        public static implicit operator ErrorList(Error e) => new(new List<Error>() { e });
    }
}
