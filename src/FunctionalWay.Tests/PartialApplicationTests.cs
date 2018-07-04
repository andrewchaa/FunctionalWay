using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using FunctionalWay.Extensions;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using Xunit;

namespace FunctionalWay.Tests
{
    public class PartialApplicationTests
    {
        
        private readonly Func<int, int, int> Sum2 = (i, j) => i + j;
        private readonly Func<int, int, int, int> Sum3 = (i, j, k) => i + j + k;
        
        [Fact]
        public void Should_convert_2_parameter_function_to_1_argument_function()
        {
            var sum = Sum2(1, 2);
            
            Assert.Equal(3, sum);
            Assert.Equal(3, Sum2.Apply(1)(2));
            Assert.Equal(3, Sum2.Apply(1)
                .Pipe(s => s(2))
            );
        }

        [Fact]
        public void Should_convert_3_parameter_function_to_2_parameter_function()
        {
            var sum = Sum3(1, 2, 3);
            
            Assert.Equal(sum, Sum3.Apply(1)(2,3));
            Assert.Equal(sum, Sum3.Apply(1)
                .Pipe(s => s(2, 3))
            );
        }
       
    }
}