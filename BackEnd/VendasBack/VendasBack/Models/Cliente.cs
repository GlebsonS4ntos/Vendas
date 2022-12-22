using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VendasBack.Models
{
    public class Cliente
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "O campo nome não pode ter mais que 100 caracteres ")]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Email { get; set; }
        public bool IsDeleted { get; set; } = false;
        [JsonIgnore]
        public virtual ICollection<Venda> Vendas { get; set; }
    }
}
