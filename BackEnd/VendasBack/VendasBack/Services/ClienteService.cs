using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VendasBack.Data;
using VendasBack.Data.Dtos.ClienteDTO;
using VendasBack.Models;

namespace VendasBack.Services
{
    public class ClienteService
    {
        private VendaContext _context;
        private IMapper _mapper;

        public ClienteService(VendaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ReadClienteDTO> GetAllClientes()
        {
            //O Where é pra caso tenha algum Cliente deletado n ser exibido
            IEnumerable<Cliente> clientes = _context.Clientes.Where(x => x.IsDeleted == false).ToList();
            return _mapper.Map<IEnumerable<ReadClienteDTO>>(clientes);
        }

        public ReadClienteDTO GetClienteById(int id)
        {
            Cliente c = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (c == null || c.IsDeleted == true)
            {
                return null;
            }
            return _mapper.Map<ReadClienteDTO>(c);    
        }

        public ReadClienteDTO CreatedCliente(CreateClienteDTO createCliente)
        {
            Cliente c = _mapper.Map<Cliente>(createCliente);
            _context.Clientes.Add(c);
            _context.SaveChanges();
            return _mapper.Map<ReadClienteDTO>(c);   
        }

        public Result UpdateCliente(int id, UpdateClienteDTO updateCliente)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);
            if (cliente == null)
            {
                return Result.Fail(errorMessage: "Cliente não encontrado");
            }
            _mapper.Map(updateCliente, cliente);

            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteCliente(int id)
        {
            Cliente c = _context.Clientes.FirstOrDefault(x => x.Id == id);
            if (c == null || c.IsDeleted == true)
            {
                return Result.Fail(errorMessage: "O Cliente n existe ou ja foi excluido!");
            }
            c.IsDeleted = true;
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
