using System.Threading.Tasks;
using FunctionalWay.Eithers;
using FunctionalWay.Extensions;
using FunctionalWay.Options;
using Unit = System.ValueTuple;

namespace FunctionalWay
{
    public static partial class F
    {
        // Options
        public static Option<T> Some<T>(T value) => new Some<T>(value);
        public static None None { get; set; }

        public static Unit Unit() => default(Unit);
        public static async Task<Unit> UnitAsync() => default(Unit);
        
        // Eithers
        public static Left<L> Left<L>(L l) => new Left<L>(l);
        public static Right<R> Right<R>(R r) => new Right<R>(r);


    }
}