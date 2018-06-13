using System;
using FunctionalWay.Extensions;
using Xunit;

namespace FunctionalWay.Tests
{
    public class MapTests
    {
        private Func<(string, string), string> GetFullname =
            ((string firstName, string lastName) input) => input.firstName + " " + input.lastName;

        [Fact]
        public void Should_bind_value_tuple()
        {
            var fullname = ("Young ho", "Chaa").Map(i => GetFullname(i));
            
            Assert.Equal("Young ho Chaa", fullname);
        }
    }
}