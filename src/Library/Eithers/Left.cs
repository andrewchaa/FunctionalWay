using System.Collections.Generic;

namespace FunctionalWay.Eithers
{
    public struct Left<L>
    {
        internal L Value { get; }
        internal Left(L value) { Value = value; }

        public override string ToString() => $"Left({Value})";
    }
  
}