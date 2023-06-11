using DataLaag.DataToegang;
using InterfaceLaag.DTOs;
using InterfaceLaag.Interfaces;
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
    }
}
