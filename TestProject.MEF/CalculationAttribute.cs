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

        public CalculationAttribute(string[] countries)
        {
            foreach(var country in countries)
            {
                Countries.Add(country);
            }
        }

        public List<string> Countries { get; set; }
    }
}
