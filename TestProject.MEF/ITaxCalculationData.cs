using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MEF
{
    public interface ITaxCalculationData
    {
        string DrzavaPDV { get; }
    }
}
