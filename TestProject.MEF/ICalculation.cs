using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MEF
{
    public interface ICalculation
    {
        int Price { get; set; }
        float Calculate(int tax);
    }
}
