using NetCore.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Dados.Repositorios.Interfaces
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        IEnumerable<Cliente> ObterClientesComCategorias();

        Cliente ObterClienteComCategoria(int id);
    }
}
