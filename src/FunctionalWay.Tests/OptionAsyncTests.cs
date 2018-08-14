using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FunctionalWay.Options;
using Xunit;

namespace FunctionalWay.Tests
{
    public class OptionAsyncTests
    {
        private async Task<string> Greet(Option<string> name) 
            => name.Match(
                Some: n => $"hello, {n}",
                None: () => "sorry, who?");

        private async Task<Option<string>> GetName(bool real)
            => real
                ? F.Some("Name")
                : F.None;

        private async Task PrintName(string name)
            => Console.WriteLine(name);
        
        private async Task<string> GetNameAsync() 
            => "My name is Trinity";

        [Fact]
        public async Task Match_should_call_appropriate_func()
        {
            Assert.Equal("hello, John", await Greet(F.Some("John")));
            Assert.Equal("sorry, who?", await Greet(F.None));
        }

        [Fact]
        public async Task Match_should_handle_action()
        {
            var result = await GetName(false);
            await result.Match(
                None: async () => Console.Write("Nothing"),
                Some: async name => await PrintName(name)
            );
            
            Assert.Equal(F.None, await GetName(false));
        }

        [Fact]
        public async Task Match_should_handle_func_async()
        {
            var result = await GetName(false);
            await result.Match(
                None: async () => Console.Write("Nothing"),
                Some: async name => await PrintName(name)
            );
            
            Assert.Equal(F.None, await GetName(false));
        }

        [Fact]
        public void Should_compare_cointained_value()
        {
            Assert.Equal(F.Some(20), F.Some(20));
        }

        [Fact]
        public void Should_convert_inner_value()
        {
            var optionString = F.Some("true");
            var optionBool = optionString.Map(bool.Parse);
            
            Assert.Equal(F.Some(true), optionBool);
        }

    }

    
}