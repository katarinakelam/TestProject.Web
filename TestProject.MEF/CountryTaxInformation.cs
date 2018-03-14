using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MEF
{
    public class CountryTaxInformation
    {
        public string Name { get; set; }

        public int Tax { get; set; }

        public string Stringify()
        {
            return Name + "|" + Tax.ToString();
        }
    }
}
