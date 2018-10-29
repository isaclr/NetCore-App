using NetCore.Dados.Contexto;
using NetCore.Dados.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Dados.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected ContextoDB Contexto;

        public Repositorio(ContextoDB contexto)
        {
            Contexto = contexto;
        }

        public void Adicionar(T entidade)
        {
            Contexto.Add(entidade);
        }

        public void Alterar(T entidade)
        {
            Contexto.Entry(entidade).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public T ObterPorId(int id)
        {
            return Contexto.Find<T>(id);
        }


        public IEnumerable<T> ObterTodos()
        {
            return Contexto.Set<T>();            
        }

        public void Remover(int id)
        {
            Contexto.Remove(this.ObterPorId(id));
        }
    }
}
