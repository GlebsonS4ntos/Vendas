using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VendasBack.Data;
using VendasBack.Data.Dtos.VendasDTO;
using VendasBack.Models;

namespace VendasBack.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class VendasController : ControllerBase
    {

        private VendaContext _context;
        private IMapper _mapper;

        public VendasController(VendaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllVendas()
        {
            IEnumerable<Venda> vendas = _context.Venda.Where(x => x.IsCanceled == false).ToList();
            IEnumerable<ReadVendaDTO> readVendas = _mapper.Map<IEnumerable<ReadVendaDTO>>(vendas);
            return Ok(readVendas);
        }

        [HttpGet("{id}")]
        public IActionResult GetVendaById(int id)
        {
            Venda v = _context.Venda.FirstOrDefault(venda => venda.Id == id);
            if (v == null)
            {
                return NotFound();
            }
            ReadVendaDTO readVenda = _mapper.Map<ReadVendaDTO>(v);
            return Ok(readVenda);
        }
        [HttpPost]
        public IActionResult CreatedVenda([FromBody] CreateVendaDTO createVenda)
        {
            Produto p = _context.Produtos.FirstOrDefault(produtos => produtos.Id == createVenda.ProdutoId);
            if (p == null || p.Quantidade - createVenda.Quantidade < 0 || p.Vendedor.IsDeleted == true)
            {
                //caso o produto n exista
                //caso a quantidade de produtos da venda seja maior que a quantidade de produtos ele ficaria negativo o que n pode acontecer
                //caso o Vendedor do produto tenha se desligado, e de alguma forma conseguiu fazer a compra de um produto que n aparece
                return BadRequest();
            }
            p.Quantidade -= createVenda.Quantidade; //decremento
            Venda v = _mapper.Map<Venda>(createVenda);
            _context.Venda.Add(v);
            _context.SaveChanges();
            ReadVendaDTO readVenda = _mapper.Map<ReadVendaDTO>(v);
            return CreatedAtAction(nameof(GetVendaById), new { readVenda.Id }, readVenda);
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
