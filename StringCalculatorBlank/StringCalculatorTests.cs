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

        [Fact]
        public void EmptyStringReturnsZero()
        {
            var calculator = new StringCalculator();

            var answer = calculator.Add("");

            Assert.Equal(0, answer);
        } 
    }
}
