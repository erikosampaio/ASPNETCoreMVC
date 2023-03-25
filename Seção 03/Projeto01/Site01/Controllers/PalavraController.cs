using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Site01.Models;

namespace Site01.Controllers
{
    public class PalavraController : Controller
    {
        // Listar todas as palavras
        public IActionResult Index()
        {
            return View();
        }


        // CRUD - Create(Criar), Read(Consultar), Update(Atualizar), Delete(Deletar)
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm]Palavra palavra)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Atualizar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm]Palavra palavra)
        {
            return View();
        }

        // palavra/excluir/id
        // {Controller}/{Action}/{Id?}
        [HttpGet]
        public IActionResult Excluir(int Id)
        {
            return RedirectToAction("Index");
        }
    }
}