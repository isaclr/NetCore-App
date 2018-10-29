using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Dominio.Entidades
{
    /// <summary>
    /// Entidade Principal
    /// </summary>
    public class Cliente
    {
        public Cliente()
        {

        }

        public int    Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string CNPJ { get; set; }

        public string Cep { get; set; }

        public string Rua { get; set; }

        public int?    Numero { get; set; }

        public string Complemento { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }


        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
