using DataLaag.DataToegang;
using LogicaLaag.DTOs;
using LogicaLaag.Interfaces;
using LogicaLaag.Logica;
using LogicaLaag.Mapping;
using LogicaLaag.Models;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace DetailingBedrijf.Controllers
{ 
    public class DetailerController : Controller
    {
        private DetailerLogica _logica;
        private DetailerMapping _mapping = new DetailerMapping();

        public DetailerController(IConfiguration configuration)
        {
            ICRUDCollectie<DetailerDTO> _data = new DetailerDataToegang(configuration);//
            DetailerLogica logica = new DetailerLogica(_data);
            _logica = logica;
        }
        public IActionResult Index()
        {
            List<DetailerModel> models = _logica.HaalAllesOp();
            return View(models);
        }

        [HttpGet]
        [Route("Detailer/Aanmaken")]
        public IActionResult Aanmaken()
        {
            return View(new DetailerModel());
        }

        [HttpPost]
        public IActionResult Aanmaken(DetailerModel model)
        {
            _logica.Aanmaken(_mapping.MapModelNaarDTO(model));
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        [Route("Detailer/Details/{id}")]
        public IActionResult Details(int id)
        {
            DetailerModel model = _logica.HaalOpViaID(id);
            return View(model);
        }

        [Route("Detailer/Verwijderen/{id}")]
        public IActionResult Verwijderen(int id)
        {
            _logica.Verwijderen(id);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
