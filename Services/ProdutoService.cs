using AutoMapper;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IProdutoService
    {
        Task<ProdutoDto> BuscarPorIdAsync(int id);
        Task<ProdutoDto> BuscarPorNomeAsync(string nome);
        Task<List<ProdutoDto>> BuscarTodosAsync();
        Task<ProdutoDto> CadastrarAsync(CadastrarProdutoDto produtoDto);
        Task<List<ProdutoDto>> CadastrarVariosAsync(List<CadastrarProdutoDto> cadastrarProdutoDtos);
        Task<ProdutoDto> AtualizarAsync(ProdutoDto produtoDto);
        Task<ProdutoDto> RemoverAsync(int id);
    }

    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<List<ProdutoDto>> BuscarTodosAsync()
        {
            var produtos = await _produtoRepository.BuscarTodosAsync();

            return _mapper.Map<List<ProdutoDto>>(produtos);
        }

        public async Task<ProdutoDto> BuscarPorNomeAsync(string nome)
        {
            var produto = await _produtoRepository.BuscarPorNomeAsync(nome);

            return _mapper.Map<ProdutoDto>(produto);
        }

        public async Task<ProdutoDto> BuscarPorIdAsync(int id)
        {
            var produto = await _produtoRepository.BuscarPorIdAsync(id);

            return _mapper.Map<ProdutoDto>(produto);
        }

        public async Task<ProdutoDto> CadastrarAsync(CadastrarProdutoDto cadastrarProdutoDto)
        {
            var produto = await _produtoRepository.CadastrarAsync(_mapper.Map<Produto>(cadastrarProdutoDto));

            return _mapper.Map<ProdutoDto>(produto);
        }
        public async Task<List<ProdutoDto>> CadastrarVariosAsync(List<CadastrarProdutoDto> cadastrarProdutoDtos)
        {
            var produtos = await _produtoRepository.CadastrarVariosAsync(_mapper.Map<List<Produto>>(cadastrarProdutoDtos));

            return _mapper.Map<List<ProdutoDto>>(produtos);
        }
        public async Task<ProdutoDto> AtualizarAsync(ProdutoDto atualizarProdutoDto)
        {
            var produto = await _produtoRepository.BuscarPorIdAsync(atualizarProdutoDto.Id);

            produto = _mapper.Map<Produto>(atualizarProdutoDto);

            var produtoAtualizado  =await _produtoRepository.AtualizarAsync(produto);

            return _mapper.Map<ProdutoDto>(produtoAtualizado);
        }

        public async Task<ProdutoDto> RemoverAsync(int id)
        {
            var produto = await _produtoRepository.RemoverAsync(id);

            return _mapper.Map<ProdutoDto>(produto);
        }
    }
}
