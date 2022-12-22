using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VendasBack.Data;
using VendasBack.Data.Dtos.ClienteDTO;
using VendasBack.Models;

namespace VendasBack.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClientesController : ControllerBase
    {
        private VendaContext _context;
        private IMapper _mapper;

        public ClientesController(VendaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllClientes()
        {
            //O Where é pra caso tenha algum Cliente deletado n ser exibido
            IEnumerable<Cliente> clientes = _context.Clientes.Where(x => x.IsDeleted == false).ToList();
            IEnumerable<ReadClienteDTO> readClientes = _mapper.Map<IEnumerable<ReadClienteDTO>>(clientes);
            return Ok(readClientes);
           
        }

        [HttpGet("{id}")]
        public IActionResult GetClienteById(int id)
        {
            Cliente c = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (c == null || c.IsDeleted == true)
            {
                return NotFound();
            }
            ReadClienteDTO readCliente = _mapper.Map<ReadClienteDTO>(c);
            return Ok(readCliente);
        }
        [HttpPost]
        public IActionResult CreatedCliente([FromBody] CreateClienteDTO createCliente)
        {
            Cliente c = _mapper.Map<Cliente>(createCliente);
            _context.Clientes.Add(c);
            _context.SaveChanges();
            ReadClienteDTO readCliente = _mapper.Map<ReadClienteDTO>(c);
            return CreatedAtAction(nameof(GetClienteById), new { readCliente.Id }, readCliente);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, [FromBody] UpdateClienteDTO updateCliente)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            _mapper.Map(updateCliente, cliente);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            Cliente c = _context.Clientes.FirstOrDefault(x => x.Id == id);
            if (c  == null || c.IsDeleted == true)
            {
                return NotFound();
            }
            c.IsDeleted = true;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
