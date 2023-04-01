using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Site01.Database;
using Site01.Library.Filters;
using Site01.Models;
using X.PagedList;

namespace Site01.Controllers
{       
    [Login]
    public class PalavraController : Controller
    {
        private DatabaseContext _db;

        List<Nivel> niveis = new List<Nivel>();
        public PalavraController(DatabaseContext db)
        {
            _db = db;

            niveis.Add(new Nivel() { Id = 1, Nome = "1 - Fácil" });
            niveis.Add(new Nivel() { Id = 2, Nome = "2 - Médio" });
            niveis.Add(new Nivel() { Id = 3, Nome = "3 - Difícil" });
        }

        // Listar todas as palavras
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;

            var palavras = _db.Palavras.ToList();

            var resultadoPaginado = _db.Palavras.OrderBy(a => a.Id).ToPagedList(pageNumber, 5);
            return View(resultadoPaginado);
        }


        // CRUD - Create(Criar), Read(Consultar), Update(Atualizar), Delete(Deletar)
        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Nivel = niveis;

            return View(new Palavra());
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm]Palavra palavra)
        {
            ViewBag.Nivel = niveis;

            if (ModelState.IsValid)
            {
                _db.Palavras.Add(palavra);
                _db.SaveChanges();

                TempData["Mensagem"] = "Palavra '" + palavra.Nome + "' criada com sucesso!";

                return RedirectToAction("Index");
            }

            return View(palavra);
        }

        [HttpGet]
        public IActionResult Atualizar(int Id)
        {
            ViewBag.Nivel = niveis;

            Palavra palavra = _db.Palavras.Find(Id);

            return View("Cadastrar", palavra);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm]Palavra palavra)
        {
            ViewBag.Nivel = niveis;

            if (ModelState.IsValid)
            {
                _db.Update(palavra);
                _db.SaveChanges();

                TempData["Mensagem"] = "Palavra '" + palavra.Nome + "' atualizada com sucesso!";

                return RedirectToAction("Index");
            }
            return View("Cadastrar", palavra);
        }

        // palavra/excluir/id
        // {Controller}/{Action}/{Id?}
        [HttpGet]
        public IActionResult Excluir(int Id)
        {
            Palavra palavra = _db.Palavras.Find(Id);
            _db.Palavras.Remove(palavra);
            _db.SaveChanges();

            TempData["Mensagem"] = "Palavra '" + palavra.Nome + "' excluída com sucesso!";

            return RedirectToAction("Index");
        }
    }
}