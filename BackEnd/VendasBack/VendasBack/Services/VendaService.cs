using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VendasBack.Data;
using VendasBack.Data.Dtos.VendasDTO;
using VendasBack.Models;

namespace VendasBack.Services
{
    public class VendaService
    {
        private VendaContext _context;
        private IMapper _mapper;

        public VendaService(VendaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public IEnumerable<ReadVendaDTO> GetAllVendas()
        {
            IEnumerable<Venda> vendas = _context.Venda.Where(x => x.IsCanceled == false).ToList();
            return _mapper.Map<IEnumerable<ReadVendaDTO>>(vendas);  
        }

        public ReadVendaDTO GetVendaById(int id)
        {
            Venda v = _context.Venda.FirstOrDefault(venda => venda.Id == id);
            if (v == null)
            {
                return null;
            }
            return _mapper.Map<ReadVendaDTO>(v); 
        }
        
        public ReadVendaDTO CreatedVenda(CreateVendaDTO createVenda)
        {
            Produto p = _context.Produtos.FirstOrDefault(produtos => produtos.Id == createVenda.ProdutoId);
            if (p == null || p.Quantidade - createVenda.Quantidade < 0 || p.Vendedor.IsDeleted == true)
            {
                //caso o produto n exista
                //caso a quantidade de produtos da venda seja maior que a quantidade de produtos ele ficaria negativo o que n pode acontecer
                //caso o Vendedor do produto tenha se desligado, e de alguma forma conseguiu fazer a compra de um produto que n aparece
                return null;
            }
            p.Quantidade -= createVenda.Quantidade; //decremento
            Venda v = _mapper.Map<Venda>(createVenda);
            _context.Venda.Add(v);
            _context.SaveChanges();
            return _mapper.Map<ReadVendaDTO>(v);
            
        }

        public Result CancelarVenda(int id)
        {
            Venda v = _context.Venda.FirstOrDefault(x => x.Id == id);
            if (v == null)
            {
                return Result.Fail("Venda n encontrada");
            }
            Produto p = _context.Produtos.FirstOrDefault(x => x.Id == v.ProdutoId);
            p.Quantidade += v.Quantidade; //adicionando novamente a quantidade do produto que seria retirada na venda
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
