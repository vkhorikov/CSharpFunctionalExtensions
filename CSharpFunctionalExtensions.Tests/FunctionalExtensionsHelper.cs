using System;
using System.Linq;
using Microsoft.VisualBasic;

namespace CSharpFunctionalExtensions.Tests;

public static class FunctionalExtensionsHelper
{
    public static int Plus2(int value) => value + 2;

    public static int Mul5(int value) => value * 5;

    public static string IntToString(int value) => value.ToString();

    public static string SkipTake(string value) => new string(value.Skip(1).ToArray()) ?? "";
}