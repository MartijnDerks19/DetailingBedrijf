﻿using DataLaag.DataToegang;
using DomeinLaag.DTOs;
using DomeinLaag.Interfaces;
using DomeinLaag.Logica;
using DomeinLaag.Mapping;
using DomeinLaag.Models;
using Microsoft.AspNetCore.Mvc;

namespace DetailingBedrijf.Controllers
{
    public class DashboardController : Controller
    {
        private DetailerLogica _logica;
        private DetailerMapping _mapping = new DetailerMapping();

        public DashboardController(IConfiguration configuration)
        {
            IDetailer _data = new DetailerDataToegang(HaalConnectionStringOp(configuration));
            DetailerLogica logica = new DetailerLogica(_data);
            _logica = logica;
        }
        public IActionResult Index()
        {
            List<DetailerModel> models = _logica.HaalAllesOp();
            return View(models);
        }

        public IActionResult DetailerAanpassing()
        {
            return RedirectToAction("Index", "Detailer");
        }
        public IActionResult AfspraakAanpassingen()
        {
            return RedirectToAction("Index", "Afspraak");
        }

        public IActionResult AutoEigenaarAanpassingen()
        {
            return RedirectToAction("Index", "AutoEigenaar");
        }

        public IActionResult AutoAanpassingen()
        {
            return RedirectToAction("Index", "Detailer");
        }

        public IActionResult AfspraakInplannen(int detailerID)
        {
            return RedirectToAction("Aanmaken", "Afspraak", detailerID);
        }
        
        private string HaalConnectionStringOp(IConfiguration configuration)
        {
            string connectionString = configuration.GetSection("ConnectionSettings")["ConnectionString"];
            return connectionString;
        }
    }
}
