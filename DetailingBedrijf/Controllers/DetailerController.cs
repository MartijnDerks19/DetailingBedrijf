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
        private DetailerLogica _logica;
        private DetailerMapping _mapping = new DetailerMapping();

        public DetailerController(IConfiguration configuration)
        {
            IDetailer _data = new DetailerDataToegang(configuration);
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

        [HttpGet]
        [Route("Detailer/AfsprakenOphalen/{detailerID:int}")]
        public IActionResult OphalenVoorDetailer(int detailerID)
        {
            DetailerModel model = _logica.AfsprakenOphalenOpID(detailerID);
            return View(model.AfsprakenDetailer);
        }

        private string HaalConnectionStringOp(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            return connectionString;
        }
    }
}
