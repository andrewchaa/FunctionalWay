using System.Collections.Generic;

namespace FunctionalWay.Eithers
{
    public struct Left<L>
    {
        internal L Value { get; }
        internal Left(L value) { Value = value; }

        public override string ToString() => $"Left({Value})";
    }

    
//    public struct Left<T>
//    {
//        public T Value { get; }
//
//        public Left(T value)
//        {
//            Value = value;
//        }
//
//        public bool Equals(Left<T> other)
//        {
//            return EqualityComparer<T>.Default.Equals(Value, other.Value);
//        }
//
//        public override bool Equals(object obj)
//        {
//            if (ReferenceEquals(null, obj)) return false;
//            return obj is Left<T> && Equals((Left<T>) obj);
//        }
//
//        public override int GetHashCode()
//        {
//            return EqualityComparer<T>.Default.GetHashCode(Value);
//        }
//    }
}