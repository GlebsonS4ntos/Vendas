using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VendasBack.Models;

namespace VendasBack.Data.Dtos.VendedoresDTO
{
    public class ReadVendedorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string EnderecoFilial { get; set; }
        public bool IsDeleted { get; set; } = false;
        [JsonIgnore]
        public virtual Produto Produto { get; set; }
    }
}
