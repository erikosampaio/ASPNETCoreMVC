﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Site01.Database;
using Site01.Library.Filters;
using Site01.Models;

namespace Site01.Controllers
{       
    [Login]
    public class PalavraController : Controller
    {
        private DatabaseContext _db;

        public PalavraController(DatabaseContext db)
        {
            _db = db;
        }

        // Listar todas as palavras
        public IActionResult Index()
        {
            var palavras = _db.Palavras.ToList();
            return View(palavras);
        }


        // CRUD - Create(Criar), Read(Consultar), Update(Atualizar), Delete(Deletar)
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View(new Palavra());
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm]Palavra palavra)
        {
            if (ModelState.IsValid)
            {
                _db.Palavras.Add(palavra);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Atualizar(int Id)
        {
            Palavra palavra = _db.Palavras.Find(Id);

            return View("Cadastrar", palavra);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm]Palavra palavra)
        {
            if (ModelState.IsValid)
            {
                _db.Update(palavra);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Cadastrar", palavra);
        }

        // palavra/excluir/id
        // {Controller}/{Action}/{Id?}
        [HttpGet]
        public IActionResult Excluir(int Id)
        {
            _db.Palavras.Remove(_db.Palavras.Find(Id));
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}