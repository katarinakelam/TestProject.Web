using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MEF
{
    //public interface ICalculatorr //tax calculator
    //{
    //    float Calculate(int cijena, string drzava, int pdv);
    //}

    //public interface ICalculation //tax calculation
    //{
    //    float Calculate(int cijena, int pdv);
    //}

    //public interface ICalculationData
    //{
    //    string DrzavaPDV { get; }
    //}

    //[Export(typeof(ICalculation))]
    //[ExportMetadata("DrzavaPDV", "HR|25")]
    //class TaxCalculationCroatia : ICalculation
    //{
    //    public float Calculate(int cijena, int pdv)
    //    {
    //        return cijena * (float)pdv / 100;
    //    }
    //}

    //[Export(typeof(ICalculation))]
    //[ExportMetadata("DrzavaPDV", "BiH|17")]
    //class TaxCalculationBiH : ICalculation
    //{
    //    public float Calculate(int cijena, int pdv)
    //    {
    //        return cijena * (float)pdv / 10;
    //    }
    //}

    //[Export(typeof(ICalculatorr))]
    //class MySimpleCalculator : ICalculatorr
    //{
    //    [ImportMany]
    //    IEnumerable<Lazy<ICalculation, ICalculationData>> operations;

    //    public float Calculate(int cijena, string drzava, int pdv)
    //    {
    //        foreach (Lazy<ICalculation, ICalculationData> i in operations)
    //        {
    //            if (i.Metadata.DrzavaPDV.Equals(drzava + "|" + pdv.ToString()))
    //                return i.Value.Calculate(cijena, pdv);
    //        }
    //        return 0;
    //    }
    //}

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
            catalog.Catalogs.Add(new DirectoryCatalog("C:\\Users\\Katarina\\Desktop\\Extensions"));

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