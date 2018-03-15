using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MEF
{
    [Export(typeof(ITaxCalculator))]
    class TaxCalculator : ITaxCalculator
    {
        [ImportMany]
        IEnumerable<Lazy<ITaxCalculation, ITaxCalculationData>> operations;

        public float Calculate(int cijena, string drzava, int pdv)
        {
            foreach (Lazy<ITaxCalculation, ITaxCalculationData> i in operations)
            {
                if (i.Metadata.DrzavaPDV.Equals(drzava + "|" + pdv.ToString()))
                    return i.Value.Calculate(cijena, pdv);
            }
            return 0;
        }
    }
}
