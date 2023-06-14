using DataLaag.DataToegang;
using DomeinLaag.DTOs;
using DomeinLaag.Interfaces;
using DomeinLaag.Logica;
using DomeinLaag.Mapping;
using DomeinLaag.Models;
using Microsoft.AspNetCore.Mvc;

namespace DetailingBedrijf.Controllers
{
    public class AutoEigenaarController : Controller
    {
        private AutoEigenaarLogica _logica;
        private AutoEigenaarMapping _mapping = new AutoEigenaarMapping();

        public AutoEigenaarController(IConfiguration configuration)
        {
            IAutoEigenaar _autoEigenaarData = new AutoEigenaarDataToegang(configuration);
            IAuto _autoData = new AutoDataToegang(configuration);
            AutoEigenaarLogica logica = new AutoEigenaarLogica(_autoEigenaarData, _autoData);
            _logica = logica;
        }
        public IActionResult Index()
        {
            List<AutoEigenaarModel> models = _logica.HaalAllesOp();
            return View(models);
        }

        [HttpGet]
        [Route("AutoEigenaar/Aanmaken")]
        public IActionResult Aanmaken()
        {
            return View(new AutoEigenaarModel());
        }

        [HttpPost]
        public IActionResult Aanmaken(AutoEigenaarModel model)
        {
            _logica.Aanmaken(_mapping.MapModelNaarDTO(model));
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        [Route("AutoEigenaar/Details/{id}")]
        public IActionResult Details(int id)
        {
            AutoEigenaarModel model = _logica.OphalenOpID(id);
            return View(model);
        }

        [Route("AutoEigenaar/Verwijderen/{id}")]
        public IActionResult Verwijderen(int id)
        {
            _logica.VerwijderenOpID(id);
            return RedirectToAction("Index", "Dashboard");
        }
        
        [HttpGet]
        [Route("Auto/AutosVanEigenaarOpID/{eigenaarID:int}")]
        public IActionResult AutosVanEigenaarOpID(int eigenaarID)
        {
            AutoEigenaarModel eigenaarEnAutos = _logica.HaalAutosOpVoorEigenaar(eigenaarID);
            return View(eigenaarEnAutos);
        }
        
        private string HaalConnectionStringOp(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            return connectionString;
        }
    }
}
