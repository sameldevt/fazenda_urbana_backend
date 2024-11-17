using AutoMapper;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IInsumoService
    {
        Task<IEnumerable<InsumoDto>> BuscarTodosAsync();
        Task<InsumoDto> BuscarPorIdAsync(int id);
        Task<InsumoDto> CadastrarAsync(CadastrarInsumoDto cadastrarInsumoDto);
        Task<InsumoDto> AtualizarAsync(InsumoDto atualizarInsumoDto);
        Task<InsumoDto> RemoverAsync(int id);
    }
    public class InsumoService : IInsumoService
    {
        private readonly IInsumoRepository _insumoRepository;
        private readonly IMapper _mapper;

        public InsumoService(IInsumoRepository insumoRepository, IMapper mapper)
        {
            _insumoRepository = insumoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InsumoDto>> BuscarTodosAsync()
        {
            var insumos = await _insumoRepository.BuscarTodosAsync();

            return _mapper.Map<List<InsumoDto>>(insumos);
        }

        public async Task<InsumoDto> BuscarPorIdAsync(int id)
        {
            var insumo = await _insumoRepository.BuscarPorIdAsync(id);

            return _mapper.Map<InsumoDto>(insumo);
        }

        public async Task<InsumoDto> CadastrarAsync(CadastrarInsumoDto cadastrarInsumoDto)
        {
            var insumo = _mapper.Map<Insumo>(cadastrarInsumoDto);

            var insumoCadastrado = await _insumoRepository.CadastrarAsync(insumo);

            return _mapper.Map<InsumoDto>(insumoCadastrado);
        }

        public async Task<InsumoDto> AtualizarAsync(InsumoDto atualizarInsumoDto)
        {
            var insumo = _mapper.Map<Insumo>(atualizarInsumoDto);

            var insumoAtualizado = await _insumoRepository.AtualizarAsync(insumo);

            return _mapper.Map<InsumoDto>(insumoAtualizado);
        }

        public async Task<InsumoDto> RemoverAsync(int id)
        {
            var insumoRemovido = await _insumoRepository.RemoverAsync(id);

            return _mapper.Map<InsumoDto>(insumoRemovido);
        }
    }
}
