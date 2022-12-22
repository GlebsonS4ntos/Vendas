using System.ComponentModel.DataAnnotations;
using VendasBack.Models;

namespace VendasBack.Data.Dtos.VendasDTO
{
    public class ReadVendaDTO
    { 
        public int Id { get; set; }   
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }   
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public bool IsCanceled { get; set; } = false;
    }
}
