namespace System {
    //Some Extension Errors Here
    public enum ResultError {
        None ,
        Any ,
        AsyncResultUnitError,
        AsyncResultExceptionUnexpected,
        Cancelled,
        UnhandledExceptionDoingBenignAction,
    }
}
