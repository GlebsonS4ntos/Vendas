using System.ComponentModel.DataAnnotations;
using VendasBack.Models;

namespace VendasBack.Data.Dtos.VendedoresDTO
{
    public class CreateVendedorDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "O campo Nome tem que ter no maximo 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        public string Cnpj { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "O campo Endereço deve ter no maximo 100 caracteres")]
        public string EnderecoFilial { get; set; }
    }
}
