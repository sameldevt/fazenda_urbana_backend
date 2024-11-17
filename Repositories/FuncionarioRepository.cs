using Data;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Model.Entities;

namespace Repositories
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionario>> BuscarTodosAsync();
        Task<Funcionario> BuscarPorIdAsync(int id);
        Task<Funcionario> BuscarPorEmailAsync(string email);
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

        public async Task<Funcionario> AtualizarAsync(Funcionario funcionario)
        {
            try
            {
                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();
                return funcionario;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao atualizar funcionário. Causa: ${ex}.");
            }
        }

        public async Task<Funcionario> AtualizarSenhaAsync(Funcionario funcionario)
        {
            var funcionarioBanco = await _context.Funcionarios
                            .Include(f => f.Contato)
                            .Include(f => f.Enderecos)
                            .Include(f => f.Fazenda)
                            .FirstOrDefaultAsync(f => f.Id == funcionario.Id);

            try
            {
                _context.Funcionarios.Update(funcionarioBanco);
                await _context.SaveChangesAsync();
                return funcionarioBanco;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao atualizar a senha do funcionário. Causa: ${ex}.");
            }
        }

        public async Task<Funcionario> BuscarPorIdAsync(int id)
        {
            var funcionario = await _context.Funcionarios
                        .Include(f => f.Contato)
                        .Include(f => f.Enderecos)
                        .Include(f => f.Fazenda)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(f => f.Id == id);

            if (funcionario == null)
            {
                throw new ResourceNotFoundException($"Funcionário com id {id} não encontrado.");
            }

            return funcionario;
        }

        public async Task<IEnumerable<Funcionario>> BuscarTodosAsync()
        {
            var funcionarios = await _context.Funcionarios
                        .AsNoTracking()
                        .Include(f => f.Contato)
                        .Include(f => f.Enderecos)
                        .Include(f => f.Fazenda)
                        .ToListAsync();

            if (funcionarios.IsNullOrEmpty())
            {
                throw new ResourceNotFoundException("Nenhum funcionário encontrado.");
            }

            return funcionarios;
        }

        public async Task<Funcionario> CadastrarAsync(Funcionario funcionario)
        {
            try
            {
                _context.Funcionarios.Add(funcionario);
                await _context.SaveChangesAsync();
                return funcionario;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao cadastrar funcionário. Causa: ${ex}.");
            }
        }

        public async Task<Funcionario> RemoverAsync(int id)
        {
            var funcionario = await _context.Funcionarios
                          .Include(c => c.Contato)
                          .Include(c => c.Enderecos)
                          .Include(f => f.Fazenda)
                          .FirstOrDefaultAsync(c => c.Id == id);

            if (funcionario == null)
            {
                throw new ResourceNotFoundException($"Funcionario com id {id} não encontrado.");
            }

            try
            {
                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();
                return funcionario;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao remover funcionario. Causa: ${ex}.");
            }
        }

        public async Task<Funcionario> BuscarPorEmailAsync(string email)
        {
            var funcionario = await _context.Funcionarios
                      .Include(f => f.Contato)
                      .Include(f => f.Enderecos)
                      .Include(f => f.Fazenda)
                      .FirstOrDefaultAsync(f => f.Contato.Email == email);

            return funcionario;
        }
    }
}
