using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.MEF;

namespace TestProject.BLL.BusinessServices
{
    public class TaxCalculationService
    {
        public float CalculateTaxes (int cijena, string drzava, int pdv)
        {
            var returnVariable = TaxCalculatorImplementation.DoCalculations(cijena, drzava, pdv);
            return returnVariable;
        }
    }
}
