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
    public class StavkeBLLToStavkeVMResolver : IValueResolver<Faktura, FakturaVM, List<StavkaVM>>
    {
        public List<StavkaVM> Resolve(Faktura source, FakturaVM destination, List<StavkaVM> destMember, ResolutionContext context)
        {
            List<StavkaVM> stavke = new List<StavkaVM>();
            StavkaVM stavka = new StavkaVM();
            foreach (var item in source.Stavke)
            {
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