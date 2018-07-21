using System;

namespace FunctionalWay.Extensions
{
    public static class PartialApplicationExtensions
    {
        public static Func<T2, TR> Apply<T1, T2, TR>(this Func<T1, T2, TR> func, T1 t1) 
            => t2 => func(t1, t2);

        public static Func<T2, T3, TR> Apply<T1, T2, T3, TR>(this Func<T1, T2, T3, TR> func, T1 t1)
            => (t2, t3) => func(t1, t2, t3);
    }
}