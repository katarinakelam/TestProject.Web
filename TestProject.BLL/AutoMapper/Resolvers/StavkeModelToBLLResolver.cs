using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model;
using FakturaBLL = TestProject.BLL.BusinessModels.Faktura;
using StavkaBLL = TestProject.BLL.BusinessModels.Stavka;

namespace TestProject.BLL.AutoMapper.Resolvers
{
    public class StavkeModelToBLLResolver : IValueResolver<Faktura, FakturaBLL, List<StavkaBLL>>
    {
        public List<StavkaBLL> Resolve(Faktura source, FakturaBLL destination, List<StavkaBLL> destMember, ResolutionContext context)
        {
            List<StavkaBLL> stavke = new List<StavkaBLL>();
            foreach (var item in source.Stavke)
            {
                StavkaBLL stavka = new StavkaBLL();
                stavka.Cijena = item.Cijena;
                stavka.Kolicina = item.Kolicina;
                stavka.Opis = item.Opis;
                stavka.UkupnaCijena = item.UkupnaCijena;

                stavke.Add(stavka);
            }
            return stavke;
        }
    }
}
