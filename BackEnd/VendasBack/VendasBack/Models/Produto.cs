using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VendasBack.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preço { get; set; }
        public int Quantidade { get; set; }
        public string LinkImagem { get; set; }
        public int VendedorId { get; set; }
        public Vendedor Vedendor { get; set; }
        [JsonIgnore]
        public ICollection<Venda> Vendas { get; set; }
    }
}
