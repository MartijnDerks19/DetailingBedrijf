using DataLaag.DataToegang;
using InterfaceLaag.Interfaces;
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
            IDetailer _data = new DetailerDataToegang(configuration);//
            DetailerLogica logica = new DetailerLogica(_data);
            _logica = logica;
        }
        public IActionResult Index()
        {
            List<DetailerModel> models = _logica.HaalAlleDetailersOp();
            return View(models);
        }

        [HttpGet]
        [Route("Detailer/Aanmaken")]
        public IActionResult Aanmaken()
        {
            return View(new DetailerModel());
        }

        [HttpGet]
        [Route("Detailer/Details/{id}")]
        public IActionResult Details(int id)
        {
            DetailerModel model = _logica.HaalDetailerOpViaID(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Aanmaken(DetailerModel model)
        {
            _logica.DetailerAanmaken(_mapping.MapModelNaarDTO(model));
            return RedirectToAction("Index");
        }

        [Route("Detailer/Verwijderen/{id}")]
        public IActionResult Verwijderen(int id)
        {
            _logica.VerwijderDetailer(id);
            return RedirectToAction("Index");
        }
    }
}
