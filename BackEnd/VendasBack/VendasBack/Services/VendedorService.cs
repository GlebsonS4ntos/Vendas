using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VendasBack.Data;
using VendasBack.Data.Dtos.VendedoresDTO;
using VendasBack.Models;

namespace VendasBack.Services
{
    public class VendedorService
    {
        private VendaContext _context;
        private IMapper _mapper;

        public VendedorService(VendaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ReadVendedorDTO> GetAllVendedores()
        {
            IEnumerable<Vendedor> vendedores = _context.Vendendores.Where(x => x.IsDeleted == false).ToList();
            return _mapper.Map<IEnumerable<ReadVendedorDTO>>(vendedores);
        }

        public ReadVendedorDTO GetVendedorById(int id)
        {
            Vendedor v = _context.Vendendores.FirstOrDefault(vend => vend.Id == id);
            if (v == null || v.IsDeleted == true)
            {
                return null;
            }
            return _mapper.Map<ReadVendedorDTO>(v);
        }

        public ReadVendedorDTO CreatedVendedor(CreateVendedorDTO createVendedor)
        {
            Vendedor v = _mapper.Map<Vendedor>(createVendedor);
            _context.Vendendores.Add(v);
            _context.SaveChanges();
            return _mapper.Map<ReadVendedorDTO>(v);
        }

        public Result UpdateVendendor(int id, UpdateVendedorDTO updateVendedor)
        {
            Vendedor vendedor = _context.Vendendores.FirstOrDefault(x => x.Id == id);
            if (vendedor == null || vendedor.IsDeleted == true)
            {
                return Result.Fail(errorMessage: "O vendedor n existe ou já foi excluido");
            }
            _mapper.Map(updateVendedor, vendedor);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteLogicoVendedor(int id)
        {
            Vendedor v = _context.Vendendores.FirstOrDefault(x => x.Id == id);
            if (v == null || v.IsDeleted == true)
            {
                return Result.Fail(errorMessage: "O vendedor n existe ou já foi excluido");
            }
            v.IsDeleted = true;
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
