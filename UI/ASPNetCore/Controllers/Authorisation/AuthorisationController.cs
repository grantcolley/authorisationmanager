using Microsoft.AspNetCore.Mvc;
using DevelopmentInProgress.AuthorisationManager.ASP.Net.Core.ViewModels;
using System.Collections.Generic;

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

        public ActionResult GetTree(string tab)
        {
            var nodes = new List<JsTreeNodeModel>();
            nodes.Add(new JsTreeNodeModel() { id = "101", parent = "#", text = "Simple root node" });
            nodes.Add(new JsTreeNodeModel() { id = "102", parent = "#", text = "Root node 1" });
            nodes.Add(new JsTreeNodeModel() { id = "103", parent = "102", text = "Child 1" });
            nodes.Add(new JsTreeNodeModel() { id = "104", parent = "102", text = "Child 2" });
            return Json(nodes);
        }
    }
}
