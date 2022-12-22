using AutoMapper;
using VendasBack.Data.Dtos.VendasDTO;
using VendasBack.Models;

namespace VendasBack.Profiles
{
    public class VendasProfile : Profile
    {
        public VendasProfile()
        {
            CreateMap<Venda, ReadVendaDTO>();
            CreateMap<CreateVendaDTO, Venda>();
        }
    }
}
