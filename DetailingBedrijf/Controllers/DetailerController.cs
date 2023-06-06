using DataLaag.DataToegang;
using InterfaceLaag.Interfaces;
using LogicaLaag.Logica;
using LogicaLaag.Models;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace DetailingBedrijf.Controllers
{ 
    public class DetailerController : Controller
    {
        private DetailerLogica _logica;

        public DetailerController(IConfiguration configuration)
        {
            DetailerDataToegang _data = new DetailerDataToegang(configuration);
            DetailerLogica logica = new DetailerLogica(_data);
            _logica = logica;
        }
        public IActionResult Index()
        {
            List<DetailerModel> models = _logica.HaalAlleDetailersOp();
            return View(models);
        }
    }
}
