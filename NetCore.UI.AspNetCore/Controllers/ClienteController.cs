using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.Dados.Repositorios;
using NetCore.Dados.Repositorios.Interfaces;
using NetCore.Dados.UnitOfWork.Interfaces;
using NetCore.Dominio.Entidades;
using NetCore.UI.AspNetCore.Models;

namespace NetCore.UI.AspNetCore.Controllers
{
    public class ClienteController : Controller
    {
        //private IRepositorio<Cliente> Repositorio;        
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IRepositorio<Categoria> _categoriaRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public ClienteController(IClienteRepositorio clienteRepositorio, IRepositorio<Categoria> categoriaRepositorio, IUnitOfWork unitOfWork)
        {
            _clienteRepositorio = clienteRepositorio;
            _categoriaRepositorio = categoriaRepositorio;
            _unitOfWork = unitOfWork;
        }

        // GET: Cliente
        public ActionResult Index()
        {
            return View(MapearClienteViewModel(_clienteRepositorio.ObterClientesComCategorias()));
        }

        private IEnumerable<ClienteViewModel> MapearClienteViewModel(IEnumerable<Cliente> clientes)
        {
            var clientesVM = new List<ClienteViewModel>();

            foreach (var cliente in clientes)
            {
                clientesVM.Add(MapearEntidadeClienteParaViewModel(cliente));
            }

            return clientesVM;
        }

        private static ClienteViewModel MapearEntidadeClienteParaViewModel(Cliente cliente)
        {
            return new ClienteViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                CNPJ = cliente.CNPJ,
                CEP = cliente.Cep,
                Rua = cliente.Rua,
                Numero = cliente.Numero,
                Complemento = cliente.Complemento,
                Cidade = cliente.Cidade,
                Estado = cliente.Estado,
                CategoriaId = cliente.Categoria.Id,
                DescricaoCategoria = cliente.Categoria.NomeCategoria
            };
        }

        private Cliente MapearClienteViewModelParaEntidade(ClienteViewModel cliente)
        {
            var clienteDominio = new Cliente
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                CNPJ = cliente.CNPJ,
                Cep = cliente.CEP,
                Rua = cliente.Rua,
                Numero = cliente.Numero,
                Complemento = cliente.Complemento,
                Cidade = cliente.Cidade,
                Estado = cliente.Estado,
                CategoriaId = cliente.CategoriaId.Value
            };

            return clienteDominio;
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View(MapearEntidadeClienteParaViewModel(_clienteRepositorio.ObterClienteComCategoria(id)));
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            DefineViewBagCategoria();
            return View();
        }

        private void DefineViewBagCategoria()
        {
            ViewBag.SelectCategorias = _categoriaRepositorio.ObterTodos().Select(x => new { Value = x.Id, Text = x.NomeCategoria });
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteVM)
        {
            try
            {                
                var objCliente = MapearClienteViewModelParaEntidade(clienteVM);
                _clienteRepositorio.Adicionar(objCliente);
                _unitOfWork.Confirmar();

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                DefineViewBagCategoria();
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            DefineViewBagCategoria();
            return View(MapearEntidadeClienteParaViewModel(_clienteRepositorio.ObterClienteComCategoria(id)));
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClienteViewModel clienteVM)
        {
            try
            {
                var objCliente = MapearClienteViewModelParaEntidade(clienteVM);
                _clienteRepositorio.Alterar(objCliente);
                _unitOfWork.Confirmar();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                DefineViewBagCategoria();
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View(MapearEntidadeClienteParaViewModel(_clienteRepositorio.ObterClienteComCategoria(id)));
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _clienteRepositorio.Remover(id);
                _unitOfWork.Confirmar();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
};