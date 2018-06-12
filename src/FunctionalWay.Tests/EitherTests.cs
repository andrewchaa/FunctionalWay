using FunctionalWay.Eithers;
using Xunit;


namespace FunctionalWay.Tests
{
    public class EitherTests
    {
        string Render(Either<string, double> value) =>
            value.Match(
                Left: l => $"Invalid value: {l}",
                Right: r => $"The result is: {r.ToString()}");

        Either<string, double> Calc(double x, double y)
        {
            if (y == 0) return "y cannot be 0";

            return x / y;
        }

        [Fact]
        public void Should_handle_left_correctly()
        {
            Assert.Equal("Invalid value: left", Render(F.Left("left")));
        }

        [Fact]
        public void Should_handle_right_correctly()
        {
            Assert.Equal("The result is: 12", Render(F.Right(12d)));
        }

        [Fact]
        public void Should_handle_either_correctly()
        {
            Assert.Equal("y cannot be 0", Calc(1, 0).Match(
                Left: msg => msg,
                Right: result => result.ToString()));
        }
        
    }
}