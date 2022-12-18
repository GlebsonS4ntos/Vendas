using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VendasBack.Data;
using VendasBack.Models;

namespace VendasBack.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class VendasController : ControllerBase
    {

        private VendaContext _context;

        public VendasController(VendaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllVendas()
        {
            return Ok(_context.Venda.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetVendaById(int id)
        {
            Venda v = _context.Venda.FirstOrDefault(venda => venda.Id == id);
            if (v == null)
            {
                return NotFound();
            }
            return Ok(v);
        }
        [HttpPost]
        public IActionResult CreatedVenda([FromBody] Venda v)
        {
            _context.Venda.Add(v);
            Produto p = _context.Produtos.FirstOrDefault(produtos => produtos.Id == v.ProdutoId);
            p.Quantidade -= v.Quantidade; //Decremento da quantidade de Produtos de acordo com a quantidade vendida
            if (p == null || p.Quantidade < 0 || p.Vendedor.IsDeleted == true)
            {
                //caso o produto n exista
                //caso a quantidade de produtos da venda seja maior que a quantidade de produtos ele ficaria negativo o que n pode acontecer
                //caso o Vendedor do produto tenha se desligado, e de alguma forma conseguiu fazer a compra de um produto que n aparece
                return BadRequest();
            }
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetVendaById), new { v.Id }, v);
        }

        [HttpDelete("{id}")]
        public  IActionResult CancelarVenda(int id)
        {
            Venda v = _context.Venda.FirstOrDefault(x => x.Id == id);
            if (v == null)
            {
                return NotFound();
            }
            Produto p = _context.Produtos.FirstOrDefault(x => x.Id == v.ProdutoId);
            p.Quantidade += v.Quantidade; //adicionando novamente a quantidade do produto que seria retirada na venda
            _context.SaveChanges();
            return NoContent();
        }
    }
}
