using DataLaag.DataToegang;
using LogicaLaag.DTOs;
using LogicaLaag.Interfaces;
using LogicaLaag.Logica;
using LogicaLaag.Mapping;
using LogicaLaag.Models;
using Microsoft.AspNetCore.Mvc;

namespace DetailingBedrijf.Controllers
{
    public class DashboardController : Controller
    {
        private DetailerLogica _logica;
        private DetailerMapping _mapping = new DetailerMapping();

        public DashboardController(IConfiguration configuration)
        {
            ICRUDCollectie<DetailerDTO> _data = new DetailerDataToegang(configuration);
            DetailerLogica logica = new DetailerLogica(_data);
            _logica = logica;
        }
        public IActionResult Index()
        {
            List<DetailerModel> models = _logica.HaalAllesOp();
            return View(models);
        }

        public IActionResult DetailerAanpassing()
        {
            return RedirectToAction("Index", "Detailer");
        }
        public IActionResult AfspraakAanpassingen()
        {
            return RedirectToAction("Index", "Afspraak");
        }

        public IActionResult AutoEigenaarAanpassingen()
        {
            return RedirectToAction("Index", "AutoEigenaar");
        }

        public IActionResult AutoAanpassingen()
        {
            return RedirectToAction("Index", "Detailer");
        }

        public IActionResult AfspraakInplannen(int detailerID)
        {
            return RedirectToAction("Afspraak", "Aanmaken", detailerID);
        }
    }
}
