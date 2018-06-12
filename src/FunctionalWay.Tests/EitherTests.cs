using System.IO.MemoryMappedFiles;
using FunctionalWay;
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
        
    }
}