using AutoMapper;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IFazendaService
    {
        Task<IEnumerable<FazendaDto>> BuscarTodosAsync();
        Task<FazendaDto> BuscarPorIdAsync(int id);
        Task<FazendaDto> CadastrarAsync(CadastrarFazendaDto cadastrarFazendaDto);
        Task<FazendaDto> AtualizarAsync(FazendaDto atualizarFazendaDto);
        Task<FazendaDto> RemoverAsync(int id);
    }
    public class FazendaService : IFazendaService
    {
        private readonly IFazendaRepository _fazendaRepository;
        private readonly IMapper _mapper;

        public FazendaService(IFazendaRepository fazendaRepository, IMapper mapper) 
        {
            _fazendaRepository = fazendaRepository;
            _mapper = mapper;
        }

        public async Task<FazendaDto> BuscarPorIdAsync(int id)
        {
            var fazenda = await _fazendaRepository.BuscarPorIdAsync(id);
            return _mapper.Map<FazendaDto>(fazenda);
        }

        public async Task<IEnumerable<FazendaDto>> BuscarTodosAsync()
        {
            var fazendas = await _fazendaRepository.BuscarTodosAsync();
            return _mapper.Map<List<FazendaDto>>(fazendas);
        }

        public async Task<FazendaDto> CadastrarAsync(CadastrarFazendaDto cadastrarFazendaDto)
        {
            var fazenda = _mapper.Map<Fazenda>(cadastrarFazendaDto);
            var fazendaCadastrada = await _fazendaRepository.CadastrarAsync(fazenda);
            return _mapper.Map<FazendaDto>(fazendaCadastrada);
        }

        public async Task<FazendaDto> AtualizarAsync(FazendaDto atualizarFazendaDto)
        {
            var fazenda = _mapper.Map<Fazenda>(atualizarFazendaDto);
            var fazendaAtualizada = await _fazendaRepository.AtualizarAsync(fazenda);
            return _mapper.Map<FazendaDto>(fazendaAtualizada);
        }

        public async Task<FazendaDto> RemoverAsync(int id)
        {
            var fazendaRemovida = await _fazendaRepository.RemoverAsync(id);
            return _mapper.Map<FazendaDto>(fazendaRemovida);
        }
    }
}