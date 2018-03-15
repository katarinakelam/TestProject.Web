using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MEF
{
    public interface ITaxCalculation
    {
        float Calculate(int cijena, int pdv);
    }
}
