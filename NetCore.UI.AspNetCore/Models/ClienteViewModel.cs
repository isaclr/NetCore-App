using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.UI.AspNetCore.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        [MaxLength(125, ErrorMessage = "O comprimento do campo {0} é no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        [MaxLength(125, ErrorMessage = "O comprimento do campo {0} é no máximo {1} caracteres.")]
        public string Email { get; set; }

        [DisplayName("númerno do CNPJ")]        
        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        [DisplayFormat(DataFormatString ="{0:##.###.###/####-##}")]
        [MaxLength(14, ErrorMessage ="O comprimento do campo {0} é no máximo {1} caracteres.")]
        public string CNPJ{ get; set; }

        [MaxLength(10, ErrorMessage = "O comprimento do campo {0} é no máximo {1} caracteres.")]
        public string CEP { get; set; }

        [MaxLength(255, ErrorMessage = "O comprimento do campo {0} é no máximo {1} caracteres.")]
        public string Rua { get; set; }
        
        public int? Numero { get; set; }

        [MaxLength(50, ErrorMessage = "O comprimento do campo {0} é no máximo {1} caracteres.")]
        public string Complemento { get; set; }

        [MaxLength(100, ErrorMessage = "O comprimento do campo {0} é no máximo {1} caracteres.")]
        public string Cidade { get; set; }

        [MaxLength(50, ErrorMessage = "O comprimento do campo {0} é no máximo {1} caracteres.")]
        public string Estado { get; set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        public int? CategoriaId { get; set; }

        [DisplayName("Categoria")]        
        public string DescricaoCategoria { get; set; }

        public IEnumerable<CategoriaViewModel> OpcoesCategorias { get; set; }
    }
}
