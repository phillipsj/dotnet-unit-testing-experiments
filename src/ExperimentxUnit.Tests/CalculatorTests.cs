using System;
using Experiments;
using Xunit;

namespace ExperimentxUnit.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 3, 5)]
        public void ShouldAdd(int a, int b, int expected) {
            var actual = Calculator.Add(a, b);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldAddMultiple() {
            var data = new[] {
                new {A = 1, B = 2, Expected = 3},
                new {A = 2, B = 3, Expected = 5}
            };

            foreach (var item in data) {
                var actual = Calculator.Add(item.A, item.B);
                Assert.Equal(item.Expected, actual);
            }
        }
        
        [Fact]
        public void ShouldDivide() {
            var data = new[] {
                new {A = 1, B = 1, Expected = 1, ErrorExpected = false },
                new {A = 4, B = 2, Expected = 2, ErrorExpected = false },
                new {A = 4, B = 0, Expected = 0, ErrorExpected = true }
            };
            
            foreach (var item in data) {
                try {
                    var actual = Calculator.Divide(item.A, item.B);
                    Assert.Equal(item.Expected, actual);
                    Assert.False(item.ErrorExpected);
                }
                catch (DivideByZeroException e) {
                    Assert.True(item.ErrorExpected);
                }
               
            }
        }
    }
}
