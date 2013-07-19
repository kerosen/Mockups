using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MefCalcApp.Models
{
    public class CalculationModel
    {
        public CalculationSet CalculationSet { get; set; }

        public CalculationModel()
        {
        }

        public CalculationModel(CalculationSet calculationSet)
            : this()
        {
            this.CalculationSet = calculationSet;
        }
    }
}