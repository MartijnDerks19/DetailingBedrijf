using DataLaag.DataToegang;
using DomeinLaag.DTOs;
using DomeinLaag.Exceptions;
using DomeinLaag.Interfaces;
using DomeinLaag.Logica;
using DomeinLaag.Mapping;
using DomeinLaag.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.Extensions.Configuration.Ini;

namespace DetailingBedrijf.Controllers
{
    public class AfspraakController : Controller
    {
        private AfspraakCollectie _collectie;
        private IConfiguration _configuration;
        private AfspraakMapping _mapping = new AfspraakMapping();

        public AfspraakController(IConfiguration configuration)
        {
            IAfspraak _afspraakData = new AfspraakDataToegang(configuration);
            IDetailer _detailerData = new DetailerDataToegang(configuration);
            AfspraakCollectie collectie = new AfspraakCollectie(_afspraakData, _detailerData);
            _collectie = collectie;
        }
        public IActionResult Index()
        {
            List<AfspraakModel> models = _collectie.HaalAllesOp();
            return View(models);
        }

        [HttpGet]
        [Route("Afspraak/Aanmaken")]
        public IActionResult Aanmaken()
        {
            return View(new AfspraakModel());
        }

        [HttpPost]
        public IActionResult Aanmaken(AfspraakModel model)
        {
            _collectie.ProbeerAanmaken(_mapping.MapModelNaarDTO(model));
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        [Route("Afspraak/Details/{id:int}")]
        public IActionResult Details(int id)
        {
            AfspraakModel model = _collectie.HaalOpViaID(id);
            return View(model);
        }

        [Route("Afspraak/Verwijderen/{id}")]
        public IActionResult Verwijderen(int id)
        {
            _collectie.Verwijderen(id);
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        [Route("Afspraak/OphalenVoorDetailer/{detailerID:int}")]
        public IActionResult OphalenVoorDetailer(int detailerID)
        {
            List<AfspraakModel> models = _collectie.HaalOpVoorDetailer(detailerID);
            return View(models);
        }

        [HttpGet]
        [Route("Afspraak/AanmakenVoorDetailer/{detailerID:int}")]
        public IActionResult AanmakenVoorDetailer()
        {
            return View(new AfspraakModel());
        }


        //Oude methode
        //[HttpPost]
        //[Route("Afspraak/AanmakenVoorDetailer/{detailerID}")]
        //public IActionResult AanmakenVoorDetailer(int detailerID, AfspraakModel model)
        //{
        //    model.DetailerID = detailerID;
        //    _logica.ProbeerAanmaken(_mapping.MapModelNaarDTO(model));
        //    return RedirectToAction("Index", "Dashboard");
        //}

        //Nieuwe methode
        [HttpPost]
        [Route("Afspraak/AanmakenVoorDetailer/{detailerID:int}")]
        public IActionResult AanmakenVoorDetailer(int detailerID, AfspraakModel model)
        {
            try
            {
                model.DetailerID = detailerID;
                _collectie.ProbeerAanmaken(_mapping.MapModelNaarDTO(model));
                return RedirectToAction("Index", "Dashboard");
            }
            catch (Exception divge)
            {
                Console.Write($"{divge.Message}\n {divge.InnerException}"); //Eerst specifieke catch daarna generiek.
                return RedirectToAction("Index", "Dashboard"); //return Error view model met message. 
                //DataAnnotations
            }
        }

        private string HaalConnectionStringOp(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            return connectionString;
        }

    }
}
