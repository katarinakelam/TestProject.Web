using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model;
using FakturaBLL = TestProject.BLL.BusinessModels.Faktura;

namespace TestProject.BLL.AutoMapper.Resolvers
{
    public class StavkeBLLToModelResolver : IValueResolver<FakturaBLL, Faktura, List<Stavka>>
    {
        public List<Model.Stavka> Resolve(FakturaBLL source, Model.Faktura destination, List<Model.Stavka> destMember, ResolutionContext context)
        {
            List<Stavka> stavke = new List<Stavka>();
            Stavka stavka = new Stavka();
            foreach (var item in source.Stavke)
            {
                stavka.Cijena = item.Cijena;
                stavka.Kolicina = item.Kolicina;
                stavka.Opis = item.Opis;
                stavka.UkupnaCijenaSPDVom = item.UkupnaCijenaSPDVom;

                stavke.Add(stavka);
            }
            return stavke;
        }
    }
}
