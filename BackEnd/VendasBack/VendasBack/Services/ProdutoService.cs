using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VendasBack.Data;
using VendasBack.Data.Dtos.ProdutosDTO;
using VendasBack.Models;

namespace VendasBack.Services
{
    public class ProdutoService
    {
        private VendaContext _context;
        private IMapper _mapper;

        public ProdutoService(VendaContext context, IMapper mapper)
        {
            _context= context;
            _mapper= mapper;
        }

        public IEnumerable<ReadProdutoDTO> GetAllProdutos()
        {
            //O Where é pra caso tenha algum produto em que o vendedor se deletou ele n ser exibido
            IEnumerable<Produto> p = _context.Produtos.Where(x => x.Vendedor.IsDeleted == false).ToList();
            return _mapper.Map<IEnumerable<ReadProdutoDTO>>(p);
        }

        
        public ReadProdutoDTO GetProdutoById(int id)
        {
            Produto p = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
            return p == null ? null : _mapper.Map<ReadProdutoDTO>(p);
        }
        
        public ReadProdutoDTO CreatedProduto(CreateProdutoDTO createProduto)
        {
            Produto prod = _context.Produtos.FirstOrDefault(produto => produto.VendedorId == createProduto.VendedorId);
            Vendedor v = _context.Vendendores.FirstOrDefault(x => x.Id == createProduto.VendedorId);
            if (prod != null || v == null || v.IsDeleted == true)
            {
                //Caso tenha um produto ja cadastrado com o vendedor do produto que está sendo cadastrado
                //caso o id do vendedor n exista ou o vendedor tenha deletado a conta
                return null;
            }
            Produto p = _mapper.Map<Produto>(createProduto);
            _context.Produtos.Add(p);
            _context.SaveChanges();
            return _mapper.Map<ReadProdutoDTO>(p);            
        }

        public Result UpdateProduto(int id, UpdateProdutoDTO updateProduto)
        {
            Produto produto = _context.Produtos.FirstOrDefault(x => x.Id == id);
            if (produto == null)
            {
                return Result.Fail(errorMessage: "Produto não encontrado");
            }
            _mapper.Map(updateProduto, produto);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteProduto(int id)
        {
            Produto p = _context.Produtos.FirstOrDefault(x => x.Id == id);
            if (p == null) //caso o id informado n seja valido vai retornar nulo
            {
                return Result.Fail(errorMessage: "Produto não encontrado");
            }
            if (p.Vendas.Count > 0) //Caso o produto ja tenha uma venda
            {
                return Result.Fail(errorMessage: "Não é possivel deletar um produto que ja tenha sido vendido");
            }
            _context.Remove(p);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
