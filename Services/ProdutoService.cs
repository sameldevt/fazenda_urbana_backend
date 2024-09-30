using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IProdutoService
    {
        Task<ProdutoDto> BuscarPorIdAsync(int id);
        Task<List<ProdutoDto>> ListarTodosAsync();
        Task<ProdutoDto> BuscarPorNomeAsync(string nome);
        Task<List<Categoria>> ListarCategoriasAsync();
        Task<ProdutoDto> AdicionarNovoAsync(ProdutoDto produtoDto);
        Task<ProdutoDto> AtualizarAsync(ProdutoDto produtoDto);
        Task<ProdutoDto> RemoverAsync(int id);
    }

    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProdutoDto>> ListarTodosAsync()
        {
            var produtos = await _repository.ListarTodosAsync();

            var listaProdutoDto = new List<ProdutoDto>();

            foreach(Produto p in produtos)
            {
                ProdutoDto produtoDto = ProdutoDto.FromProduto(p);
                listaProdutoDto.Add(produtoDto);
            }

            return listaProdutoDto;
        }

        public async Task<ProdutoDto> BuscarPorNomeAsync(string nome)
        {
            Produto produto = await _repository.BuscarPorNomeAsync(nome);

            if (produto != null)
            {
                return ProdutoDto.FromProduto(produto);
            }

            return null;
        }

        public Task<List<Categoria>> ListarCategoriasAsync() =>
            _repository.ListarCategoriasAsync();

        public async Task<ProdutoDto> BuscarPorIdAsync(int id)
        {
            Produto produto = await _repository.BuscarPorIdAsync(id);

            var produtoDto = ProdutoDto.FromProduto(produto);
            return produtoDto;
        }

        public async Task<ProdutoDto> AdicionarNovoAsync(ProdutoDto produtoDto)
        {
            Categoria categoria = await _repository.BuscarCategoriaPorNome(produtoDto.Categoria);

            Produto produto = new Produto
            {
                Nome = produtoDto.Nome,
                Descricao = produtoDto.Descricao,
                PrecoUnitario = produtoDto.PrecoUnitario,
                PrecoQuilo = produtoDto.PrecoQuilo,
                QuantidadeEstoque = produtoDto.QuantidadeEstoque,
                ImagemUrl = produtoDto.ImagemUrl,
                Categoria = categoria,
                InformacoesNutricionais = new InformacoesNutricionais
                {
                    Calorias = produtoDto.InformacoesNutricionais.Calorias,
                    Proteinas = produtoDto.InformacoesNutricionais.Proteinas,
                    Carboidratos = produtoDto.InformacoesNutricionais.Carboidratos,
                    Fibras = produtoDto.InformacoesNutricionais.Fibras,
                    Gorduras = produtoDto.InformacoesNutricionais.Gorduras,
                }
             };

            var novoProduto = await _repository.AdicionarNovoAsync(produto);

            return ProdutoDto.FromProduto(novoProduto);
        }

        public async Task<ProdutoDto> AtualizarAsync(ProdutoDto produtoDto)
        {
            var produtoExistente = await _repository.BuscarPorNomeAsync(produtoDto.Nome);
            
            if (produtoExistente != null)
            {
                produtoExistente.Nome = produtoDto.Nome;
                produtoExistente.Descricao = produtoDto.Descricao;
                produtoExistente.PrecoUnitario = produtoDto.PrecoUnitario;
                produtoExistente.PrecoQuilo = produtoDto.PrecoQuilo;
                await _repository.AtualizarAsync(produtoExistente);
            }

            return ProdutoDto.FromProduto(produtoExistente);
        }

        public async Task<ProdutoDto> RemoverAsync(int id)
        {
            Produto produto = await _repository.RemoverAsync(id);

            return ProdutoDto.FromProduto(produto);
        }
    }

}
