using AutoMapper;
using Model.Dtos;
using Model.Entities;

namespace DtoMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MapEndereco();
            MapCliente();
            MapUsuario();
            MapProduto();
            MapCategoria();
            MapFornecedor();
            MapPedido();
            MapItemPedido();
            MapFuncionario();
        }

        private void MapEndereco()
        {
            CreateMap<CadastrarEnderecoDto, Endereco>();
            CreateMap<Endereco, CadastrarEnderecoDto>();
//            CreateMap<Endereco, EnderecoDto>();

            CreateMap<Endereco, EnderecoDto>();

        }

        private void MapCliente()
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
        }

        private void MapUsuario()
        {
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
            CreateMap<Nutrientes, NutrientesDto>();
        }

        private void MapProduto()
        {
            CreateMap<Produto, ProdutoDto>()
                .ForMember(dest => dest.Fornecedor, opt => opt.MapFrom(src => src.Fornecedor)) // AutoMapper cuidará da relação
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria))   // Similar para Categoria e Nutrientes
                .ForMember(dest => dest.Nutrientes, opt => opt.MapFrom(src => src.Nutrientes));

            CreateMap<ProdutoDto, Produto>()
                .ForMember(dest => dest.Fornecedor, opt => opt.MapFrom(src => src.Fornecedor)) // AutoMapper cuidará da relação
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria))   // Similar para Categoria e Nutrientes
                .ForMember(dest => dest.Nutrientes, opt => opt.MapFrom(src => src.Nutrientes));

            //CreateMap<Produto, ProdutoDto>()
            // .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => new CategoriaDto
            // {
            //     Id = src.Categoria.Id,
            //     Nome = src.Categoria.Nome,
            //     Descricao = src.Categoria.Descricao,
            //     DataCriacao = src.Categoria.DataCriacao
            // }))
            // .ForMember(dest => dest.Nutrientes, opt => opt.MapFrom(src => new NutrientesDto
            // {
            //     Calorias = src.Nutrientes.Calorias,
            //     Proteinas = src.Nutrientes.Proteinas,
            //     Carboidratos = src.Nutrientes.Carboidratos,
            //     Fibras = src.Nutrientes.Fibras,
            //     Gorduras = src.Nutrientes.Gorduras
            // }))
            // .ForMember(dest => dest.Fornecedor, opt => opt.MapFrom(src => new FornecedorDto
            // {
            //     Id = src.Fornecedor.Id,
            //     CNPJ = src.Fornecedor.CNPJ,
            //     Nome = src.Fornecedor.Nome,
            //     DataCadastro = src.Fornecedor.DataCadastro,
            //     Contato = new ContatoDto
            //     {
            //         Email = src.Fornecedor.Contato.Email,
            //         Telefone = src.Fornecedor.Contato.Telefone,
            //     },
            //     Enderecos = src.Fornecedor.Enderecos.Select(e => new EnderecoDto
            //     {
            //         Estado = e.Estado,
            //         CEP = e.CEP,
            //         Cidade = e.CEP,
            //         Complemento = e.Complemento,
            //         Numero = e.Numero,
            //         Logradouro = e.Logradouro
            //     }).ToList(),
            // }));

            //CreateMap<ProdutoDto, Produto>()
            //  .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => new Categoria
            //  {
            //      Id = src.Categoria.Id,
            //      Nome = src.Categoria.Nome,
            //      Descricao = src.Categoria.Descricao,
            //      DataCriacao = src.Categoria.DataCriacao
            //  }))
            //  .ForMember(dest => dest.Nutrientes, opt => opt.MapFrom(src => new Nutrientes
            //  {
            //      Calorias = src.Nutrientes.Calorias,
            //      Proteinas = src.Nutrientes.Proteinas,
            //      Carboidratos = src.Nutrientes.Carboidratos,
            //      Fibras = src.Nutrientes.Fibras,
            //      Gorduras = src.Nutrientes.Gorduras
            //  }))
            //  .ForMember(dest => dest.Fornecedor, opt => opt.MapFrom(src => new Fornecedor
            //  {
            //      Id = src.Fornecedor.Id,
            //      CNPJ = src.Fornecedor.CNPJ,
            //      Nome = src.Fornecedor.Nome,
            //      DataCadastro = src.Fornecedor.DataCadastro,
            //      Contato = new Contato
            //      {
            //          Email = src.Fornecedor.Contato.Email,
            //          Telefone = src.Fornecedor.Contato.Telefone,
            //      },
            //      Enderecos = src.Fornecedor.Enderecos.Select(e => new Endereco
            //      {
            //          Estado = e.Estado,
            //          CEP = e.CEP,
            //          Cidade = e.Cidade,
            //          Complemento = e.Complemento,
            //          Numero = e.Numero,
            //          Logradouro = e.Logradouro
            //      }).ToList(),
            //  }));

            CreateMap<CadastrarProdutoDto, Produto>()
                .ForMember(dest => dest.Nutrientes, opt => opt.MapFrom(src => new Nutrientes
                {
                    Calorias = src.Nutrientes.Calorias,
                    Proteinas = src.Nutrientes.Proteinas,
                    Carboidratos = src.Nutrientes.Carboidratos,
                    Fibras = src.Nutrientes.Fibras,
                    Gorduras = src.Nutrientes.Gorduras
                }))
                .ForMember(dest => dest.Fornecedor, opt => opt.Ignore());
        }

        private void MapCategoria()
        {
            CreateMap<CadastrarCategoriaDto, Categoria>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            //CreateMap<Categoria, CategoriaDto>();

            CreateMap<Categoria, CategoriaDto>();
        }

        private void MapFornecedor()
        {
            CreateMap<CadastrarFornecedorDto, Fornecedor>()
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Produtos, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Contato, opt => opt.MapFrom(src => new Contato
                {
                    Telefone = src.Contato.Telefone,
                    Email = src.Contato.Email
                }))
                .ForMember(dest => dest.Enderecos, opt => opt.MapFrom(src => src.Enderecos.Select(e => new Endereco
                {
                    Logradouro = e.Logradouro,
                    Numero = e.Numero,
                    Cidade = e.Cidade,
                    CEP = e.CEP,
                    Complemento = e.Complemento,
                    Estado = e.Estado
                })));

            //CreateMap<Fornecedor, FornecedorDto>();

            CreateMap<Fornecedor, FornecedorDto>()
                .ForMember(dest => dest.Enderecos, opt => opt.MapFrom(src => src.Enderecos))
                .ForMember(dest => dest.Contato, opt => opt.MapFrom(src => src.Contato));

            //CreateMap<FornecedorDto, Fornecedor>();
            CreateMap<FornecedorDto, Fornecedor>()
                .ForMember(dest => dest.Enderecos, opt => opt.MapFrom(src => src.Enderecos))
                .ForMember(dest => dest.Contato, opt => opt.MapFrom(src => src.Contato));

        }

        private void MapPedido()
        {
            CreateMap<Pedido, CadastrarPedidoDto>()
                .ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src.Itens));

            CreateMap<Pedido, PedidoDto>()
                .ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src.Itens));
        }

        private void MapItemPedido()
        {
            CreateMap<ItemPedidoDto, ItemPedido>();
            CreateMap<ItemPedido, ItemPedidoDto>();
        }

        private void MapFuncionario()
        {
            CreateMap<FuncionarioDto, Funcionario>();
            CreateMap<CadastrarFuncionarioDto, Funcionario>()
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Contato, opt => opt.MapFrom(src => new Contato
                {
                    Telefone = src.Contato.Telefone,
                    Email = src.Contato.Email
                }))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Funcionario, FuncionarioDto>();
        }
    }
}
