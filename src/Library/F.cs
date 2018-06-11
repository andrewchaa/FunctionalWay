using System.Threading.Tasks;
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

        public static Unit Unit() => default(Unit);
        public static async Task<Unit> UnitAsync() => default(Unit);

//        public static Either<TL, TR> Right<TR>(TR right)
//        {
//            return new Either<TL, TR>(right);
//        }
    }
}