using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MEF
{
    [Export(typeof(ITaxCalculation))]
    [ExportMetadata("DrzavaPDV", "HR|25")]
    public class TaxCalculationCroatia : ITaxCalculation
    {
        public float Calculate(int cijena, int pdv)
        {
            return cijena * (float)pdv / 100;
        }
    }
}
