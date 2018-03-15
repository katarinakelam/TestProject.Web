using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using TestProject.BLL.BusinessModels;
using FakturaVM = TestProject.Web.ViewModels.Faktura;

namespace TestProject.Web.AutoMapper.Resolvers
{
    public class CijenaSPDVomVMToBLLResolver : IValueResolver<FakturaVM, Faktura, float>
    {
        public float Resolve(FakturaVM source, Faktura destination, float destMember, ResolutionContext context)
        {
            var number = float.Parse(source.CijenaSPDVom, CultureInfo.InvariantCulture);
            return number;
        }
    }
}