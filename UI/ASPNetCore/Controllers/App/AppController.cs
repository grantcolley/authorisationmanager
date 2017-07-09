using DevelopmentInProgress.AuthorisationManager.ASP.Net.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentInProgress.AuthorisationManager.ASP.Net.Core.Controllers.App
{
    public class AppController : Controller
    {
        public IActionResult Authorisation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authorisation(UserViewModel userViewModel)
        {
            return View();
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