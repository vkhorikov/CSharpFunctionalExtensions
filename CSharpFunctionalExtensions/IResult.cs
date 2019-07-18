﻿namespace CSharpFunctionalExtensions
{
    public interface IResult
    {
        bool IsFailure { get; }
        bool IsSuccess { get; }
    }
}
