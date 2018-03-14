using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MEF
{
    public class CalculationImplementation
    {
        public List<float> DoCalculations(int price, string countryName, int countryTax)
        {

            //Loading the assembly
            var asm = Assembly.LoadFrom("AllCalculations.dll");
            //Create the catalog
            var catalog = new AssemblyCatalog(asm);
            //Create the composition container
            var container = new CompositionContainer(catalog);

            //Create an instance of CalculationSelection class
            CountryTaxInformation country = new CountryTaxInformation();
            country.Name = countryName;
            country.Tax = countryTax;

            var myCalculations1 = new CalculationSelection(price, country);

            //Perform all the tax calculations
            List<float> returnVariables = new List<float>();
            returnVariables = PeformCalculations(container, myCalculations1);
            return returnVariables;
        }

        public List<float> PeformCalculations(CompositionContainer container, CalculationSelection currentCalculation)
        {
            //Compose the parts, match the imports with exports
            container.ComposeParts(currentCalculation);
            List<float> returnVariables = new List<float>();
            //loop through all available calculations inside the assembly
            foreach (var item in currentCalculation.AllCalculations)
            {
                //retrieve the list of applicable countries from the metadata
                var applicableCountries = item.Metadata.Countries;
                //Check whether the current tax calculation is applicable in the selected country
                var cmp = applicableCountries.Contains(currentCalculation.Country.Stringify());
                float returnVariable = 0;
                if (cmp)
                {
                    //get the the value for lazy initialization
                    ICalculation calc = item.Value as ICalculation;
                    //provide the input salary
                    calc.Price = currentCalculation.Price;
                    //perform the calculation
                    returnVariable = calc.Calculate(currentCalculation.Country.Tax);
                    returnVariables.Add(returnVariable);
                }
            }
            return returnVariables;
        }
    }
}
