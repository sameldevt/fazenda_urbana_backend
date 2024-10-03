using AutoMapper;
using Model.Dtos;
using Model.Entities;

namespace DtoMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MapearCliente();
            MapearFornecedor();
            MapearPedido();
            MapearProduto();
            MapearMensagemContato();
        }

        private void MapearCliente()
        {
            CreateMap<RegistrarUsuarioDto, Cliente>()
            .ForMember(dest => dest.Contato, opt => opt.MapFrom(src => new Contato
            {
                Telefone = src.Telefone,
                Email = src.Email
            }))
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => new Endereco
            {
                Logradouro = src.Logradouro,
                Numero = src.Numero,
                Cidade = src.Cidade,
                CEP = src.CEP,
                Complemento = src.Complemento,
                Estado = src.Estado,
                InformacoesAdicionais = src.InformacoesAdicionais
            }));

            CreateMap<Cliente, VisualizarClienteDto>()
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Contato.Telefone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Contato.Email))
                .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Endereco.Logradouro))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Endereco.Numero))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Endereco.Cidade))
                .ForMember(dest => dest.CEP, opt => opt.MapFrom(src => src.Endereco.CEP))
                .ForMember(dest => dest.Complemento, opt => opt.MapFrom(src => src.Endereco.Complemento))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Endereco.Estado))
                .ForMember(dest => dest.InformacoesAdicionais, opt => opt.MapFrom(src => src.Endereco.InformacoesAdicionais));

            CreateMap<CadastrarClienteDto, Cliente>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignorar Id ao criar novo cliente
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha)) // Incluir a senha para persistir no banco
                .ForPath(dest => dest.Contato.Telefone, opt => opt.MapFrom(src => src.Telefone))
                .ForPath(dest => dest.Contato.Email, opt => opt.MapFrom(src => src.Email))
                .ForPath(dest => dest.Endereco.Logradouro, opt => opt.MapFrom(src => src.Logradouro))
                .ForPath(dest => dest.Endereco.Numero, opt => opt.MapFrom(src => src.Numero))
                .ForPath(dest => dest.Endereco.Cidade, opt => opt.MapFrom(src => src.Cidade))
                .ForPath(dest => dest.Endereco.CEP, opt => opt.MapFrom(src => src.CEP))
                .ForPath(dest => dest.Endereco.Complemento, opt => opt.MapFrom(src => src.Complemento))
                .ForPath(dest => dest.Endereco.Estado, opt => opt.MapFrom(src => src.Estado))
                .ForPath(dest => dest.Endereco.InformacoesAdicionais, opt => opt.MapFrom(src => src.InformacoesAdicionais));

            CreateMap<AtualizarClienteDto, Cliente>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)) // Preserva o Id para garantir a atualização correta
                .ForPath(dest => dest.Contato.Telefone, opt => opt.MapFrom(src => src.Telefone))
                .ForPath(dest => dest.Contato.Email, opt => opt.MapFrom(src => src.Email))
                .ForPath(dest => dest.Endereco.Logradouro, opt => opt.MapFrom(src => src.Logradouro))
                .ForPath(dest => dest.Endereco.Numero, opt => opt.MapFrom(src => src.Numero))
                .ForPath(dest => dest.Endereco.Cidade, opt => opt.MapFrom(src => src.Cidade))
                .ForPath(dest => dest.Endereco.CEP, opt => opt.MapFrom(src => src.CEP))
                .ForPath(dest => dest.Endereco.Complemento, opt => opt.MapFrom(src => src.Complemento))
                .ForPath(dest => dest.Endereco.Estado, opt => opt.MapFrom(src => src.Estado))
                .ForPath(dest => dest.Endereco.InformacoesAdicionais, opt => opt.MapFrom(src => src.InformacoesAdicionais));
        }

        private void MapearFornecedor()
        {
            CreateMap<Fornecedor, VisualizarFornecedorDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.CNPJ, opt => opt.MapFrom(src => src.CNPJ))
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Telefone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.Website))
                .ForMember(dest => dest.ContatoPrincipal, opt => opt.MapFrom(src => src.ContatoPrincipal))
                .ForMember(dest => dest.Observacoes, opt => opt.MapFrom(src => src.Observacoes))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => src.DataCadastro));


            CreateMap<CadastrarFornecedorDto, Fornecedor>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.CNPJ, opt => opt.MapFrom(src => src.CNPJ))
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Telefone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.Website))
                .ForMember(dest => dest.ContatoPrincipal, opt => opt.MapFrom(src => src.ContatoPrincipal))
                .ForMember(dest => dest.Observacoes, opt => opt.MapFrom(src => src.Observacoes))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => DateTime.UtcNow)); // Set DataCadastro with the current date

            CreateMap<AtualizarFornecedorDto, Fornecedor>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                 .ForMember(dest => dest.CNPJ, opt => opt.MapFrom(src => src.CNPJ))
                 .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
                 .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Telefone))
                 .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                 .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.Website))
                 .ForMember(dest => dest.ContatoPrincipal, opt => opt.MapFrom(src => src.ContatoPrincipal))
                 .ForMember(dest => dest.Observacoes, opt => opt.MapFrom(src => src.Observacoes))
                 .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => src.DataCadastro)); // Preserving existing DataCadastro
        }

        private void MapearPedido()
        {
            CreateMap<Pedido, VisualizarPedidoDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DataPedido, opt => opt.MapFrom(src => src.DataPedido))
                .ForMember(dest => dest.DataEntrega, opt => opt.MapFrom(src => src.DataEntrega))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
                .ForMember(dest => dest.EnderecoEntrega, opt => opt.MapFrom(src => src.EnderecoEntrega))
                .ForMember(dest => dest.FormaPagamento, opt => opt.MapFrom(src => src.FormaPagamento))
                .ForMember(dest => dest.Observacoes, opt => opt.MapFrom(src => src.Observacoes))
                .ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src.Itens));

            CreateMap<CadastrarPedidoDto, Pedido>()
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.DataPedido, opt => opt.MapFrom(src => src.DataPedido))
                .ForMember(dest => dest.DataEntrega, opt => opt.MapFrom(src => src.DataEntrega))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
                .ForMember(dest => dest.EnderecoEntrega, opt => opt.MapFrom(src => src.EnderecoEntrega))
                .ForMember(dest => dest.FormaPagamento, opt => opt.MapFrom(src => src.FormaPagamento))
                .ForMember(dest => dest.Observacoes, opt => opt.MapFrom(src => src.Observacoes))
                .ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src.Itens));

            CreateMap<ItemPedido, VisualizarItemPedidoDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Produto, opt => opt.MapFrom(src => src.Produto)) // Adicione o mapeamento do Produto
                .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src.Quantidade))
                .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => src.PrecoUnitario))
                .ForMember(dest => dest.SubTotal, opt => opt.MapFrom(src => src.SubTotal));

            CreateMap<CadastrarItemPedidoDto, ItemPedido>()
                .ForMember(dest => dest.Produto, opt => opt.MapFrom(src => src.Produto)) // Certifique-se que Produto está mapeado corretamente
                .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src.Quantidade))
                .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => src.PrecoUnitario))
                .ForMember(dest => dest.SubTotal, opt => opt.MapFrom(src => src.SubTotal));

            CreateMap<AlterarStatusPedidoDto, Pedido>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<VisualizarItemPedidoDto, ItemPedido>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignorando o Id, se gerado pelo banco
                .ForMember(dest => dest.PedidoId, opt => opt.Ignore()) // Ignorando o PedidoId
                .ForMember(dest => dest.Produto, opt => opt.MapFrom(src => src.Produto))
                .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src.Quantidade))
                .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => src.PrecoUnitario))
                .ForMember(dest => dest.SubTotal, opt => opt.MapFrom(src => src.SubTotal));

            // Certifique-se que o mapeamento para Produto está definido
            CreateMap<VisualizarProdutoDto, Produto>();
            // Adicione quaisquer outras configurações de mapeamento necessárias para o Produto e outros tipos que você usar.
        }

        private void MapearProduto()
        {
            CreateMap<Produto, VisualizarProdutoDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => src.PrecoUnitario))
                .ForMember(dest => dest.PrecoQuilo, opt => opt.MapFrom(src => src.PrecoQuilo))
                .ForMember(dest => dest.QuantidadeEstoque, opt => opt.MapFrom(src => src.QuantidadeEstoque))
                .ForMember(dest => dest.NomeCategoria, opt => opt.MapFrom(src => src.Categoria.Nome))
                .ForMember(dest => dest.DescricaoCategoria, opt => opt.MapFrom(src => src.Categoria.Descricao))
                .ForMember(dest => dest.ImagemUrl, opt => opt.MapFrom(src => src.ImagemUrl))
                .ForMember(dest => dest.Calorias, opt => opt.MapFrom(src => src.Nutrientes.Calorias))
                .ForMember(dest => dest.Proteinas, opt => opt.MapFrom(src => src.Nutrientes.Proteinas))
                .ForMember(dest => dest.Carboidratos, opt => opt.MapFrom(src => src.Nutrientes.Carboidratos))
                .ForMember(dest => dest.Fibras, opt => opt.MapFrom(src => src.Nutrientes.Fibras))
                .ForMember(dest => dest.Gorduras, opt => opt.MapFrom(src => src.Nutrientes.Gorduras));

            CreateMap<CadastrarProdutoDto, Produto>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => src.PrecoUnitario))
                .ForMember(dest => dest.PrecoQuilo, opt => opt.MapFrom(src => src.PrecoQuilo))
                .ForMember(dest => dest.QuantidadeEstoque, opt => opt.MapFrom(src => src.QuantidadeEstoque))
                .ForMember(dest => dest.ImagemUrl, opt => opt.MapFrom(src => src.ImagemUrl))
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => new Categoria
                {
                    Nome = src.NomeCategoria,
                    Descricao = src.DescricaoCategoria
                }))
                .ForMember(dest => dest.Nutrientes, opt => opt.MapFrom(src => new Nutrientes
                {
                    Calorias = src.Calorias,
                    Proteinas = src.Proteinas,
                    Carboidratos = src.Carboidratos,
                    Fibras = src.Fibras,
                    Gorduras = src.Gorduras
                }));

            CreateMap<AtualizarProdutoDto, Produto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => src.PrecoUnitario))
                .ForMember(dest => dest.PrecoQuilo, opt => opt.MapFrom(src => src.PrecoQuilo))
                .ForMember(dest => dest.QuantidadeEstoque, opt => opt.MapFrom(src => src.QuantidadeEstoque))
                .ForMember(dest => dest.ImagemUrl, opt => opt.MapFrom(src => src.ImagemUrl))
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => new Categoria
                {
                    Nome = src.NomeCategoria,
                    Descricao = src.DescricaoCategoria
                }))
                .ForMember(dest => dest.Nutrientes, opt => opt.MapFrom(src => new Nutrientes
                {
                    Calorias = src.Calorias,
                    Proteinas = src.Proteinas,
                    Carboidratos = src.Carboidratos,
                    Fibras = src.Fibras,
                    Gorduras = src.Gorduras
                }));

            CreateMap<Categoria, VisualizarProdutoDto>()
                .ForMember(dest => dest.NomeCategoria, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.DescricaoCategoria, opt => opt.MapFrom(src => src.Descricao));

            CreateMap<Nutrientes, VisualizarProdutoDto>()
                .ForMember(dest => dest.Calorias, opt => opt.MapFrom(src => src.Calorias))
                .ForMember(dest => dest.Proteinas, opt => opt.MapFrom(src => src.Proteinas))
                .ForMember(dest => dest.Carboidratos, opt => opt.MapFrom(src => src.Carboidratos))
                .ForMember(dest => dest.Fibras, opt => opt.MapFrom(src => src.Fibras))
                .ForMember(dest => dest.Gorduras, opt => opt.MapFrom(src => src.Gorduras));
        }

        private void MapearMensagemContato()
        {
            CreateMap<RegistrarMensagemDto, MensagemContato>()
                .ForMember(dest => dest.DataEnvio, opt => opt.Ignore()) 
                .ForMember(dest => dest.Respondido, opt => opt.Ignore());

            CreateMap<MensagemContato, VisualizarMensagemDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.NomeUsuario))
                .ForMember(dest => dest.EmailUsuario, opt => opt.MapFrom(src => src.EmailUsuario))
                .ForMember(dest => dest.Conteudo, opt => opt.MapFrom(src => src.Conteudo))
                .ForMember(dest => dest.DataEnvio, opt => opt.MapFrom(src => src.DataEnvio))
                .ForMember(dest => dest.Respondido, opt => opt.MapFrom(src => src.Respondido));

            CreateMap<MensagemContato, RegistrarMensagemDto>()
                .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.NomeUsuario))
                .ForMember(dest => dest.EmailUsuario, opt => opt.MapFrom(src => src.EmailUsuario))
                .ForMember(dest => dest.Conteudo, opt => opt.MapFrom(src => src.Conteudo));

            CreateMap<AtualizarMensagemDto, MensagemContato>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                       .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.NomeUsuario))
                       .ForMember(dest => dest.EmailUsuario, opt => opt.MapFrom(src => src.EmailUsuario))
                       .ForMember(dest => dest.Conteudo, opt => opt.MapFrom(src => src.Conteudo))
                       .ForMember(dest => dest.Respondido, opt => opt.MapFrom(src => src.Respondido));
        }
    }
}
