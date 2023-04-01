using Microsoft.AspNetCore.Http;
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
                if (usuario.Email == "teste@teste.com" && usuario.Senha == "123456")
                {
                    /*
                    * - Add Session
                    * HttpContext.Session.SetString("Login", "true");
                    * HttpContext.Session.SetInt32("UserID", 32);
                    * HttpContext.Session.SetString("Login", Serializar Object > String);
                    * 
                    * - Ler Session
                    * HttpContext.Session.GetString("Login");
                    * HttpContext.Session.Get   String("Login", Deserializar String > Object) --> (?);
                    */

                    HttpContext.Session.SetString("Login", "true");
                    return RedirectToAction("Index", "Palavra");
                }
                else
                {
                    ViewBag.Message = "Email e/ou senha inválido(s)";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
