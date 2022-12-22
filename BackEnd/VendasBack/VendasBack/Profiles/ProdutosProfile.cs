using AutoMapper;
using VendasBack.Data.Dtos.ProdutosDTO;
using VendasBack.Models;

namespace VendasBack.Profiles
{
    public class ProdutosProfile : Profile
    {
        public ProdutosProfile()
        {
            CreateMap<CreateProdutoDTO, Produto>();
            CreateMap<Produto, ReadProdutoDTO>();
            CreateMap<UpdateProdutoDTO, Produto>();
        }
    }
}
