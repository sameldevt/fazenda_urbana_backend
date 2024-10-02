using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IProdutoService
    {
        Task<IProdutoDto> BuscarPorIdAsync(int id);
        Task<List<IProdutoDto>> BuscarTodosAsync();
        Task<IProdutoDto> BuscarPorNomeAsync(string nome);
        Task<bool> CadastrarAsync(IProdutoDto produtoDto);
        Task<bool> AtualizarAsync(IProdutoDto produtoDto);
        Task<bool> RemoverAsync(int id);
    }

    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<IProdutoDto>> BuscarTodosAsync()
        {
            var produtos = await _repository.BuscarTodosAsync();

            var produtosDto = new List<IProdutoDto>();

            foreach(Produto p in produtos)
            {
                var produtoDto = ProdutoDtoFactory.Criar(ProdutoDtoTipo.Visualizar, p);
                produtosDto.Add(produtoDto);
            }

            return produtosDto;
        }

        public async Task<IProdutoDto> BuscarPorNomeAsync(string nome)
        {
            Produto produto = await _repository.BuscarPorNomeAsync(nome);

            if (produto != null)
            {
                return ProdutoDtoFactory.Criar(ProdutoDtoTipo.Visualizar, produto);
            }

            return null;
        }

        public async Task<IProdutoDto> BuscarPorIdAsync(int id)
        {
            var produto = await _repository.BuscarPorIdAsync(id);

            return ProdutoDtoFactory.Criar(ProdutoDtoTipo.Visualizar, produto);
        }

        public async Task<IProdutoDto> CadastrarAsync(CadastrarProdutoDto cadastrarProdutoDto)
        {
            var categoria = await _repository.BuscarCategoriaPorNome(cadastrarProdutoDto.NomeCategoria);

            Produto produto = new Produto(cadastrarProdutoDto); 

            var novoProduto = await _repository.CadastrarAsync(produto);

            return ProdutoDtoFactory.Criar(ProdutoDtoTipo.Visualizar, novoProduto);
        }

        public async Task<bool> AtualizarAsync(AtualizarProdutoDto atualizarProdutoDto)
        {
            var produtoBanco = await _repository.BuscarPorNomeAsync(atualizarProdutoDto.Nome);
            
            if (produtoBanco != null)
            {
                produtoBanco.Nome = atualizarProdutoDto.Nome;
                produtoBanco.Descricao = atualizarProdutoDto.Descricao;
                produtoBanco.PrecoUnitario = atualizarProdutoDto.PrecoUnitario;
                produtoBanco.PrecoQuilo = atualizarProdutoDto.PrecoQuilo;
                produtoBanco.QuantidadeEstoque = atualizarProdutoDto.QuantidadeEstoque;
                produtoBanco.Categoria = atualizarProdutoDto.Categoria,
                produtoBanco.ImagemUrl = atualizarProdutoDto.ImagemUrl;
                produtoBanco.Nutrientes = new Nutrientes
                {
                    Calorias = atualizarProdutoDto.Calorias,
                    Proteinas = atualizarProdutoDto.Proteinas,
                    Carboidratos = atualizarProdutoDto.Carboidratos,
                    Fibras = atualizarProdutoDto.Fibras,
                    Gorduras = atualizarProdutoDto.Gorduras,
                };

                return await _repository.AtualizarAsync(produtoBanco);
            }
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var produto = await _repository.RemoverAsync(id);

            if (produto != null)
            {
                return true;
            }

            return false;
        }
    }

}
