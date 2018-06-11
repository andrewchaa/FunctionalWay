using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FunctionalWay.Extensions;
using Unit = System.ValueTuple;

namespace FunctionalWay
{
    public class Some<T>
    {
        public T Value { get; }
        public Some(T value)
        {
            Value = value;
        }
    }

    public class None {}

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
        
        public R Match<R>(Func<R> None, Func<T, R> Some)
        {
            return _isSome ? Some(_value) : None();
        }

//        public async Task<R> MatchAsync<R>(Func<Task<R>> None, Func<T, Task<R>> Some)
//        {
//            return _isSome ? await Some(_value) : await None();
//        }

        public Unit Match(Action None, Action<T> Some) 
            => Match(None.ToFunc(), Some.ToFunc());
        
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