using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevelopmentInProgress.AuthorisationManager.ASP.Net.Core.ViewComponents
{
    [ViewComponent(Name = "AuthorisationTree")]
    public class AuthorisationTreeViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
