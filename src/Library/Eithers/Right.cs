using System.Collections.Generic;

namespace FunctionalWay.Eithers
{
    public struct Right<R>
    {
        internal R Value { get; }
        internal Right(R value) { Value = value; }

        public override string ToString() => $"Right({Value})";
    }

//    public struct Right<T>
//    {
//        public T Value { get; }
//        
//        public Right(T value)
//        {
//            Value = value;
//        }
//
//        public bool Equals(Right<T> other)
//        {
//            return EqualityComparer<T>.Default.Equals(Value, other.Value);
//        }
//
//        public override bool Equals(object obj)
//        {
//            if (ReferenceEquals(null, obj)) return false;
//            return obj is Right<T> && Equals((Right<T>) obj);
//        }
//
//        public override int GetHashCode()
//        {
//            return EqualityComparer<T>.Default.GetHashCode(Value);
//        }
//    }
}