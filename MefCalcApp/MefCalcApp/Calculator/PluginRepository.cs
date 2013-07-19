using SharedContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MefCalcApp.Calculator
{
    public class PluginRepository
    {
        public IEnumerable<ICalculationService> CalculationServices { get; set; }
    }
}