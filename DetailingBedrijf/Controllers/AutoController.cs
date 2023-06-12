using DataLaag.DataToegang;
using LogicaLaag.DTOs;
using LogicaLaag.Interfaces;
using LogicaLaag.Logica;
using LogicaLaag.Mapping;
using LogicaLaag.Models;
using Microsoft.AspNetCore.Mvc;

namespace DetailingBedrijf.Controllers
{
    public class AutoController : Controller
    {
        private AutoLogica _logica;
        private AutoMapping _mapping = new AutoMapping();

        public AutoController(IConfiguration configuration)
        {
            ICRUDCollectie<AutoDTO> _data = new AutoDataToegang(configuration);//
            AutoLogica logica = new AutoLogica(_data);
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
    }
}
