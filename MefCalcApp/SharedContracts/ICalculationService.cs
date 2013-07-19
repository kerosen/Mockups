using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedContracts
{
    [InheritedExport(typeof(ICalculationService))]
    public interface ICalculationService
    {
        int Calculate(int number1, int number2);

        string MethodName { get; }
    }
}
