using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DevelopmentInProgress.AuthorisationManager.ASP.Net.Core.ViewModels;

namespace DevelopmentInProgress.AuthorisationManager.ASP.Net.Core.ViewComponents
{
    [ViewComponent(Name="Role")]
    public class RoleViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(RoleViewModel role)
        {
            if (role == null)
            {
                role = new RoleViewModel();
            }

            return View(role);
        }
    }
}
