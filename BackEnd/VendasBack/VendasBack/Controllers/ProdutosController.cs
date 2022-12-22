using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasBack.Data;
using VendasBack.Data.Dtos.ProdutosDTO;
using VendasBack.Models;

namespace VendasBack.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProdutosController : ControllerBase
    {
        private VendaContext _context;
        private IMapper _mapper;

        public ProdutosController(VendaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProdutos()
        {
            //O Where é pra caso tenha algum produto em que o vendedor se deletou ele n ser exibido
            IEnumerable<Produto> p = _context.Produtos.Where(x => x.Vendedor.IsDeleted == false).ToList();
            IEnumerable<ReadProdutoDTO> readProdutos = _mapper.Map<IEnumerable<ReadProdutoDTO>>(p);
            return Ok(readProdutos);
        }

        [HttpGet("{id}")]
        public IActionResult GetProdutoById(int id)
        {
            Produto p = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
            if (p == null)
            {
                return NotFound();
            }
            ReadProdutoDTO readProduto = _mapper.Map<ReadProdutoDTO>(p);
            return Ok(readProduto); 
        }
        [HttpPost]
        public IActionResult CreatedProduto([FromBody] CreateProdutoDTO createProduto)
        {
            Produto prod = _context.Produtos.FirstOrDefault(produto => produto.VendedorId == createProduto.VendedorId);
            Vendedor v = _context.Vendendores.FirstOrDefault(x => x.Id == createProduto.VendedorId);
            if (prod != null || v == null || v.IsDeleted == true)
            {
                //Caso tenha um produto ja cadastrado com o vendedor do produto que está sendo cadastrado
                //caso o id do vendedor n exista ou o vendedor tenha deletado a conta
                return BadRequest();
            }
            Produto p =_mapper.Map<Produto>(createProduto);
            _context.Produtos.Add(p);
            _context.SaveChanges();
            ReadProdutoDTO readProduto = _mapper.Map<ReadProdutoDTO>(p);
            return CreatedAtAction(nameof(GetProdutoById), new { readProduto.Id }, readProduto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduto(int id, [FromBody] UpdateProdutoDTO updateProduto )
        {
            Produto produto = _context.Produtos.FirstOrDefault(x => x.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            _mapper.Map(updateProduto, produto);
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
