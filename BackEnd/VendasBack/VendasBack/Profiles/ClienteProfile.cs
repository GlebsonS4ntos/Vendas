using AutoMapper;
using VendasBack.Data.Dtos.ClienteDTO;
using VendasBack.Models;

namespace VendasBack.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile() 
        {
            CreateMap<CreateClienteDTO, Cliente>();
            CreateMap<Cliente, ReadClienteDTO>();
            CreateMap<UpdateClienteDTO, Cliente>();
        }
    }
}
