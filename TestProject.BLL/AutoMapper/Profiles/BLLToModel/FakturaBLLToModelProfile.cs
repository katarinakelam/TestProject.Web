using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.BLL.AutoMapper.Resolvers;
using TestProject.Model;
using FakturaBLL = TestProject.BLL.BusinessModels.Faktura;

namespace TestProject.BLL.AutoMapper.Profiles.BLLToModel
{
    public class FakturaBLLToModelProfile : Profile
    {
        public FakturaBLLToModelProfile()
        {
            CreateMap<FakturaBLL, Faktura>()
                .ForMember(dest => dest.DatumIzdavanja,
                    opt => opt.MapFrom(src => src.DatumIzdavanja))
                .ForMember(dest => dest.DatumDospijeca,
                    opt => opt.MapFrom(src => src.DatumDospijeca))
                .ForMember(dest => dest.PDV,
                    opt => opt.MapFrom(src => src.PDV))
                .ForMember(dest => dest.Cijena,
                    opt => opt.MapFrom(src => src.Cijena))
                .ForMember(dest => dest.CijenaSPDVom,
                    opt => opt.MapFrom(src => src.CijenaSPDVom))
                .ForMember(dest => dest.Korisnik,
                    opt => opt.MapFrom(src => src.StvarateljRacuna))
                .ForMember(dest => dest.Primatelj,
                    opt => opt.MapFrom(src => src.Primatelj))
                .ForMember(dest => dest.Stavke,
                    opt => opt.ResolveUsing<StavkeBLLToModelResolver>());
        }
    }
}
