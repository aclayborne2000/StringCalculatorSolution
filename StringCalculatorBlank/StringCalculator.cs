using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorBlank
{
    public class StringCalculator
    {
        private readonly ILogger _logger;
        private readonly IWebService _webService;

        public StringCalculator(ILogger logger, IWebService webService)
        {
            _logger = logger;
            _webService = webService;
        }

        public int Add(string numbers)
        {
            
            var message =  numbers == "" ? 0 : numbers.Split(',')
                .Select(int.Parse)
                .Sum();

            try
            {
                _logger.Write(message.ToString());
            }
            catch (LoggerException ex)
            {
                _webService.Report(ex.Message);
            }
           
            return message;
        }
    }
}

