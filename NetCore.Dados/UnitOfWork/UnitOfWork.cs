using NetCore.Dados.Repositorios.Interfaces;
using NetCore.Dados.UnitOfWork.Interfaces;
using NetCore.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Dados.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Contexto.ContextoDB contexto;
        IRepositorio<Categoria> repositorioCategoria;
        IRepositorio<Cliente> repositorioCliente;

        public UnitOfWork(Contexto.ContextoDB contexto)
        {
            this.contexto = contexto;

            this.repositorioCategoria = new Repositorios.Repositorio<Categoria>(contexto);
            this.repositorioCliente = new Repositorios.Repositorio<Cliente>(contexto);
        }

        public void Confirmar()
        {
            this.contexto.SaveChanges();
        }

        public void Dispose()
        {
            this.contexto.Dispose();
        }
    }
}
