using AutoMapper;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IProdutoService
    {
        Task<VisualizarProdutoDto> BuscarPorIdAsync(int id);
        Task<VisualizarProdutoDto> BuscarPorNomeAsync(string nome);
        Task<List<VisualizarProdutoDto>> BuscarTodosAsync();
        Task<VisualizarProdutoDto> CadastrarAsync(CadastrarProdutoDto produtoDto);
        Task<List<VisualizarProdutoDto>> CadastrarVariosAsync(List<CadastrarProdutoDto> cadastrarProdutoDtos);
        Task<VisualizarProdutoDto> AtualizarAsync(AtualizarProdutoDto produtoDto);
        Task<VisualizarProdutoDto> RemoverAsync(int id);
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

        public async Task<List<VisualizarProdutoDto>> BuscarTodosAsync()
        {
            var produtos = await _produtoRepository.BuscarTodosAsync();

            return _mapper.Map<List<VisualizarProdutoDto>>(produtos);
        }

        public async Task<VisualizarProdutoDto> BuscarPorNomeAsync(string nome)
        {
            var produto = await _produtoRepository.BuscarPorNomeAsync(nome);

            return _mapper.Map<VisualizarProdutoDto>(produto);
        }

        public async Task<VisualizarProdutoDto> BuscarPorIdAsync(int id)
        {
            var produto = await _produtoRepository.BuscarPorIdAsync(id);

            return _mapper.Map<VisualizarProdutoDto>(produto);
        }

        public async Task<VisualizarProdutoDto> CadastrarAsync(CadastrarProdutoDto cadastrarProdutoDto)
        {
            var produto = await _produtoRepository.CadastrarAsync(_mapper.Map<Produto>(cadastrarProdutoDto));

            return _mapper.Map<VisualizarProdutoDto>(produto);
        }
        public async Task<List<VisualizarProdutoDto>> CadastrarVariosAsync(List<CadastrarProdutoDto> cadastrarProdutoDtos)
        {
            var produtos = await _produtoRepository.CadastrarVariosAsync(_mapper.Map<List<Produto>>(cadastrarProdutoDtos));

            return _mapper.Map<List<VisualizarProdutoDto>>(produtos);
        }
        public async Task<VisualizarProdutoDto> AtualizarAsync(AtualizarProdutoDto atualizarProdutoDto)
        {
            var produto = await _produtoRepository.BuscarPorIdAsync(atualizarProdutoDto.Id);

            produto = _mapper.Map<Produto>(atualizarProdutoDto);

            var produtoAtualizado  =await _produtoRepository.AtualizarAsync(produto);

            return _mapper.Map<VisualizarProdutoDto>(produtoAtualizado);
        }

        public async Task<VisualizarProdutoDto> RemoverAsync(int id)
        {
            var produto = await _produtoRepository.RemoverAsync(id);

            return _mapper.Map<VisualizarProdutoDto>(produto);
        }
    }
}
