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
        private AutoEigenaarCollectie _logica;
        private AutoEigenaarMapping _mapping = new AutoEigenaarMapping();

        public AutoEigenaarController(IConfiguration configuration)
        {
            IAutoEigenaar _autoEigenaarData = new AutoEigenaarDataToegang(configuration);
            IAuto _autoData = new AutoDataToegang(configuration);
            AutoEigenaarCollectie logica = new AutoEigenaarCollectie(_autoEigenaarData, _autoData);
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
        
        
        //ToDo: Ophalen auto's en toevoegen aan eigenaar. 
        [HttpGet]
        [Route("AutoEigenaar/Details/{id}")]
        public IActionResult Details(int id)
        {
            List<AutoModel> autos = _logica.HaalAutosOpVoorEigenaar(id);
            AutoEigenaarModel model = _logica.OphalenOpID(id);
            model.AutosEigenaar = autos;
            return View(model);
        }

        [Route("AutoEigenaar/Verwijderen/{id}")]
        public IActionResult Verwijderen(int id)
        {
            _logica.VerwijderenOpID(id);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
