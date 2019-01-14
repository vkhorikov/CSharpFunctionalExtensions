namespace System
{
    //Pretty stright forward but how do we implement control flow without branching
    //eg service.GetMaybe().Onfull()
    // Maybes should not become input parameters on functions which take only one parameter
    // Absolutely recommended to use maybe's instead of null on return values
    public static class Maybe
    {
        public static Maybe<T> Create<T>(T t) where T : class => Maybe<T>.Create(t);
    }
}
