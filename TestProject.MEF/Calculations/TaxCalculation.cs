using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MEF.Calculations
{
    [Export(typeof(ICalculation))]
    [CalculationAttribute(new string[] {"HR|25", "BiH|25" })]
    public class TaxCalculation : ICalculation
    {
        public int Price
        {
            get;
            set;
        }

        public float Calculate(int tax)
        {
            return Price * (float)tax/100;
        }
    }
}
