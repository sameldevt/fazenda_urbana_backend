using AutoMapper;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IColheitaService
    {
        Task<IEnumerable<ColheitaDto>> BuscarTodosAsync();
        Task<ColheitaDto> BuscarPorIdAsync(int id);
        Task<ColheitaDto> CadastrarAsync(CadastrarColheitaDto cadastrarColheitaDto);
        Task<ColheitaDto> AtualizarAsync(ColheitaDto atualizarColheitaDto);
        Task<ColheitaDto> RemoverAsync(int id);
    }
    public class ColheitaService : IColheitaService
    {
        private readonly IColheitaRepository _colheitaRepository;
        private readonly IMapper _mapper;

        public ColheitaService(IColheitaRepository colheitaRepository, IMapper mapper)
        {
            _colheitaRepository = colheitaRepository;
            _mapper = mapper;
        }

        public async Task<ColheitaDto> BuscarPorIdAsync(int id)
        {
            var colheita = await _colheitaRepository.BuscarPorIdAsync(id);
            return _mapper.Map<ColheitaDto>(colheita);
        }

        public async Task<IEnumerable<ColheitaDto>> BuscarTodosAsync()
        {
            var colheitas = await _colheitaRepository.BuscarTodosAsync();
            return _mapper.Map<List<ColheitaDto>>(colheitas);
        }

        public async Task<ColheitaDto> CadastrarAsync(CadastrarColheitaDto cadastrarColheitaDto)
        {
            var colheita = _mapper.Map<Colheita>(cadastrarColheitaDto);
            var colheitaCadastrada = await _colheitaRepository.CadastrarAsync(colheita);
            return _mapper.Map<ColheitaDto>(colheitaCadastrada);
        }

        public async Task<ColheitaDto> AtualizarAsync(ColheitaDto atualizarColheitaDto)
        {
            var colheita = _mapper.Map<Colheita>(atualizarColheitaDto);
            var colheitaAtualizada = await _colheitaRepository.AtualizarAsync(colheita);
            return _mapper.Map<ColheitaDto>(colheitaAtualizada);
        }

        public async Task<ColheitaDto> RemoverAsync(int id)
        {
            var colheitaRemovida = await _colheitaRepository.RemoverAsync(id);
            return _mapper.Map<ColheitaDto>(colheitaRemovida);
        }
    }
}
