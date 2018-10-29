using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.UI.AspNetCore.Models
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Descrição da Categoria")]
        [MaxLength(255, ErrorMessage = "O comprimento do campo {0} é no máximo {1} caracteres.")]
        public string Nome { get; set; }
    }
}
