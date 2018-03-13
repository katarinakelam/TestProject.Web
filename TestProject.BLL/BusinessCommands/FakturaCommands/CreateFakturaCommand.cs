using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.BLL.BusinessModels;

namespace TestProject.BLL.BusinessCommands.FakturaCommands
{
    public class CreateFakturaCommand : ICommand
    {
        public Faktura Faktura { get; set; }
    }
}
