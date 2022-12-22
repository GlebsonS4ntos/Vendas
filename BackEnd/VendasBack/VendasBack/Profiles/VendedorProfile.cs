using AutoMapper;
using VendasBack.Data.Dtos.VendedoresDTO;
using VendasBack.Models;

namespace VendasBack.Profiles
{
    public class VendedorProfile : Profile
    {
        public VendedorProfile() 
        {
            CreateMap<Vendedor, ReadVendedorDTO>();
            CreateMap<CreateVendedorDTO, Vendedor>();
            CreateMap<UpdateVendedorDTO, Vendedor>();
        }
    }
}
