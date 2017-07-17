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
        public IActionResult UserSave(UserViewModel user)
        {
            var authorisation = new AuthorisationViewModel();
            authorisation.User = user;
            return View("Authorisation", authorisation);
        }

        [HttpPost]
        public IActionResult RoleSave(RoleViewModel role)
        {
            var authorisation = new AuthorisationViewModel();
            authorisation.Role = role;
            return View("Authorisation", authorisation);
        }

        [HttpPost]
        public IActionResult ActivitySave(ActivityViewModel activity)
        {
            var authorisation = new AuthorisationViewModel();
            authorisation.Activity = activity;
            return View("Authorisation", authorisation);
        }
    }
}
