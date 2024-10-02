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
        Task<IProdutoDto> CadastrarAsync(CadastrarProdutoDto produtoDto);
        Task<IProdutoDto> AtualizarAsync(AtualizarProdutoDto produtoDto);
        Task<IProdutoDto> RemoverAsync(int id);
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

            return produtos.Select(p => ProdutoDtoFactory.Criar(TipoDto.Visualizar, p)).ToList();
        }

        public async Task<IProdutoDto> BuscarPorNomeAsync(string nome)
        {
            Produto produto = await _repository.BuscarPorNomeAsync(nome);

            return ProdutoDtoFactory.Criar(TipoDto.Visualizar, produto);
        }

        public async Task<IProdutoDto> BuscarPorIdAsync(int id)
        {
            var produto = await _repository.BuscarPorIdAsync(id);

            return ProdutoDtoFactory.Criar(TipoDto.Visualizar, produto);
        }

        public async Task<IProdutoDto> CadastrarAsync(CadastrarProdutoDto cadastrarProdutoDto)
        {
            Produto produto = new Produto(cadastrarProdutoDto); 

            var novoProduto = await _repository.CadastrarAsync(produto);

            return ProdutoDtoFactory.Criar(TipoDto.Visualizar, novoProduto);
        }

        public async Task<IProdutoDto> AtualizarAsync(AtualizarProdutoDto atualizarProdutoDto)
        {
            var produtoBanco = await _repository.BuscarPorNomeAsync(atualizarProdutoDto.Nome);

            var produtoAtualizado  =await _repository.AtualizarAsync(new Produto(atualizarProdutoDto));

            return ProdutoDtoFactory.Criar(TipoDto.Visualizar, produtoAtualizado);
        }

        public async Task<IProdutoDto> RemoverAsync(int id)
        {
            var produto = await _repository.RemoverAsync(id);

            return ProdutoDtoFactory.Criar(TipoDto.Visualizar, produto);
        }
    }

}
