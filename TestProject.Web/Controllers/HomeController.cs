using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.BLL.BusinessServices;
using TestProject.Web.AutoMapper.Profiles.BLLToVM;
using TestProject.Web.AutoMapper.Profiles.VMToBLL;
using TestProject.Web.ViewModels;
using FakturaBLL = TestProject.BLL.BusinessModels.Faktura;

namespace TestProject.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateFaktura()
        {
            Faktura faktura = new Faktura();
            faktura.Stavke = new List<Stavka>();

            return View(faktura);
        }

        [HttpGet]
        public ActionResult ViewAllFakture()
        {
            FakturaService service = new FakturaService();
            var returnAnswer = service.GetAllFakture();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FakturaBLLToVMProfile>();
            });
            var mapper = new Mapper(config);
            List<Faktura> fakture = mapper.DefaultContext.Mapper.Map<List<Faktura>>(returnAnswer);

            return View(fakture);
        }

        public ActionResult AddStavka()
        {
            return PartialView("StavkaRow", new Stavka());
        }

        [HttpPost]
        public float CalculateTaxes(PDVCalculation data)
        {
            TaxCalculationService service = new TaxCalculationService();
            return service.CalculateTaxes(data.Cijena, data.Drzava, data.PDV);
        }

        [HttpGet]
        public string GetUser()
        {
            if (User.Identity.GetUserName() != null)
            {
                return User.Identity.GetUserName();
            }
            else
            {
                RedirectToAction("Index", "Home");
                return " ";
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFaktura([Bind(Include = "DatumIzdavanja, DatumDospijeca, Stavke, Cijena, PDV, CijenaSPDVom, StvarateljRacuna, Primatelj")]Faktura faktura)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.AddProfile<FakturaVMToFakturaBLLProfile>();
                    });
                    var mapper = new Mapper(config);
                    FakturaBLL fakturaBLL = mapper.DefaultContext.Mapper.Map<FakturaBLL>(faktura);

                    FakturaService service = new FakturaService();
                    var returnAnswer = service.CreateFaktura(fakturaBLL);
                    if (returnAnswer == "OK")
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("CreateFaktura");
                    }
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(faktura);
        }
    }
}