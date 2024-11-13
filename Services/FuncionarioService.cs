using AutoMapper;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<FuncionarioDto>> BuscarTodosAsync();
        Task<FuncionarioDto> BuscarPorIdAsync(int id);
        Task<FuncionarioDto> CadastrarAsync(CadastrarFuncionarioDto funcionario);
        Task<FuncionarioDto> AtualizarAsync(FuncionarioDto funcionario);
        Task<FuncionarioDto> RemoverAsync(int id);
    }

    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FuncionarioDto>> BuscarTodosAsync()
        {
            var funcionarios = await _funcionarioRepository.BuscarTodosAsync();
            return _mapper.Map<List<FuncionarioDto>>(funcionarios);
        }

        public async Task<FuncionarioDto> BuscarPorIdAsync(int id)
        {
            var funcionario = await _funcionarioRepository.BuscarPorIdAsync(id);
            return _mapper.Map<FuncionarioDto>(funcionario);
        }

        public async Task<FuncionarioDto> CadastrarAsync(CadastrarFuncionarioDto funcionarioDto)
        {
            var funcionario = _mapper.Map<Funcionario>(funcionarioDto);
            var funcionarioCadastrado = await _funcionarioRepository.CadastrarAsync(funcionario);
            return _mapper.Map<FuncionarioDto>(funcionario);
        }

        public async Task<FuncionarioDto> AtualizarAsync(FuncionarioDto funcionarioDto)
        {
            var funcionario = _mapper.Map<Funcionario>(funcionarioDto);
            var funcionarioAtualizado = await _funcionarioRepository.AtualizarAsync(funcionario);
            return _mapper.Map<FuncionarioDto>(funcionarioAtualizado);
        }

        public async Task<FuncionarioDto> RemoverAsync(int id)
        {
            var funcionarioRemovido = await _funcionarioRepository.RemoverAsync(id);
            return _mapper.Map<FuncionarioDto>(funcionarioRemovido);
        }
    }
}
