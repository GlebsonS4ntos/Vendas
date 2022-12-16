using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasBack.Data;
using VendasBack.Models;

namespace VendasBack.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProdutosController : ControllerBase
    {
        private VendaContext _context;

        public ProdutosController(VendaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllProdutos()
        {
            return Ok(_context.Produtos.Where(x => x.Vendedor.IsDeleted == false).ToList());
            //O Where é pra caso tenha algum produto em que o vendedor se deletou ele n ser exibido
        }

        [HttpGet("{id}")]
        public IActionResult GetProdutoById(int id)
        {
            Produto p = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p); 
        }
        [HttpPost]
        public IActionResult CreatedProduto([FromBody] Produto p)
        {
            Produto prod = _context.Produtos.FirstOrDefault(produto => produto.VendedorId == p.VendedorId);
            if (prod != null) //Caso tenha um produto ja cadastrado com o vendedor do produto que está sendo cadastrado
            {
                return BadRequest();
            }
            Vendedor v = _context.Vendendores.FirstOrDefault(x => x.Id == p.Id);
            if (v == null || v.IsDeleted == true) //caso o id do vendedor n exista ou o vendedor tenha deletado a conta
            {
                return BadRequest();
            }
            _context.Produtos.Add(p);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProdutoById), new { p.Id }, p);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduto(int id, [FromBody] Produto p)
        {
            Produto produto = _context.Produtos.FirstOrDefault(x => x.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            produto.Nome = p.Nome;
            produto.Preco = p.Preco;
            produto.Quantidade = p.Quantidade;
            produto.LinkImagem = p.LinkImagem;
            produto.Descricao = p.Descricao;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(int id)
        {
            Produto p = _context.Produtos.FirstOrDefault(x => x.Id == id);
            if (p == null) //caso o id informado n seja valido vai retornar nulo
            {
                return NotFound();
            }
            if (p.Vendas.Count > 0) //Caso o produto ja tenha uma venda
            {
                return BadRequest();
            }
            _context.Remove(p);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
