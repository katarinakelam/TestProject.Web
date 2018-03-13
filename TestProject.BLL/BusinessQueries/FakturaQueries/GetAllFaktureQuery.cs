using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model;
using FakturaBLL = TestProject.BLL.BusinessModels.Faktura;

namespace TestProject.BLL.BusinessQueries.FakturaQueries
{
    public class GetAllFaktureQuery : IQuery<List<FakturaBLL>>
    {
    }
}
