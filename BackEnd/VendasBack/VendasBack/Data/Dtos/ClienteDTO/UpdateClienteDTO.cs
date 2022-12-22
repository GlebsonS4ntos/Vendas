using System.ComponentModel.DataAnnotations;

namespace VendasBack.Data.Dtos.ClienteDTO
{
    public class UpdateClienteDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "O campo nome não pode ter mais que 100 caracteres ")]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
