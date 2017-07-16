using DevelopmentInProgress.AuthorisationManager.ASP.Net.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentInProgress.AuthorisationManager.ASP.Net.Core.Controllers.App
{
    public class AuthorisationController : Controller
    {
        public IActionResult Authorisation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserSave(UserViewModel user)
        {

            return View();
        }
    }
}
