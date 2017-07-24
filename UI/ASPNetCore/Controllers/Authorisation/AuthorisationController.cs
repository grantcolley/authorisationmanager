using Microsoft.AspNetCore.Mvc;
using DevelopmentInProgress.AuthorisationManager.ASP.Net.Core.ViewModels;

namespace DevelopmentInProgress.AuthorisationManager.ASP.Net.Core.Controllers.Authorisation
{
    public class AuthorisationController : Controller
    {
        public IActionResult Authorisation()
        {
            return View(new AuthorisationViewModel());
        }

        [HttpPost]
        public IActionResult UserSave(AuthorisationViewModel authorisation)
        {
            return View("Authorisation", authorisation);
        }

        [HttpPost]
        public IActionResult RoleSave(AuthorisationViewModel authorisation)
        {
            return View("Authorisation", authorisation);
        }

        [HttpPost]
        public IActionResult ActivitySave(AuthorisationViewModel authorisation)
        {
            return View("Authorisation", authorisation);
        }
    }
}
