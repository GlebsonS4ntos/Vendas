using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VendasBack.Models;

namespace VendasBack.Data.Dtos.ProdutosDTO
{
    public class UpdateProdutoDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "O Campo Nome n pode ter mais que 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "O Campo Descricao n pode ter mais que 500 caracteres")]
        public string Descricao { get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        public double Preco { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Quantidade { get; set; }
        [Required]
        public string LinkImagem { get; set; }
    }
}
