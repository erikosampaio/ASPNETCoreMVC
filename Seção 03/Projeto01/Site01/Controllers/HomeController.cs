using Microsoft.AspNetCore.Mvc;
using Site01.Models;

namespace Site01.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // return new ContentResult() { Content = "Olá Vida!", ContentType = "text/json" };
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm]Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario.Email == "erikoa.93@gmail.com" && usuario.Senha == "123456")
                {
                    return RedirectToAction("Index", "Palavra");
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
