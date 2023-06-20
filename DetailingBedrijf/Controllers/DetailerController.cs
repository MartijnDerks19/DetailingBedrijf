using DataLaag.DataToegang;
using DomeinLaag.DTOs;
using DomeinLaag.Interfaces;
using DomeinLaag.Logica;
using DomeinLaag.Mapping;
using DomeinLaag.Models;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace DetailingBedrijf.Controllers
{ 
    public class DetailerController : Controller
    {
        private DetailerCollectie _collectie;
        private DetailerMapping _mapping = new DetailerMapping();

        public DetailerController(IConfiguration configuration)
        {
            IDetailer _data = new DetailerDataToegang(configuration);
            DetailerCollectie collectie = new DetailerCollectie(_data);
            _collectie = collectie;
        }
        public IActionResult Index()
        {
            List<DetailerModel> models = _collectie.HaalAllesOp();
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
            _collectie.Aanmaken(_mapping.MapModelNaarDTO(model));
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        [Route("Detailer/Details/{id}")]
        public IActionResult Details(int id)
        {
            DetailerModel model = _collectie.HaalOpViaID(id);
            return View(model);
        }

        [Route("Detailer/Verwijderen/{id}")]
        public IActionResult Verwijderen(int id)
        {
            _collectie.Verwijderen(id);
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        [Route("Detailer/AfsprakenOphalen/{detailerID:int}")]
        public IActionResult OphalenVoorDetailer(int detailerID)
        {
            DetailerModel model = _collectie.AfsprakenOphalenOpID(detailerID);
            return View(model.AfsprakenDetailer);
        }
    }
}
