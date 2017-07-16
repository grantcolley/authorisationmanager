using Microsoft.AspNetCore.Mvc;

namespace DevelopmentInProgress.AuthorisationManager.ASP.Net.Core.Controllers.App
{
    public class AppController : Controller
    {
        public IActionResult Home()
        {
            return RedirectToAction("Authorisation", "Authorisation");
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}