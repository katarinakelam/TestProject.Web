using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProject.Web.AutoMapper.Resolvers;
using TestProject.BLL.BusinessModels;
using FakturaVM = TestProject.Web.ViewModels.Faktura;

namespace TestProject.Web.AutoMapper.Profiles.VMToBLL
{
    public class FakturaVMToFakturaBLLProfile : Profile
    {
        public FakturaVMToFakturaBLLProfile()
        {
            CreateMap<FakturaVM, Faktura>()
                .ForMember(dest => dest.DatumIzdavanja,
                    opt => opt.MapFrom(src => src.DatumIzdavanja))
                .ForMember(dest => dest.DatumDospijeca,
                    opt => opt.MapFrom(src => src.DatumDospijeca))
                .ForMember(dest => dest.PDV,
                    opt => opt.MapFrom(src => src.PDV))
                .ForMember(dest => dest.Cijena,
                    opt => opt.MapFrom(src => src.Cijena))
                .ForMember(dest => dest.CijenaSPDVom,
                    opt => opt.ResolveUsing<CijenaSPDVomVMToBLLResolver>())
                .ForMember(dest => dest.StvarateljRacuna,
                    opt => opt.MapFrom(src => src.StvarateljRacuna))
                .ForMember(dest => dest.Primatelj,
                    opt => opt.MapFrom(src => src.Primatelj))
                .ForMember(dest => dest.Stavke,
                    opt => opt.ResolveUsing<StavkeVMToStavkeBLLResolver>());

        }
    }
}