using Data;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Model.Entities;

namespace Repositories
{
    public interface ICulturaRepository
    {
        Task<IEnumerable<Cultura>> BuscarTodosAsync();
        Task<Cultura> BuscarPorIdAsync(int id);
        Task<Cultura> CadastrarAsync(Cultura cultura);
        Task<Cultura> AtualizarAsync(Cultura cultura);
        Task<Cultura> RemoverAsync(int id);
    }
    public class CulturaRepository : ICulturaRepository
    {
        private readonly ApplicationDbContext _context;

        public CulturaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cultura> AtualizarAsync(Cultura cultura)
        {
            try
            {
                _context.Culturas.Update(cultura);
                await _context.SaveChangesAsync();
                return cultura;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao atualizar cultura. Causa: ${ex}.");
            }
        }

        public async Task<Cultura> BuscarPorIdAsync(int id)
        {
            var cultura = await _context.Culturas
                          .AsNoTracking()
                          .Include(c => c.Colheitas)
                          .FirstOrDefaultAsync(i => i.Id == id);

            if (cultura == null)
            {
                throw new ResourceNotFoundException($"Cultura com id {id} não encontrada.");
            }

            return cultura;
        }

        public async Task<IEnumerable<Cultura>> BuscarTodosAsync()
        {
            var culturas = await _context.Culturas
                            .AsNoTracking()
                            .Include(c => c.Colheitas)
                            .ToListAsync();

            if (culturas.IsNullOrEmpty())
            {
                throw new ResourceNotFoundException("Nenhuma cultura encontrado.");
            }

            return culturas;
        }

        public async Task<Cultura> CadastrarAsync(Cultura cultura)
        {
            try
            {
                _context.Culturas.Add(cultura);
                await _context.SaveChangesAsync();
                return cultura;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao cadastrar cultura. Causa: ${ex}.");
            }
        }

        public async Task<Cultura> RemoverAsync(int id)
        {
            var cultura = await BuscarPorIdAsync(id);

            try
            {
                _context.Culturas.Remove(cultura);
                await _context.SaveChangesAsync();
                return cultura;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao remover cultura. Causa: ${ex}.");
            }
        }
    }
}
