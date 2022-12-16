using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasBack.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public bool IsCanceled { get; set; }

    }
}
