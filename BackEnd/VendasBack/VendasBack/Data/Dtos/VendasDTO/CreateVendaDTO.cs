using System.ComponentModel.DataAnnotations;
using VendasBack.Models;

namespace VendasBack.Data.Dtos.VendasDTO
{
    public class CreateVendaDTO
    {
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int ProdutoId { get; set; }
        [Required]
        public int Quantidade { get; set; }
    }
}
