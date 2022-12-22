using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VendasBack.Models
{
    public class Venda
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        [Required]
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        [Required]
        public int Quantidade { get; set; }
        public bool IsCanceled { get; set; } = false;

    }
}
