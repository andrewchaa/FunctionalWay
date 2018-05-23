using System;
using System.Collections.Generic;
using Xunit;

namespace FunctionalWay.Tests
{
    public class UnitTest1
    {
        private string Greet(Option<string> name) 
            => name.Match(
                Some: n => $"hello, {n}",
                None: () => "sorry, who?");

        [Fact]
        public void Match_should_call_appropriate_func()
        {
            Assert.Equal("hello, John", Greet(F.Some("John")));
            Assert.Equal("sorry, who?", Greet(F.None));
        }

        [Fact]
        public void Should_compare_cointained_value()
        {
            Assert.Equal(F.Some(20), F.Some(20));
        }


    }

    
}