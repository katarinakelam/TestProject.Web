using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProject.BLL.BusinessModels;
using FakturaVM = TestProject.Web.ViewModels.Faktura;
using StavkaVM = TestProject.Web.ViewModels.Stavka;

namespace TestProject.Web.AutoMapper.Resolvers
{
    public class StavkeBLLToStavkeVMResolver : IValueResolver<Faktura, FakturaVM, IEnumerable<StavkaVM>>
    {
        public IEnumerable<StavkaVM> Resolve(Faktura source, FakturaVM destination, IEnumerable<StavkaVM> destMember, ResolutionContext context)
        {
            List<StavkaVM> stavke = new List<StavkaVM>();
            foreach (var item in source.Stavke)
            {
                StavkaVM stavka = new StavkaVM();
                stavka.Cijena = item.Cijena;
                stavka.Kolicina = item.Kolicina;
                stavka.Opis = item.Opis;
                stavka.UkupnaCijena = item.UkupnaCijena;

                stavke.Add(stavka);
            }
            return stavke.AsEnumerable();
        }
    }
}