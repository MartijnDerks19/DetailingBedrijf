using Microsoft.AspNetCore.Mvc;

namespace DetailingBedrijf.Controllers
{
    //ToDo: Aanmaken van een dashboard. Lijst van detailers word getoond. Op het moment dat er op details wordt geklikt wordt een agenda getoond. 
    //ToDo: In dit dashboard kunnen afspraken worden aangemaakt, verwijderd en ingezien.
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
