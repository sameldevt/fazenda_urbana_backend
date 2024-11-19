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
            MapNutrientes();
            MapMensagemContato();
            MapColheita();
            MapCultura();
            MapFazenda();
            MapEquipamento();
            MapInsumo();
        }

        private void MapInsumo()
        {
            CreateMap<CadastrarInsumoDto, Insumo>();
            CreateMap<InsumoDto, Insumo>();
            CreateMap<Insumo, InsumoDto>();
        }

        private void MapMensagemContato()
        {
            CreateMap<CadastrarMensagemContatoDto, MensagemContato>();
            CreateMap<MensagemContatoDto, MensagemContato>();
            CreateMap<MensagemContato, MensagemContatoDto>();
        }

        private void MapColheita()
        {
            CreateMap<CadastrarColheitaDto, Colheita>();
            CreateMap<Colheita, CadastrarColheitaDto>();
            CreateMap<ColheitaDto, Colheita>();
            CreateMap<Colheita, ColheitaDto>();
        }

        private void MapCultura()
        {
            CreateMap<CadastrarCulturaDto, Cultura>();
            CreateMap<Cultura, CulturaDto>();
            CreateMap<CulturaDto, Cultura>();
        }

        private void MapFazenda()
        {
            CreateMap<CadastrarFazendaDto, Fazenda>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Fazenda, FazendaDto>();
            CreateMap<FazendaDto, Fazenda>();
        }

        private void MapEndereco()
        {
            CreateMap<CadastrarEnderecoDto, Endereco>();
            CreateMap<Endereco, CadastrarEnderecoDto>();
            CreateMap<Endereco, EnderecoDto>();
        }

        private void MapEquipamento()
        {
            CreateMap<CadastrarEquipamentoDto, Equipamento>();
            CreateMap<EquipamentoDto, Equipamento>();
            CreateMap<Equipamento, EquipamentoDto>();
        }

        private void MapCliente()
        {
            CreateMap<ClienteDto, Cliente>();

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
            CreateMap<ContatoDto, Contato>();
            CreateMap<Nutrientes, NutrientesDto>();
        }

        private void MapProduto()
        {
            CreateMap<Produto, ProdutoDto>()
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria)) 
                .ForMember(dest => dest.Nutrientes, opt => opt.MapFrom(src => src.Nutrientes));

            CreateMap<ProdutoDto, Produto>()
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria)) 
                .ForMember(dest => dest.Nutrientes, opt => opt.MapFrom(src => src.Nutrientes));

            CreateMap<AtualizarProdutoDto, Produto>()
                .ForMember(dest => dest.Categoria, opt => opt.Ignore())
                .ForMember(dest => dest.Nutrientes, opt => opt.MapFrom(src => src.Nutrientes));

            CreateMap<CadastrarProdutoDto, Produto>()
                .ForMember(dest => dest.Nutrientes, opt => opt.MapFrom(src => new Nutrientes
                {
                    Calorias = src.Nutrientes.Calorias,
                    Proteinas = src.Nutrientes.Proteinas,
                    Carboidratos = src.Nutrientes.Carboidratos,
                    Fibras = src.Nutrientes.Fibras,
                    Gorduras = src.Nutrientes.Gorduras
                }));
        }

        private void MapCategoria()
        {
            CreateMap<CadastrarCategoriaDto, Categoria>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Categoria, CategoriaDto>();
        }

        private void MapFornecedor()
        {
            CreateMap<CadastrarFornecedorDto, Fornecedor>()
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => DateTime.UtcNow))
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

            CreateMap<Fornecedor, FornecedorDto>()
                .ForMember(dest => dest.Enderecos, opt => opt.MapFrom(src => src.Enderecos))
                .ForMember(dest => dest.Contato, opt => opt.MapFrom(src => src.Contato));

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
            CreateMap<Funcionario, FuncionarioDto>();

            CreateMap<CadastrarOperadorDto, Funcionario>()
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Contato, opt => opt.MapFrom(src => new Contato
                {
                    Telefone = src.Contato.Telefone,
                    Email = src.Contato.Email
                }))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<CadastrarFuncionarioDto, Funcionario>()
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Enderecos, opt => opt.MapFrom(src => src.Enderecos.Select(e => new Endereco
                {
                    Logradouro = e.Logradouro,
                    Numero = e.Numero,
                    Cidade = e.Cidade,
                    CEP = e.CEP,
                    Complemento = e.Complemento,
                    Estado = e.Estado
                })))
                .ForMember(dest => dest.Contato, opt => opt.MapFrom(src => new Contato
                {
                    Telefone = src.Contato.Telefone,
                    Email = src.Contato.Email
                }))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

        }

        public void MapNutrientes()
        {
            CreateMap<NutrientesDto, Nutrientes>();
        }
    }
}
