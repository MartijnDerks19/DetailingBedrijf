﻿using DataLaag.DataToegang;
using LogicaLaag.DTOs;
using LogicaLaag.Interfaces;
using LogicaLaag.Logica;
using LogicaLaag.Mapping;
using LogicaLaag.Models;
using Microsoft.AspNetCore.Mvc;

namespace DetailingBedrijf.Controllers
{
    public class AfspraakController : Controller
    {
        private AfspraakLogica _logica;
        private AfspraakMapping _mapping = new AfspraakMapping();

        public AfspraakController(IConfiguration configuration)
        {
            ICRUDCollectie<AfspraakDTO> _data = new AfspraakDataToegang(configuration);//
            IDashboard _dashboardData = new AfspraakDataToegang(configuration);
            AfspraakLogica logica = new AfspraakLogica(_data, _dashboardData);
            _logica = logica;
        }
        public IActionResult Index()
        {
            List<AfspraakModel> models = _logica.HaalAllesOp();
            return View(models);
        }

        [HttpGet]
        [Route("Afspraak/Aanmaken")]
        public IActionResult Aanmaken()
        {
            return View(new AfspraakModel());
        }

        [HttpPost]
        public IActionResult Aanmaken(AfspraakModel model)
        {
            _logica.ProbeerAanmaken(_mapping.MapModelNaarDTO(model));
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        [Route("Afspraak/Details/{id}")]
        public IActionResult Details(int id)
        {
            AfspraakModel model = _logica.HaalOpViaID(id);
            return View(model);
        }

        [Route("Afspraak/Verwijderen/{id}")]
        public IActionResult Verwijderen(int id)
        {
            _logica.Verwijderen(id);
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        [Route("Afspraak/OphalenVoorDetailer/{detailerID}")]
        public IActionResult OphalenVoorDetailer(int detailerID)
        {
            List<AfspraakModel> afsprakenVanDetailer = _logica.HaalOpVoorDetailer(detailerID);
            return View(afsprakenVanDetailer);
        }

        [HttpGet]
        [Route("Afspraak/AanmakenVoorDetailer/{detailerID}")]
        public IActionResult AanmakenVoorDetailer()
        {
            return View(new AfspraakModel());
        }

        [HttpPost]
        [Route("Afspraak/AanmakenVoorDetailer/{detailerID}")]
        public IActionResult AanmakenVoorDetailer(int detailerID, AfspraakModel model)
        {
            model.DetailerID = detailerID;
            _logica.ProbeerAanmaken(_mapping.MapModelNaarDTO(model));
            return RedirectToAction("Index", "Dashboard");
        }

    }
}
