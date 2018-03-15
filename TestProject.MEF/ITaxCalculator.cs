using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MEF
{
    public interface ITaxCalculator
    {
        float Calculate(int cijena, string drzava, int pdv);
    }
}
