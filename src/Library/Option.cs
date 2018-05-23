using System;
using System.Collections.Generic;
using Unit = System.ValueTuple;

namespace FunctionalWay
{
    public static class F
    {
        public static Option<T> Some<T>(T value)
        {
            return new Some<T>(value);
        }

        public static None None { get; set; }
    }

    public class Some<T>
    {
        public T Value { get; }
        public Some(T value)
        {
            Value = value;
        }
    }

    public class None
    {
    }

    public class Option<T> : IEquatable<Option<T>>
    {

        private readonly T _value;
        private readonly bool _isSome;
        private bool IsNone => !_isSome;

        private Option(T value)
        {
            _value = value;
            _isSome = true;
        }

        public Option()
        {
            _isSome = false;
        }
        
        public T Match(Func<T> None, Func<T, T> Some)
        {
            return _isSome ? Some(_value) : None();
        }
        
        public static implicit operator Option<T>(Some<T> some) => new Option<T>(some.Value); 
        public static implicit operator Option<T>(None _) => new Option<T>();
        
        public bool Equals(Option<T> other)
        {
            return _isSome == other._isSome &&
                   (IsNone || _value.Equals(other._value));
        }

        public bool Equals(None none) => IsNone;
        
        public override bool Equals(object obj)
        {
            return Equals((Option<T>) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T>.Default.GetHashCode(_value) * 397) ^ _isSome.GetHashCode();
            }
        }
        

        public static bool operator ==(Option<T> @this, Option<T> other) => @this.Equals(other);
        public static bool operator !=(Option<T> @this, Option<T> other) => !@this.Equals(other);

        public override string ToString() => _isSome ? $"Some({_value})" : "None";
    }


}