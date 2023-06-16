using DataLaag.DataToegang;
using DomeinLaag.Interfaces;
using DomeinLaag.Logica;
using DomeinLaag.Mapping;
using DomeinLaag.Models;
using Microsoft.AspNetCore.Mvc;

namespace DetailingBedrijf.Controllers
{
    public class AutoEigenaarController : Controller
    {
        private AutoEigenaarCollectie _collectie;
        private AutoEigenaarMapping _mapping = new AutoEigenaarMapping();

        public AutoEigenaarController(IConfiguration configuration)
        {
            IAutoEigenaar _autoEigenaarData = new AutoEigenaarDataToegang(configuration);
            IAuto _autoData = new AutoDataToegang(configuration);
            AutoEigenaarCollectie collectie = new AutoEigenaarCollectie(_autoEigenaarData, _autoData);
            _collectie = collectie;
        }
        public IActionResult Index()
        {
            List<AutoEigenaarModel> models = _collectie.HaalAllesOp();
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
            _collectie.Aanmaken(_mapping.MapModelNaarDTO(model));
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        [Route("AutoEigenaar/Details/{id}")]
        public IActionResult Details(int id)
        {
            AutoEigenaarModel model = _collectie.OphalenOpID(id);
            return View(model);
        }

        [Route("AutoEigenaar/Verwijderen/{id}")]
        public IActionResult Verwijderen(int id)
        {
            _collectie.VerwijderenOpID(id);
            return RedirectToAction("Index", "Dashboard");
        }
        
        [HttpGet]
        [Route("Auto/AutosVanEigenaarOpID/{eigenaarID:int}")]
        public IActionResult AutosVanEigenaarOpID(int eigenaarID)
        {
            AutoEigenaarModel eigenaarEnAutos = _collectie.HaalAutosOpVoorEigenaar(eigenaarID);
            return View(eigenaarEnAutos);
        }
        
        private string HaalConnectionStringOp(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            return connectionString;
        }
    }
}
