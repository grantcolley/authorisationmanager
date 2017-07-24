using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevelopmentInProgress.AuthorisationManager.ASP.Net.Core.ViewModels;

namespace DevelopmentInProgress.AuthorisationManager.ASP.Net.Core.ViewComponents
{
    [ViewComponent(Name = "AuthorisationTree")]
    public class AuthorisationTreeViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

        public ActionResult GetTree()
        {
            var nodes = new List<JsTreeNodeModel>();
            nodes.Add(new JsTreeNodeModel() { id = "101", parent = "#", text = "Simple root node" });
            nodes.Add(new JsTreeNodeModel() { id = "102", parent = "#", text = "Root node 1" });
            nodes.Add(new JsTreeNodeModel() { id = "103", parent = "102", text = "Child 1" });
            nodes.Add(new JsTreeNodeModel() { id = "104", parent = "102", text = "Child 2" });
            return null;
        }
    }
}
