using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VendasBack.Models
{
    public class Vendedor
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "O campo Nome tem que ter no maximo 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        public string Cnpj { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "O campo Endereço deve ter no maximo 100 caracteres")]
        public string EnderecoFilial { get; set; }
        public bool IsDeleted { get; set; } = false;
        [JsonIgnore]
        public virtual Produto Produto { get; set; }
    }
}
