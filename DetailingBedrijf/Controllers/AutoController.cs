using DataLaag.DataToegang;
using DomeinLaag.DTOs;
using DomeinLaag.Interfaces;
using DomeinLaag.Logica;
using DomeinLaag.Mapping;
using DomeinLaag.Models;
using Microsoft.AspNetCore.Mvc;

namespace DetailingBedrijf.Controllers
{
    public class AutoController : Controller
    {
        private AutoCollectie _collectie;
        private AutoMapping _mapping = new AutoMapping();

        public AutoController(IConfiguration configuration)
        {
            IAuto _autoData = new AutoDataToegang(configuration);
            AutoCollectie collectie = new AutoCollectie(_autoData);
            _collectie = collectie;
        }

        public IActionResult Index()
        {
            List<AutoModel> models = _collectie.HaalAllesOp();
            return View(models);
        }

        [HttpGet]
        [Route("Auto/Aanmaken")]
        public IActionResult Aanmaken()
        {
            return View(new AutoModel());
        }

        [HttpPost]
        public IActionResult Aanmaken(AutoModel model)
        {
            _collectie.Aanmaken(_mapping.MapModelNaarDTO(model));
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        [Route("Auto/Details/{id}")]
        public IActionResult Details(int id)
        {
            AutoModel model = _collectie.HaalOpViaID(id);
            return View(model);
        }

        [Route("Detailer/Verwijderen/{id}")]
        public IActionResult Verwijderen(int id)
        {
            _collectie.Verwijderen(id);
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public IActionResult AanpassenOpID()
        {
            AutoModel model = new();
            return View(model);
        }
        
        [HttpPost]
        [Route("Detailer/AanpassenOpID/{id}")]
        public IActionResult AanpassenOpID(AutoModel model, int id)
        {
            _collectie.Aanpassen(id, model);
            return RedirectToAction("Index", "Dashboard");
        }
        
        
    }
}
