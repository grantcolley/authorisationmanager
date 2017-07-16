using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DevelopmentInProgress.AuthorisationManager.ASP.Net.Core.ViewModels;

namespace DevelopmentInProgress.AuthorisationManager.ASP.Net.Core.ViewComponents
{
    [ViewComponent(Name="User")]
    public class UserViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(UserViewModel userViewModel)
        {
            if (userViewModel == null)
            {
                userViewModel = new UserViewModel();
            }

            return View(userViewModel);
        }
    }
}
