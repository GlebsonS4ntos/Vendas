using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VendasBack.Data;
using VendasBack.Data.Dtos.ClienteDTO;
using VendasBack.Models;
using VendasBack.Services;

namespace VendasBack.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClientesController : ControllerBase
    {
        private ClienteService _service;

        public ClientesController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllClientes()
        {
            return Ok(_service.GetAllClientes());
        }

        [HttpGet("{id}")]
        public IActionResult GetClienteById(int id)
        {
            ReadClienteDTO readCliente = _service.GetClienteById(id);
            if (readCliente == null)
            {
                return NotFound();
            }
            return Ok(readCliente);
        }
        [HttpPost]
        public IActionResult CreatedCliente([FromBody] CreateClienteDTO createCliente)
        {
            ReadClienteDTO readCliente = _service.CreatedCliente(createCliente);
            return CreatedAtAction(nameof(GetClienteById), new {readCliente.Id }, readCliente);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, [FromBody] UpdateClienteDTO updateCliente)
        {
            Result resultUpdate = _service.UpdateCliente(id, updateCliente);
            return resultUpdate.IsFailed ? NotFound(resultUpdate.Errors.First()) : NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            Result resultadoDelete = _service.DeleteCliente(id);
            return resultadoDelete.IsFailed ? NotFound(resultadoDelete.Errors.First()) : NoContent();
        }
    }
}
