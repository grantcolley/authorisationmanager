using System.Web.Mvc;

namespace DevelopmentInProgress.AuthorisationManager.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Authorisation Manager.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Details.";

            return View();
        }
    }
}