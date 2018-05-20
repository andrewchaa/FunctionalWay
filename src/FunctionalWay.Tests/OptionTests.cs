using Xunit;

namespace FunctionalWay.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void MatchCallsAppropriateFunc()
        {
            Assert.Equal("hello, John", Greet(F.Some("John")));
            Assert.Equal("sorry, who?", Greet(F.None));
        }

        private string Greet(Option<string> name) 
            => name.Match(
                Some: n => $"hello, {n}",
                None: () => "sorry, who?");

    }
}