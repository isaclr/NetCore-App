using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.Dados.Contexto;
using NetCore.Dados.Repositorios.Interfaces;
using NetCore.Dados.UnitOfWork;
using NetCore.Dados.UnitOfWork.Interfaces;
using NetCore.Dominio.Entidades;
using NetCore.UI.AspNetCore.Models;

namespace NetCore.UI.AspNetCore.Controllers
{
    public class CategoriaController : Controller
    {
        private IRepositorio<Categoria> Repositorio;
        private readonly IUnitOfWork unitOfWork;

        public CategoriaController(IRepositorio<Categoria> repositorio, IUnitOfWork unitOfWork)
        {
            Repositorio = repositorio;
            this.unitOfWork = unitOfWork;
        }

        // GET: Categoria
        public ActionResult Index()
        {
            return View(this.Repositorio.ObterTodos().Select( x => new CategoriaViewModel { Id = x.Id, Nome=x.NomeCategoria }).ToList());
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View(new CategoriaViewModel { });
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaViewModel model)
        {
            try
            {                
                var entidade = new Categoria();
                entidade.NomeCategoria = model.Nome;
                Repositorio.Adicionar(entidade);
                unitOfWork.Confirmar();                                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            var categoria = Repositorio.ObterPorId(id);
            return View(new CategoriaViewModel { Id = categoria.Id, Nome = categoria.NomeCategoria });

            
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoriaViewModel model)
        {
            try
            {
                var entidade = new Categoria();
                entidade.Id = id;
                entidade.NomeCategoria = model.Nome;
                Repositorio.Alterar(entidade);
                unitOfWork.Confirmar();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            var categoria = Repositorio.ObterPorId(id);
            return View(new CategoriaViewModel { Id = categoria.Id, Nome = categoria.NomeCategoria });            
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Repositorio.Remover(id);
                unitOfWork.Confirmar();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}