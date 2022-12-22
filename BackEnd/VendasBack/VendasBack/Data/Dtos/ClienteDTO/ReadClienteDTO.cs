using System.ComponentModel.DataAnnotations;

namespace VendasBack.Data.Dtos.ClienteDTO
{
    public class ReadClienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
