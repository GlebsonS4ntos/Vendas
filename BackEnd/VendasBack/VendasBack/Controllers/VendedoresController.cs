using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasBack.Data;
using VendasBack.Data.Dtos.VendedoresDTO;
using VendasBack.Models;
using VendasBack.Services;

namespace VendasBack.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class VendedoresController : ControllerBase
    {
        private VendedorService _service;

        public VendedoresController(VendedorService service)
        {
            _service= service;  
        }

        [HttpGet]
        public IActionResult GetAllVendedores()
        {
            return Ok(_service.GetAllVendedores());
        }

        [HttpGet("{id}")]
        public IActionResult GetVendedorById(int id)
        {
            ReadVendedorDTO readVendedor = _service.GetVendedorById(id);
            return readVendedor == null? NotFound() : Ok(readVendedor); 
        }

        [HttpPost]
        public IActionResult CreatedVendedor([FromBody] CreateVendedorDTO createVendedor)
        {
            ReadVendedorDTO readVendedor = _service.CreatedVendedor(createVendedor);
            return CreatedAtAction(nameof(GetVendedorById), new { readVendedor.Id }, readVendedor);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVendendor(int id, [FromBody] UpdateVendedorDTO updateVendedor)
        {
            Result resultadoUpdate = _service.UpdateVendendor(id, updateVendedor);
            return resultadoUpdate.IsFailed? NotFound(resultadoUpdate.Errors.First()) : NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLogicoVendedor(int id)
        {
            Result resultadoDelete = _service.DeleteLogicoVendedor(id);
            return resultadoDelete.IsFailed? NotFound(resultadoDelete.Errors.First()) : NoContent();
        }

    }
}
