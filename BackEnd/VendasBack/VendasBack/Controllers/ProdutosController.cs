using AutoMapper;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasBack.Data;
using VendasBack.Data.Dtos.ProdutosDTO;
using VendasBack.Models;
using VendasBack.Services;

namespace VendasBack.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProdutosController : ControllerBase
    {
        private ProdutoService _service;
        
        public ProdutosController(ProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllProdutos()
        {
            return Ok(_service.GetAllProdutos());
        }

        [HttpGet("{id}")]
        public IActionResult GetProdutoById(int id)
        {
            ReadProdutoDTO readProduto = _service.GetProdutoById(id); 
            return readProduto == null? NotFound() : Ok(readProduto); 
        }
        [HttpPost]
        public IActionResult CreatedProduto([FromBody] CreateProdutoDTO createProduto)
        {
            ReadProdutoDTO readProdutoDTO = _service.CreatedProduto(createProduto);
            return readProdutoDTO == null? BadRequest() : CreatedAtAction(nameof(GetProdutoById), new { readProdutoDTO.Id }, readProdutoDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduto(int id, [FromBody] UpdateProdutoDTO updateProduto )
        {
            Result resultadoUpdate = _service.UpdateProduto(id, updateProduto);
            return resultadoUpdate.IsFailed? NotFound(resultadoUpdate.Errors.First()) : NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(int id)
        {
            Result resultadoDelete = _service.DeleteProduto(id);
            return resultadoDelete.IsFailed? BadRequest(resultadoDelete.Errors.First()) : NoContent();
        }
    }
}
