using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetCore.Dados.Repositorios.Interfaces
{
    public interface IRepositorio<T> where T : class
    {

        T ObterPorId(int id);
        IEnumerable<T> ObterTodos();

        void Adicionar(T entidade);
        void Remover(int id);
        void Alterar(T entidade);

    }
}