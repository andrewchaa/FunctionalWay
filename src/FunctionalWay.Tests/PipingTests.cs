using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using FunctionalWay.Extensions;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using Xunit;

namespace FunctionalWay.Tests
{
    enum Animals
    {
        Dog,
        Cat
    }
    
    public class PipingTests
    {
        [Fact]
        public void Should_pipe_for_enums()
        {
            var dog = Animals.Dog;

            Assert.Equal("Dog", Animals.Dog.Map(d => d.ToString()));
        }
       
    }
}