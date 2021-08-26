using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringCalculatorBlank
{
    public class StringCalculatorInteractionTests
    {
        private StringCalculator _calculator;
        public StringCalculatorInteractionTests()
        {
            
        }
        [Theory]
        [InlineData("","0")]
        [InlineData("1,2", "3")]
        [InlineData("1,2,3,4,5,6,7,8,9", "45")]
        public void WritesAnswerToLog(string input, string expected)
        {

            var mockedLogger = new Mock<ILogger>();
            _calculator = new StringCalculator(
                mockedLogger.Object,
                new Mock<IWebService>().Object
                ); 

            _calculator.Add(input);

            mockedLogger.Verify(m => m.Write(expected));

        }

        [Theory]
        [InlineData("blammo")]
        [InlineData("tacos")]
        [InlineData("the disk is full, yo!")]
        public void CallsWebServiceOnLoggerError(string message)
        {
            // Given
            var stubbedLogger = new Mock<ILogger>();
            var mockedWebSerive = new Mock<IWebService>();

            stubbedLogger.Setup(m => m.Write(It.IsAny<string>()))
                .Throws(new LoggerException(message));

            _calculator = new StringCalculator(
                stubbedLogger.Object,
                mockedWebSerive.Object
                );


            // When
            _calculator.Add("1,2");

            // Then
            mockedWebSerive.Verify(m => m.Report(message));


        }


    }
}
