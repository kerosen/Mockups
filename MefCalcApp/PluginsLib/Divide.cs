using SharedContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plugins
{
    public class Divide : ICalculationService
    {
        public int Calculate(int number1, int number2)
        {
            if (number2 != 0)
            {
                return number1 / number2;
            }

            throw new DivideByZeroException();
        }

        public string MethodName
        {
            get { return "Divide"; }
        }
    }
}