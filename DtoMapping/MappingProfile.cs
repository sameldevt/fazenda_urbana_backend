using AutoMapper;
using Model.Dtos;
using Model.Entities;

namespace DtoMapping
{
    public class MappingProfile : Profile
    { 
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDto>()
                .ForMember(dest => dest.Contato, opt => opt.MapFrom(src => new ContatoDto
                {
                    Telefone = src.Contato.Telefone,
                    Email = src.Contato.Email
                }))
                .ForMember(dest => dest.Enderecos, opt => opt.MapFrom(src => src.Enderecos.Select(e => new EnderecoDto
                {
                    Logradouro = e.Logradouro,
                    Numero = e.Numero,
                    Cidade = e.Cidade,
                    CEP = e.CEP,
                    Complemento = e.Complemento,
                    Estado = e.Estado
                })));

            CreateMap<CadastrarClienteDto, Cliente>()
                .ForMember(dest => dest.Contato, opt => opt.MapFrom(src => new Contato
                {
                    Telefone = src.Contato.Telefone,
                    Email = src.Contato.Email
                }))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Enderecos, opt => opt.MapFrom(src => src.Enderecos.Select(e => new Endereco
                {
                    Logradouro = e.Logradouro,
                    Numero = e.Numero,
                    Cidade = e.Cidade,
                    CEP = e.CEP,
                    Complemento = e.Complemento,
                    Estado = e.Estado
                })));

            CreateMap<CadastrarUsuarioDto, Cliente>()
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Contato, opt => opt.MapFrom(src => new Contato
                {
                    Telefone = src.Contato.Telefone,
                    Email = src.Contato.Email
                }))
                .ForMember(dest => dest.Pedidos, opt => opt.Ignore()) 
                .ForMember(dest => dest.Id, opt => opt.Ignore()); 

            CreateMap<Usuario, UsuarioDto>()
                .ForMember(dest => dest.Contato, opt => opt.MapFrom(src => new ContatoDto
                {
                    Telefone = src.Contato.Telefone,
                    Email = src.Contato.Email
                }))
                .ForMember(dest => dest.Enderecos, opt => opt.MapFrom(src => src.Enderecos.Select(e => new EnderecoDto
                {
                    Logradouro = e.Logradouro,
                    Numero = e.Numero,
                    Cidade = e.Cidade,
                    CEP = e.CEP,
                    Complemento = e.Complemento,
                    Estado = e.Estado
                })));

            CreateMap<Contato, ContatoDto>();

            CreateMap<Endereco, EnderecoDto>();

            CreateMap<Produto, ProdutoDto>()
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => new CategoriaDto
                {
                    Nome = src.Categoria.Nome,
                    Descricao = src.Categoria.Descricao,
                    DataCriacao = src.Categoria.DataCriacao
                }))
                .ForMember(dest => dest.Nutrientes, opt => opt.MapFrom(src => new NutrientesDto
                {
                    Calorias = src.Nutrientes.Calorias,
                    Proteinas = src.Nutrientes.Proteinas,
                    Carboidratos = src.Nutrientes.Carboidratos,
                    Fibras = src.Nutrientes.Fibras,
                    Gorduras = src.Nutrientes.Gorduras
                }));

            CreateMap<CadastrarProdutoDto, Produto>()
                .ForMember(dest => dest.Nutrientes, opt => opt.MapFrom(src => new Nutrientes
                {
                    Calorias = src.Nutrientes.Calorias,
                    Proteinas = src.Nutrientes.Proteinas,
                    Carboidratos = src.Nutrientes.Carboidratos,
                    Fibras = src.Nutrientes.Fibras,
                    Gorduras = src.Nutrientes.Gorduras
                }))
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => new Categoria
                {
                    Nome = src.Categoria.Nome,
                    Descricao = src.Categoria.Descricao,
                    DataCriacao = src.Categoria.DataCriacao
                }));

            CreateMap<Categoria, CategoriaDto>();

            CreateMap<Nutrientes, NutrientesDto>();

            CreateMap<MensagemContato, MensagemContatoDto>();

            CreateMap<CadastrarMensagemContatoDto, MensagemContato>()
                .ForMember(dest => dest.DataEnvio, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Respondido, opt => opt.MapFrom(src => false));

            CreateMap<Fornecedor, FornecedorDto>()
                .IncludeBase<Usuario, UsuarioDto>(); 

            CreateMap<CadastrarFornecedorDto, Fornecedor>()
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Produtos, opt => opt.Ignore()) 
                .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
