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
        private AutoLogica _logica;
        private AutoMapping _mapping = new AutoMapping();

        public AutoController(IConfiguration configuration)
        {
            IAuto _autoData = new AutoDataToegang(configuration);
            AutoLogica logica = new AutoLogica(_autoData);
            _logica = logica;
        }
        public IActionResult Index()
        {
            List<AutoModel> models = _logica.HaalAllesOp();
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
            _logica.Aanmaken(_mapping.MapModelNaarDTO(model));
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        [Route("Auto/Details/{id}")]
        public IActionResult Details(int id)
        {
            AutoModel model = _logica.HaalOpViaID(id);
            return View(model);
        }

        [Route("Detailer/Verwijderen/{id}")]
        public IActionResult Verwijderen(int id)
        {
            _logica.Verwijderen(id);
            return RedirectToAction("Index", "Dashboard");
        }

        private string HaalConnectionStringOp(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            return connectionString;
        }
    }
}
