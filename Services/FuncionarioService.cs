using Model.Dtos;
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

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public Task<FuncionarioDto> AtualizarAsync(FuncionarioDto funcionario)
        {
            throw new NotImplementedException();
        }

        public Task<FuncionarioDto> BuscarPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FuncionarioDto>> BuscarTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FuncionarioDto> CadastrarAsync(CadastrarFuncionarioDto funcionario)
        {
            throw new NotImplementedException();
        }

        public Task<FuncionarioDto> RemoverAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
