using Microsoft.EntityFrameworkCore;
using NetCore.Dados.Contexto;
using NetCore.Dados.Repositorios.Interfaces;
using NetCore.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;


namespace NetCore.Dados.Repositorios
{
    public class ClienteRepositorio : Repositorio<Cliente> , IClienteRepositorio
    {
        public ClienteRepositorio(ContextoDB contexto) : base(contexto)
        {
        }

        public Cliente ObterClienteComCategoria(int id)
        {
            return Contexto.Clientes.Include(x => x.Categoria).Where(x=> x.Id == id).AsNoTracking().FirstOrDefault();
        }

        public IEnumerable<Cliente> ObterClientesComCategorias()
        {
            return Contexto.Clientes.Include(x => x.Categoria).AsNoTracking().AsEnumerable();
        }
    }
}
