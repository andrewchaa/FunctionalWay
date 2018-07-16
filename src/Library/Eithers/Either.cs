using System;

namespace FunctionalWay.Eithers
{
    
    public class Either<L, R>
    {
        private bool _isLeft;
        private L _leftValue;
        private R _rightValue;

        private Either(L leftValue)
        {
            _isLeft = true;
            _leftValue = leftValue;
            _rightValue = default(R);
        }

        private Either(R rightValue)
        {
            _isLeft = false;
            _leftValue = default(L);
            _rightValue = rightValue;
        }

        public RT Match<RT>(Func<L, RT> Left, Func<R, RT> Right)
        {
            return _isLeft
                ? Left(_leftValue)
                : Right(_rightValue);
        }
        
        public static implicit operator Either<L, R>(L left) => new Either<L, R>(left);
        public static implicit operator Either<L, R>(R right) => new Either<L, R>(right);
        public static implicit operator Either<L, R>(Left<L> left) => new Either<L, R>(left.Value);
        public static implicit operator Either<L, R>(Right<R> right) => new Either<L, R>(right.Value);
        
        public override string ToString() => Match(l => $"Left({l})", r => $"Right({r})");
    }
    
    
}