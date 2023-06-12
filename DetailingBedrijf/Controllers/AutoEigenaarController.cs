using DataLaag.DataToegang;
using LogicaLaag.DTOs;
using LogicaLaag.Interfaces;
using LogicaLaag.Logica;
using LogicaLaag.Mapping;
using LogicaLaag.Models;
using Microsoft.AspNetCore.Mvc;

namespace DetailingBedrijf.Controllers
{
    public class AutoEigenaarController : Controller
    {
        private AutoEigenaarLogica _logica;
        private AutoEigenaarMapping _mapping = new AutoEigenaarMapping();

        public AutoEigenaarController(IConfiguration configuration)
        {
            ICRUDCollectie<AutoEigenaarDTO> _data = new AutoEigenaarDataToegang(configuration);//
            AutoEigenaarLogica logica = new AutoEigenaarLogica(_data);
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
    }
}
