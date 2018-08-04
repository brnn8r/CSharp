using System;

namespace NullGuardTest
{
    public static class Mapper
    {
        public static U Map<T, U>(this T t, Func<T, U> mapper)
        {
            return mapper(t);
        }
    }
}
