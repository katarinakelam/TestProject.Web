using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
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
            var dllFile = new FileInfo(@"C:\Users\Katarina\Documents\Visual Studio 2015\Projects\TestProject.Web\TestProject.MEF\Extensions\TestProject.MEF.dll");
            var asm = Assembly.LoadFrom(dllFile.FullName);
            //Create the catalog
            var catalog = new AssemblyCatalog(asm);
            //Create the composition container
            CompositionContainer container = new CompositionContainer(catalog);

            //Create an instance of CalculationSelection class
            CountryTaxInformation country = new CountryTaxInformation();
            country.Name = countryName;
            country.Tax = countryTax;

            CalculationSelection myCalculations = new CalculationSelection(price, country);

            //Perform all the tax calculations
            List<float> returnVariables = new List<float>();
            returnVariables = PeformCalculations(container, myCalculations);
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
                string[] applicableCountries = item.Metadata.Countries;
                //Check whether the current tax calculation is applicable in the selected country
                bool cmp = applicableCountries.Contains(currentCalculation.Country.Stringify());
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
