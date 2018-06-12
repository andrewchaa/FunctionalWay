using System;

namespace FunctionalWay.Eithers
{
    public static class EitherExtensions
    {
        public static Either<LL, RR> Map<L, LL, R, RR>
            (this Either<L, R> @this, Func<L, LL> left, Func<R, RR> right)
            => @this.Match<Either<LL, RR>>(
                l => F.Left(left(l)),
                r => F.Right(right(r)));
        
        public static Either<L, RR> Bind<L, R, RR>
            (this Either<L, R> @this, Func<R, Either<L, RR>> f)
            => @this.Match(
                l => F.Left(l),
                r => f(r));

    }
}