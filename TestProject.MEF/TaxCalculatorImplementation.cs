using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MEF
{
    public class TaxCalculatorImplementation
    {
        private CompositionContainer _container;

        [Import(typeof(ITaxCalculator))]
        ITaxCalculator calculator;

        public TaxCalculatorImplementation()
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();

            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(TaxCalculatorImplementation).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog("..\\TestProject.MEF\\Extensions"));

            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

        public static float DoCalculations(int cijena, string drzava, int pdv)
        {
            TaxCalculatorImplementation p = new TaxCalculatorImplementation(); //Composition is performed in the constructor
            return p.calculator.Calculate(cijena, drzava, pdv);
        }
    }
}