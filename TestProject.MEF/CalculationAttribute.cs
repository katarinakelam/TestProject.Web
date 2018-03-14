using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MEF
{
    [MetadataAttribute]
    public class CalculationAttribute : Attribute, ICalculationAttribute
    {
        public string[] Countries { get; set; }

        public CalculationAttribute(string[] countries)
        {
            int i = 0;
            Countries = new string[countries.Count()];
            foreach (var country in countries)
            {
                Countries[i] = country;
                i++;
            }
        }
    }
}
