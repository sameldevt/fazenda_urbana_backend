using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IProdutoService
    {
        Task<VisualizarProdutoDto> BuscarPorIdAsync(int id);
        Task<List<VisualizarProdutoDto>> BuscarTodosAsync();
        Task<VisualizarProdutoDto> BuscarPorNomeAsync(string nome);
        Task<List<Categoria>> ListarCategoriasAsync();
        Task<VisualizarProdutoDto> CadastrarAsync(CadastrarProdutoDto produtoDto);
        Task<VisualizarProdutoDto> AtualizarAsync(AtualizarProdutoDto produtoDto);
        Task<VisualizarProdutoDto> RemoverAsync(int id);
    }

    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<VisualizarProdutoDto>> BuscarTodosAsync()
        {
            var produtos = await _repository.ListarTodosAsync();

            var listaProdutoDto = new List<VisualizarProdutoDto>();

            foreach(Produto p in produtos)
            {
                var produto = VisualizarProdutoDto.ConverterProduto(p);
            }

            return listaProdutoDto;
        }

        public async Task<VisualizarProdutoDto> BuscarPorNomeAsync(string nome)
        {
            Produto produto = await _repository.BuscarPorNomeAsync(nome);

            if (produto != null)
            {
                return VisualizarProdutoDto.ConverterProduto(produto);
            }

            return null;
        }

        public Task<List<Categoria>> ListarCategoriasAsync() =>
            _repository.ListarCategoriasAsync();

        public async Task<VisualizarProdutoDto> BuscarPorIdAsync(int id)
        {
            Produto produto = await _repository.BuscarPorIdAsync(id);

            return VisualizarProdutoDto.ConverterProduto(produto);
        }

        public async Task<VisualizarProdutoDto> CadastrarAsync(CadastrarProdutoDto cadastrarProdutoDto)
        {
            Categoria categoria = await _repository.BuscarCategoriaPorNome(cadastrarProdutoDto.NomeCategoria);

            Produto produto = new Produto
            {
                Nome = cadastrarProdutoDto.Nome,
                Descricao = cadastrarProdutoDto.Descricao,
                PrecoUnitario = cadastrarProdutoDto.PrecoUnitario,
                PrecoQuilo = cadastrarProdutoDto.PrecoQuilo,
                QuantidadeEstoque = cadastrarProdutoDto.QuantidadeEstoque,
                ImagemUrl = cadastrarProdutoDto.ImagemUrl,
                Categoria = categoria,
                InformacoesNutricionais = new InformacoesNutricionais
                {
                    Calorias = cadastrarProdutoDto.Calorias,
                    Proteinas = cadastrarProdutoDto.Proteinas,
                    Carboidratos = cadastrarProdutoDto.Carboidratos,
                    Fibras = cadastrarProdutoDto.Fibras,
                    Gorduras = cadastrarProdutoDto.Gorduras,
                }
             };

            var novoProduto = await _repository.AdicionarNovoAsync(produto);

            return VisualizarProdutoDto.ConverterProduto(novoProduto);
        }

        public async Task<VisualizarProdutoDto> AtualizarAsync(AtualizarProdutoDto atualizarProdutoDto)
        {
            var produtoBanco = await _repository.BuscarPorNomeAsync(atualizarProdutoDto.Nome);
            
            if (produtoBanco != null)
            {
                produtoBanco.Nome = atualizarProdutoDto.Nome;
                produtoBanco.Descricao = atualizarProdutoDto.Descricao;
                produtoBanco.PrecoUnitario = atualizarProdutoDto.PrecoUnitario;
                produtoBanco.PrecoQuilo = atualizarProdutoDto.PrecoQuilo;
                produtoBanco.QuantidadeEstoque = atualizarProdutoDto.QuantidadeEstoque;
                produtoBanco.ImagemUrl = atualizarProdutoDto.ImagemUrl;
                produtoBanco.InformacoesNutricionais = new InformacoesNutricionais
                {
                    Calorias = atualizarProdutoDto.Calorias,
                    Proteinas = atualizarProdutoDto.Proteinas,
                    Carboidratos = atualizarProdutoDto.Carboidratos,
                    Fibras = atualizarProdutoDto.Fibras,
                    Gorduras = atualizarProdutoDto.Gorduras,
                };

                await _repository.AtualizarAsync(produtoBanco);
            }

            return VisualizarProdutoDto.ConverterProduto(produtoBanco);
        }

        public async Task<VisualizarProdutoDto> RemoverAsync(int id)
        {
            Produto produto = await _repository.RemoverAsync(id);

            return VisualizarProdutoDto.ConverterProduto(produto);
        }
    }

}
