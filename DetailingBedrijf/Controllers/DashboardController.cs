using DataLaag.DataToegang;
using DataLaag.DTOs;
using InterfaceLaag.Interfaces;
using LogicaLaag.Logica;
using LogicaLaag.Mapping;
using LogicaLaag.Models;
using Microsoft.AspNetCore.Mvc;

namespace DetailingBedrijf.Controllers
{
    //ToDo: Aanmaken van een dashboard. Lijst van detailers word getoond. Op het moment dat er op details wordt geklikt wordt een agenda getoond. 
    //ToDo: In dit dashboard kunnen afspraken worden aangemaakt, verwijderd en ingezien.
    public class DashboardController : Controller
    {
        private DetailerLogica _logica;
        private DetailerMapping _mapping = new DetailerMapping();

        public DashboardController(IConfiguration configuration)
        {
            ICRUDCollectie<DetailerDTO> _data = new DetailerDataToegang(configuration);//
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
