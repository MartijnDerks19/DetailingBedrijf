using DataLaag.DataToegang;
using InterfaceLaag.DTOs;
using InterfaceLaag.Interfaces;
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
    }
}
