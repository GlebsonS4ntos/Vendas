using System.Collections.Generic;
using System.Text.Json.Serialization;
using VendasBack.Models;

namespace VendasBack.Data.Dtos.ProdutosDTO
{
    public class ReadProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public string LinkImagem { get; set; }
        public Vendedor Vendedor { get; set; }
    }
}
