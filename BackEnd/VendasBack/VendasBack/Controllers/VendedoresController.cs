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
    public class VendedoresController : ControllerBase
    {
        private VendaContext _context;

        public VendedoresController(VendaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllVendedores()
        {
            return Ok(_context.Vendendores.Where(x => x.IsDeleted == false).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetVendedorById(int id)
        {
            Vendedor v = _context.Vendendores.FirstOrDefault(vend => vend.Id == id);
            if (v == null || v.IsDeleted == true)
            {
                return NotFound();
            }
            return Ok(v); 
        }

        [HttpPost]
        public IActionResult CreatedVendedor([FromBody] Vendedor v)
        {
            _context.Vendendores.Add(v);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetVendedorById), new { v.Id }, v);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVendendor(int id, [FromBody] Vendedor v)
        {
            Vendedor vendedor = _context.Vendendores.FirstOrDefault(x =>x.Id == id);
            if (vendedor == null || vendedor.IsDeleted == true)
            {
                return NotFound();
            }
            vendedor.Nome = v.Nome;
            vendedor.Cnpj = v.Cnpj;
            vendedor.EnderecoFilial = v.EnderecoFilial;

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLogicoVendedor(int id)
        {
            Vendedor v = _context.Vendendores.FirstOrDefault(x => x.Id == id);
            if (v == null || v.IsDeleted == true)
            {
                return NotFound();
            }
            v.IsDeleted = true;
            _context.SaveChanges();
            return Ok();
        }

    }
}
