using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpFunctionalExtensions
{
    public interface ICombine
    {
        ICombine Combine(ICombine value);
    }
}
