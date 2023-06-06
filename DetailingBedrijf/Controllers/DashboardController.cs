using Microsoft.AspNetCore.Mvc;

namespace DetailingBedrijf.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
