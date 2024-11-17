using AutoMapper;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface ICulturaService
    {
        Task<IEnumerable<CulturaDto>> BuscarTodosAsync();
        Task<CulturaDto> BuscarPorIdAsync(int id);
        Task<CulturaDto> CadastrarAsync(CadastrarCulturaDto cadastrarCulturaDto);
        Task<CulturaDto> AtualizarAsync(CulturaDto atualizarCulturaDto);
        Task<CulturaDto> RemoverAsync(int id);
    }

    public class CulturaService : ICulturaService
    {
        private readonly ICulturaRepository _culturaRepository;
        private readonly IMapper _mapper;

        public CulturaService(ICulturaRepository culturaRepository, IMapper mapper)
        {
            _culturaRepository = culturaRepository;
            _mapper = mapper;
        }

        public async Task<CulturaDto> BuscarPorIdAsync(int id)
        {
            var cultura = await _culturaRepository.BuscarPorIdAsync(id);
            return _mapper.Map<CulturaDto>(cultura);
        }

        public async Task<IEnumerable<CulturaDto>> BuscarTodosAsync()
        {
            var culturas = await _culturaRepository.BuscarTodosAsync();
            return _mapper.Map<List<CulturaDto>>(culturas);
        }

        public async Task<CulturaDto> CadastrarAsync(CadastrarCulturaDto cadastrarCulturaDto)
        {
            var cultura = _mapper.Map<Cultura>(cadastrarCulturaDto);
            var culturaCadastrada = await _culturaRepository.CadastrarAsync(cultura);
            return _mapper.Map<CulturaDto>(culturaCadastrada);
        }

        public async Task<CulturaDto> AtualizarAsync(CulturaDto atualizarCulturaDto)
        {
            var cultura = _mapper.Map<Cultura>(atualizarCulturaDto);
            var culturaAtualizada = await _culturaRepository.AtualizarAsync(cultura);
            return _mapper.Map<CulturaDto>(culturaAtualizada);
        }

        public async Task<CulturaDto> RemoverAsync(int id)
        {
            var culturaRemovida = await _culturaRepository.RemoverAsync(id);
            return _mapper.Map<CulturaDto>(culturaRemovida);
        }
    }
}
