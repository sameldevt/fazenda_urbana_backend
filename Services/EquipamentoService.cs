using AutoMapper;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IEquipamentoService
    {
        Task<IEnumerable<EquipamentoDto>> BuscarTodosAsync();
        Task<EquipamentoDto> BuscarPorIdAsync(int id);
        Task<EquipamentoDto> CadastrarAsync(CadastrarEquipamentoDto cadastrarEquipamentoDto);
        Task<EquipamentoDto> AtualizarAsync(EquipamentoDto atualizarEquipamentoDto);
        Task<EquipamentoDto> RemoverAsync(int id);
    }
    public class EquipamentoService : IEquipamentoService
    {
        private readonly IEquipamentoRepository _equipamentoRepository;
        private readonly IMapper _mapper;

        public EquipamentoService(IEquipamentoRepository equipamentoRepository, IMapper mapper)
        {
            _equipamentoRepository = equipamentoRepository;
            _mapper = mapper;
        }

        public async Task<EquipamentoDto> BuscarPorIdAsync(int id)
        {
            var equipamento = await _equipamentoRepository.BuscarPorIdAsync(id);
            return _mapper.Map<EquipamentoDto>(equipamento);
        }

        public async Task<IEnumerable<EquipamentoDto>> BuscarTodosAsync()
        {
            var equipamentos = await _equipamentoRepository.BuscarTodosAsync();
            return _mapper.Map<List<EquipamentoDto>>(equipamentos);
        }

        public async Task<EquipamentoDto> CadastrarAsync(CadastrarEquipamentoDto cadastrarEquipamentoDto)
        {
            var equipamento = _mapper.Map<Equipamento>(cadastrarEquipamentoDto);
            var equipamentoCadastrado = await _equipamentoRepository.CadastrarAsync(equipamento);
            return _mapper.Map<EquipamentoDto>(equipamentoCadastrado);
        }

        public async Task<EquipamentoDto> AtualizarAsync(EquipamentoDto atualizarEquipamentoDto)
        {
            var equipamento = _mapper.Map<Equipamento>(atualizarEquipamentoDto);
            var equipamentoAtualizado = await _equipamentoRepository.AtualizarAsync(equipamento);
            return _mapper.Map<EquipamentoDto>(equipamentoAtualizado);
        }

        public async Task<EquipamentoDto> RemoverAsync(int id)
        {
            var equipamentoRemovido = await _equipamentoRepository.RemoverAsync(id);
            return _mapper.Map<EquipamentoDto>(equipamentoRemovido);
        }
    }
}
