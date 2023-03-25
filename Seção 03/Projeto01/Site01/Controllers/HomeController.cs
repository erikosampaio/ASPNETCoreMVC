using Microsoft.AspNetCore.Mvc;
using Site01.Models;

namespace Site01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // return new ContentResult() { Content = "Olá Vida!", ContentType = "text/json" };
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([FromForm]Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario.Email == "erikoa.93@gmail.com" && usuario.Senha == "123456")
                {
                    return Redirect("/palavra");
                }
                else
                {
                    ViewBag.Message = "Email e/ou senha inválido(s)";
                    return View();
                }
            }
            else {
                return View();
            }
        }
    }
}
