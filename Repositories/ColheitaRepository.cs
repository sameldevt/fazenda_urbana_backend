using Data;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Model.Entities;

namespace Repositories
{
    public interface IColheitaRepository
    {
        Task<IEnumerable<Colheita>> BuscarTodosAsync();
        Task<Colheita> BuscarPorIdAsync(int id);
        Task<Colheita> CadastrarAsync(Colheita colheita);
        Task<Colheita> AtualizarAsync(Colheita colheita);
        Task<Colheita> RemoverAsync(int id);
    }
    public class ColheitaRepository : IColheitaRepository
    {
        private readonly ApplicationDbContext _context;

        public ColheitaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Colheita> AtualizarAsync(Colheita colheita)
        {
            try
            {
                _context.Colheitas.Update(colheita);
                await _context.SaveChangesAsync();
                return colheita;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao atualizar colheita. Causa: ${ex}.");
            }
        }

        public async Task<Colheita> BuscarPorIdAsync(int id)
        {
            var colheita = await _context.Colheitas
                .AsNoTracking()
                .Include(c => c.Produto)
                .Include(c => c.Cultura)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (colheita == null)
            {
                throw new ResourceNotFoundException($"Colheita com id {id} não encontrada.");
            }

            return colheita;
        }

        public async Task<IEnumerable<Colheita>> BuscarTodosAsync()
        {
            var colheitas = await _context.Colheitas
                .AsNoTracking()
                .Include(c => c.Produto)
                .Include(c => c.Cultura)
                .ToListAsync();

            if (colheitas.IsNullOrEmpty())
            {
                throw new ResourceNotFoundException("Nenhuma colheita encontrada.");
            }

            return colheitas;
        }

        public async Task<Colheita> CadastrarAsync(Colheita colheita)
        {
            try
            {
                _context.Colheitas.Add(colheita);
                await _context.SaveChangesAsync();
                return colheita;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao cadastrar colheita. Causa: ${ex}.");
            }
        }

        public async Task<Colheita> RemoverAsync(int id)
        {
            var colheita = await BuscarPorIdAsync(id);

            try
            {
                _context.Colheitas.Remove(colheita);
                await _context.SaveChangesAsync();
                return colheita;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao remover colheita. Causa: ${ex}.");
            }
        }
    }
}
