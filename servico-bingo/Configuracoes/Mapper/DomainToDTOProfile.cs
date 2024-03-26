
using AutoMapper;
using OrcamentoGenerico.Api.Dominio.Entite;


namespace OrcamentoGenerico.Api.Configuracoes
{
    public class DomainToDTOProfile : Profile
    {
        public DomainToDTOProfile()
        {
            //CreateMap<Empresa, EmpresaDto>().ReverseMap();
            //CreateMap<Colaborador, ColaboradorDto>().ReverseMap();
            //CreateMap<CategoriaItem, CategoriaItemDto>().ReverseMap();
            //CreateMap<Item, ItemDto>().ReverseMap();

            //CreateMap<CategoriaProduto, CategoriaProdutoDto>().ReverseMap();
            //CreateMap<ProdutoItemDimencao, ItemProdutoDto>().ReverseMap();
            //CreateMap<Produto, ProdutoDto>().ReverseMap();

            /* .ForMember("", opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Telefone))
             .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
             .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));*/
            //CreateMap<List<Empresa>, List<EmpresaDto>>();

        }
    }
}