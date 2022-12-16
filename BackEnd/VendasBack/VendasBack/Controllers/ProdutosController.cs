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
            return Ok(_context.Produtos.ToList());
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

    }
}
