using System;
using Shouldly;

namespace ExperimentsTestsWithCode {
    public class CalculatorTests {
        public void ShouldAdd() {
            Calculator.Add(2, 3).ShouldBe(5);
        }

        public void ShouldSubtract() {
            Calculator.Subtract(3, 2).ShouldBe(1);
        }

        public void ShouldMultiply() {
            Calculator.Multiply(1, 2).ShouldBe(2);
        }

        public void ShouldDivide() {
            var data = new[] {
                new {A = 1, B = 1, Expected = 1, ErrorExpected = false},
                new {A = 4, B = 2, Expected = 2, ErrorExpected = false},
                new {A = 4, B = 0, Expected = 0, ErrorExpected = true}
            };

            foreach (var item in data) {
                try {
                    Calculator.Divide(item.A, item.B).ShouldBe(item.Expected);
                    item.ErrorExpected.ShouldBeFalse();
                }
                catch (DivideByZeroException e) {
                    item.ErrorExpected.ShouldBeTrue();
                }
            }
        }
    }
}
