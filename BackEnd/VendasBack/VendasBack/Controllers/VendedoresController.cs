using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasBack.Data;
using VendasBack.Data.Dtos.VendedoresDTO;
using VendasBack.Models;

namespace VendasBack.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class VendedoresController : ControllerBase
    {
        private VendaContext _context;
        private IMapper _mapper;

        public VendedoresController(VendaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllVendedores()
        {
            //O where é pra caso o vendedor tenha se deletado ele n vir 
            IEnumerable<Vendedor> vendedores= _context.Vendendores.Where(x => x.IsDeleted == false).ToList();
            IEnumerable<ReadVendedorDTO> readVendedores = _mapper.Map<IEnumerable<ReadVendedorDTO>>(vendedores);
            return Ok(readVendedores);
        }

        [HttpGet("{id}")]
        public IActionResult GetVendedorById(int id)
        {
            Vendedor v = _context.Vendendores.FirstOrDefault(vend => vend.Id == id);
            if (v == null || v.IsDeleted == true)
            {
                return NotFound();
            }
            ReadVendedorDTO readVendedor = _mapper.Map<ReadVendedorDTO>(v);
            return Ok(readVendedor); 
        }

        [HttpPost]
        public IActionResult CreatedVendedor([FromBody] CreateVendedorDTO createVendedor)
        {
            Vendedor v = _mapper.Map<Vendedor>(createVendedor);
            _context.Vendendores.Add(v);
            _context.SaveChanges();
            ReadVendedorDTO readVendedor = _mapper.Map<ReadVendedorDTO>(v);
            return CreatedAtAction(nameof(GetVendedorById), new { readVendedor.Id }, readVendedor);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVendendor(int id, [FromBody] UpdateVendedorDTO updateVendedor)
        {
            Vendedor vendedor = _context.Vendendores.FirstOrDefault(x =>x.Id == id);
            if (vendedor == null || vendedor.IsDeleted == true)
            {
                return NotFound();
            }
            _mapper.Map(updateVendedor, vendedor);
            _context.SaveChanges();
            return NoContent();
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
            return NoContent();
        }

    }
}
