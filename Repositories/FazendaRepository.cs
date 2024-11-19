using Data;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Model.Entities;

namespace Repositories
{
    public interface IFazendaRepository
    {
        Task<IEnumerable<Fazenda>> BuscarTodosAsync();
        Task<Fazenda> BuscarPorIdAsync(int id);
        Task<Fazenda> CadastrarAsync(Fazenda fazenda);
        Task<Fazenda> AtualizarAsync(Fazenda fazenda);
        Task<Fazenda> RemoverAsync(int id);
    }
    public class FazendaRepository : IFazendaRepository
    {
        private readonly ApplicationDbContext _context;
        
        public FazendaRepository(ApplicationDbContext context) 
        {
            _context = context; 
        }

        public async Task<Fazenda> AtualizarAsync(Fazenda fazenda)
        {
            try
            {
                _context.Fazendas.Update(fazenda);
                await _context.SaveChangesAsync();
                return fazenda;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao atualizar fazenda. Causa: ${ex}.");
            }
        }

        public async Task<Fazenda> BuscarPorIdAsync(int id)
        {
            var fazenda = await _context.Fazendas
                           .AsNoTracking()
                           .Include(f => f.Funcionarios)
                           .Include(f => f.Equipamentos)
                           .Include(f => f.Culturas)
                           .FirstOrDefaultAsync(i => i.Id == id);

            if (fazenda == null)
            {
                throw new ResourceNotFoundException($"Fazenda com id {id} não encontrada.");
            }

            return fazenda;
        }

        public async Task<IEnumerable<Fazenda>> BuscarTodosAsync()
        {
            var fazendas = await _context.Fazendas
                           .AsNoTracking()
                           .Include(f => f.Funcionarios)
                           .Include(f => f.Equipamentos)
                           .Include(f => f.Culturas)
                           .ToListAsync();

            if (fazendas.IsNullOrEmpty())
            {
                throw new ResourceNotFoundException("Nenhuma fazenda encontrada.");
            }

            return fazendas;
        }

        public async Task<Fazenda> CadastrarAsync(Fazenda fazenda)
        {
            try
            {
                _context.Fazendas.Add(fazenda);
                await _context.SaveChangesAsync();
                return fazenda;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao cadastrar fazenda. Causa: ${ex}.");
            }
        }

        public async Task<Fazenda> RemoverAsync(int id)
        {
            var fazenda = await BuscarPorIdAsync(id);

            try
            {
                _context.Fazendas.Remove(fazenda);
                await _context.SaveChangesAsync();
                return fazenda;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao remover fazenda. Causa: ${ex}.");
            }
        }
    }
}
