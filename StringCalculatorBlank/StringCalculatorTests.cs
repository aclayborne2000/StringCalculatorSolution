using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringCalculatorBlank
{
    public class StringCalculatorTests
    {
        private readonly StringCalculator _calculator;

        public StringCalculatorTests()
        {
            _calculator = new();
        }

        [Fact]
        public void EmptyStringReturnsZero()
        {
            var answer = _calculator.Add("");

            Assert.Equal(0, answer);
        } 

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("42", 42)]
        public void SingleDigit(string numbers, int expected)
        {
            var answer = _calculator.Add(numbers);
            Assert.Equal(expected, answer);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("4,5", 9)]
        [InlineData("10,2", 12)]
        [InlineData("20,30", 50)]
        [InlineData("108,200", 308)]
        public void TwoDigits(string numbers, int expected)
        {
            var answer = _calculator.Add(numbers);
            Assert.Equal(expected, answer);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("1,2,3,4,5,6,7,8,9", 45)]
        public void Arbitrary(string numbers, int expected)
        {
            var answer = _calculator.Add(numbers);
            Assert.Equal(expected, answer);
        }
    }
}
