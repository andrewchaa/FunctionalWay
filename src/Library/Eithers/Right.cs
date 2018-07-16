using System;
using System.Collections.Generic;

namespace FunctionalWay.Eithers
{
    public struct Right<R>
    {
        internal R Value { get; }
        internal Right(R value) { Value = value; }

        public override string ToString() => $"Right({Value})";

        public Right<RR> Map<L, RR>(Func<R, RR> f) => F.Right(f(Value));
        public Either<L, RR> Bind<L, RR>(Func<R, Either<L, RR>> f) => f(Value);

    }
}