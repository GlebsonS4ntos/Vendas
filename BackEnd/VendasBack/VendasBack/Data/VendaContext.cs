using Microsoft.EntityFrameworkCore;
using VendasBack.Models;

namespace VendasBack.Data
{
    public class VendaContext : DbContext
    {
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vendedor> Vendendores { get; set; }

        public VendaContext(DbContextOptions<VendaContext> options) : base(options){}
    }
}
