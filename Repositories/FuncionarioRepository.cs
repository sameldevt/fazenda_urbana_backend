using Data;
using Model.Entities;

namespace Repositories
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionario>> BuscarTodosAsync();
        Task<Funcionario> BuscarPorIdAsync(int id);
        Task<Funcionario> CadastrarAsync(Funcionario funcionario);
        Task<Funcionario> AtualizarAsync(Funcionario funcionario);
        Task<Funcionario> AtualizarSenhaAsync(Funcionario funcionario);
        Task<Funcionario> RemoverAsync(int id);
    }

    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly ApplicationDbContext _context;

        public FuncionarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Funcionario> AtualizarAsync(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public Task<Funcionario> AtualizarSenhaAsync(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public Task<Funcionario> BuscarPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Funcionario>> BuscarTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Funcionario> CadastrarAsync(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public Task<Funcionario> RemoverAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
