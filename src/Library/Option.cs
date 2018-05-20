using System;
using System.Collections.Generic;
using Unit = System.ValueTuple;

namespace FunctionalWay
{
    public static partial class F
    {
        public static Option<T> Some<T>(T value) => new Option.Some<T>(value); // wrap the given value into a Some
        public static Option.None None => Option.None.Default;  // the None value
    }

    public struct Option<T> : IEquatable<Option.None>, IEquatable<Option<T>>
    {
        readonly T _value;
        readonly bool _isSome;
        bool IsNone => !_isSome;

        private Option(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            _isSome = true;
            _value = value;
        }

        public static implicit operator Option<T>(Option.None _) => new Option<T>();
        public static implicit operator Option<T>(Option.Some<T> some) => new Option<T>(some.Value);

        public static implicit operator Option<T>(T value)
            => value == null ? F.None : F.Some(value);

        public R Match<R>(Func<R> None, Func<T, R> Some)
            => _isSome ? Some(_value) : None();

        public IEnumerable<T> AsEnumerable()
        {
            if (_isSome) yield return _value;
        }

        public bool Equals(Option<T> other) 
            => this._isSome == other._isSome 
               && (this.IsNone || this._value.Equals(other._value));

        public bool Equals(Option.None _) => IsNone;

        public static bool operator ==(Option<T> @this, Option<T> other) => @this.Equals(other);
        public static bool operator !=(Option<T> @this, Option<T> other) => !(@this == other);

        public override string ToString() => _isSome ? $"Some({_value})" : "None";
    }

    namespace Option
    {
        public struct None
        {
            internal static readonly None Default = new None();
        }

        public struct Some<T>
        {
            internal T Value { get; }

            internal Some(T value)
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value)
                        , "Cannot wrap a null value in a 'Some'; use 'None' instead");
                Value = value;
            }
        }
    }
    
}