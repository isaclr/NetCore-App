using System.Collections.Generic;

namespace NetCore.Dominio.Entidades
{
    public class Categoria
    {
        public Categoria()
        {

        }

        public int Id { get; set; }

        public string NomeCategoria { get; set; }

        ICollection<Cliente> Clientes { get; set; }
    }
}