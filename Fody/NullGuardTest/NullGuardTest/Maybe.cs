using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NullGuardTest
{
    public struct Maybe<T> : IMaybe<T>
    {
        private static readonly Lazy<Maybe<T>> NONE = new Lazy<Maybe<T>>(
                () => new Maybe<T>(new T[] { })
            );

        public static Maybe<T> None = NONE.Value;

        private readonly IEnumerable<T> t;

        public T Value => t.Single();

        public bool HasValue => t.Any();

        public static Maybe<T> Some(T t)
        {
            return new Maybe<T>(new [] { t });
        }

        private Maybe(IEnumerable<T> ts)
        {
            t = ts;
        }

        public U Match<U>(Func<T, U> some, Func<U> none)
        {
            return HasValue ? some(Value) : none();
        }


        public override string ToString()
        {
            if (!HasValue) return string.Empty;

            return Value.ToString();
        }

        public IMaybe<U> Map<U>(Func<T, U> mapper)
        {
            return HasValue ? Maybe<U>.Some(Value.Map(mapper)) : Maybe<U>.None;
        }
    }
}
