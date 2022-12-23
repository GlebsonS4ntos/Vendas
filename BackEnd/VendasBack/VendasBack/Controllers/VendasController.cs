using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VendasBack.Data;
using VendasBack.Data.Dtos.VendasDTO;
using VendasBack.Models;
using VendasBack.Services;

namespace VendasBack.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class VendasController : ControllerBase
    {

        private VendaService _service;

        public VendasController(VendaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllVendas()
        {
            return Ok(_service.GetAllVendas());
        }

        [HttpGet("{id}")]
        public IActionResult GetVendaById(int id)
        {
            ReadVendaDTO readVenda = _service.GetVendaById(id);
            return readVenda == null? NotFound() : Ok(readVenda);
        }
        [HttpPost]
        public IActionResult CreatedVenda([FromBody] CreateVendaDTO createVenda)
        {
            ReadVendaDTO readVenda = _service.CreatedVenda(createVenda);
            return readVenda == null? BadRequest() : CreatedAtAction(nameof(GetVendaById), new { readVenda.Id }, readVenda);
        }

        [HttpDelete("{id}")]
        public  IActionResult CancelarVenda(int id)
        {
            Result resultadoDelete = _service.CancelarVenda(id);
            return resultadoDelete.IsFailed? NotFound() : NoContent();
        }
    }
}
