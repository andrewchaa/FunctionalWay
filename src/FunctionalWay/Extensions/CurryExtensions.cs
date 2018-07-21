using System;

namespace FunctionalWay.Extensions
{
    public static class CurryExtensions
    {
        public static Func<T1, Func<T2, TR>> Curry<T1, T2, TR>(this Func<T1, T2, TR> func) 
            => t1 => t2 => func(t1, t2);

        public static Func<T1, Func<T2, Func<T3, TR>>> Curry<T1, T2, T3, TR>(this Func<T1, T2, T3, TR> func) =>
            t1 => t2 => t3 => func(t1, t2, t3);
    }
}