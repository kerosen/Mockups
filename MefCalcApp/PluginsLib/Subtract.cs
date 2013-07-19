using SharedContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plugins
{
    public class Subtract : ICalculationService
    {
        public int Calculate(int number1, int number2)
        {
            return number1 - number2;
        }

        public string MethodName
        {
            get { return "Subtract"; }
        }
    }
}