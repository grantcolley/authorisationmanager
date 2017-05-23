using Microsoft.AspNetCore.Mvc;

namespace DevelopmentInProgress.AuthorisationManager.ASP.Net.Core.Controllers.App
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}