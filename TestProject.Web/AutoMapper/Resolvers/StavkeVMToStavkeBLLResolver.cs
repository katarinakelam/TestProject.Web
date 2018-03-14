using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProject.BLL.BusinessModels;
using FakturaVM = TestProject.Web.ViewModels.Faktura;

namespace TestProject.Web.AutoMapper.Resolvers
{
    public class StavkeVMToStavkeBLLResolver : IValueResolver<FakturaVM, Faktura, List<Stavka>>
    {
        public List<Stavka> Resolve(FakturaVM source, Faktura destination, List<Stavka> destMember, ResolutionContext context)
        {
            List<Stavka> stavke = new List<Stavka>();
            Stavka stavka = new Stavka();
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