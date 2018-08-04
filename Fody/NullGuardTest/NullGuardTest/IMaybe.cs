using System;
using System.Collections.Generic;

namespace NullGuardTest
{
    public interface IMaybe<T>
    {       
        T Value { get; }

        bool HasValue { get; }

        U Match<U>(Func<T, U> some, Func<U> none);

        IMaybe<U> Map<U>(Func<T, U> mapper);
    }
}
