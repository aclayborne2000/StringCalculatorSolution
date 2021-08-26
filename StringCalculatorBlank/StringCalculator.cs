using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorBlank
{
    public class StringCalculator
    {

        public int Add(string numbers)
        {
            return numbers == "" ? 0 : numbers.Split(',')
                .Select(int.Parse)
                .Sum();
        }
    }
}

