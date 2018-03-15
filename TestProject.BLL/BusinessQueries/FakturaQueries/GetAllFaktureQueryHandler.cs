using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.BLL.AutoMapper.Profiles.ModelToBLL;
using TestProject.DLL;
using FakturaBLL = TestProject.BLL.BusinessModels.Faktura;
using TestProject.Model;

namespace TestProject.BLL.BusinessQueries.FakturaQueries
{
    public class GetAllFaktureQueryHandler : IQueryHandler<GetAllFaktureQuery, List<FakturaBLL>>
    {
        private UnitOfWork _unitOfWork;

        public GetAllFaktureQueryHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<FakturaBLL> Handle(GetAllFaktureQuery query)
        {
            List<Faktura> fakture = _unitOfWork.FakturaRepository.Get()
               .Select(f => new Faktura
               {
                   DatumIzdavanja = f.DatumIzdavanja,
                   DatumDospijeca = f.DatumDospijeca,
                   Cijena = f.Cijena,
                   CijenaSPDVom = f.CijenaSPDVom,
                   PDV = f.PDV,
                   Korisnik = f.Korisnik,
                   Primatelj = f.Primatelj,
                   Stavke = f.Stavke.Select(s => new Stavka
                   {
                       Opis = s.Opis,
                       Cijena = s.Cijena,
                       Kolicina = s.Kolicina,
                       UkupnaCijena = s.UkupnaCijena
                   }).OrderBy(s => s.Opis).ToList()
               }).ToList();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FakturaModelToBLLProfile>();
            });
            var mapper = new Mapper(config);
            List<FakturaBLL> returnList = mapper.DefaultContext.Mapper.Map<List<FakturaBLL>>(fakture);

            return returnList;
        }
    }
}
