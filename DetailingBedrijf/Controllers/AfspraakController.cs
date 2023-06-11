using DataLaag.DataToegang;
using DataLaag.DTOs;
using InterfaceLaag.DTOs;
using InterfaceLaag.Interfaces;
using LogicaLaag.Logica;
using LogicaLaag.Mapping;
using LogicaLaag.Models;
using Microsoft.AspNetCore.Mvc;

namespace DetailingBedrijf.Controllers
{
    public class AfspraakController : Controller
    {
        private AfspraakLogica _logica;
        private AfspraakMapping _mapping = new AfspraakMapping();

        public AfspraakController(IConfiguration configuration)
        {
            ICRUDCollectie<AfspraakDTO> _data = new AfspraakDataToegang(configuration);//
            AfspraakLogica logica = new AfspraakLogica(_data);
            _logica = logica;
        }
        public IActionResult Index()
        {
            List<AfspraakModel> models = _logica.HaalAllesOp();
            return View(models);
        }

    }
}
