using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MEF
{
    public class CalculationSelection
    {
        //Constructor
        public CalculationSelection(int price, CountryTaxInformation country)
        {
            Price = price;
            Country = new CountryTaxInformation();
            Country.Name = country.Name;
            Country.Tax = country.Tax;
        }

        public int Price { get; set; }
        public CountryTaxInformation Country { get; set; }

        //ImportMany of type ICalculation
        [ImportMany]
        public IEnumerable<Lazy<ICalculation, ICalculationAttribute>> AllCalculations;

    }
}
