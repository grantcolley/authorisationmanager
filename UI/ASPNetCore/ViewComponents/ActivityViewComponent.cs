using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DevelopmentInProgress.AuthorisationManager.ASP.Net.Core.ViewModels;

namespace DevelopmentInProgress.AuthorisationManager.ASP.Net.Core.ViewComponents
{
    [ViewComponent(Name="Activity")]
    public class ActivityViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ActivityViewModel activity)
        {
            if (activity == null)
            {
                activity = new ActivityViewModel();
            }

            return View(activity);
        }
    }
}
