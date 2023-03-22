using Microsoft.AspNetCore.Mvc;

namespace Site01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return new ContentResult() { Content = "Olá Vida!", ContentType = "text/json" };
        }
    }
}
