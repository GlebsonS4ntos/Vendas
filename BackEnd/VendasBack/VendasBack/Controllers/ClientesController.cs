using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VendasBack.Data;
using VendasBack.Models;

namespace VendasBack.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClientesController : ControllerBase
    {
        private VendaContext _context;

        public ClientesController(VendaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllClientes()
        {
            return Ok(_context.Clientes.Where(x => x.IsDeleted == false).ToList());
            //O Where é pra caso tenha algum Cliente deletado n ser exibido
        }

        [HttpGet("{id}")]
        public IActionResult GetClienteById(int id)
        {
            Cliente c = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (c == null || c.IsDeleted == true)
            {
                return NotFound();
            }
            return Ok(c);
        }
        [HttpPost]
        public IActionResult CreatedCliente([FromBody] Cliente c)
        {                    
            _context.Clientes.Add(c);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetClienteById), new { c.Id }, c);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, [FromBody] Cliente c)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            cliente.Nome = c.Nome;
            cliente.Email = c.Email;
            cliente.Telefone = c.Telefone;

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
