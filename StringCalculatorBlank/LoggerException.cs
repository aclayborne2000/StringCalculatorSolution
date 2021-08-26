using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorBlank
{
    public class LoggerException : SystemException
    {
        public LoggerException(string message): base(message)
        {
          
        }
    }
}
