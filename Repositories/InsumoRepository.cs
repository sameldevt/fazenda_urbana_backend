using Data;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Model.Entities;
using Repositories;

namespace Repositories
{
    public interface IInsumoRepository
    {
        Task<IEnumerable<Insumo>> BuscarTodosAsync();
        Task<Insumo> BuscarPorIdAsync(int id);
        Task<Insumo> CadastrarAsync(Insumo insumo);
        Task<Insumo> AtualizarAsync(Insumo insumo);
        Task<Insumo> RemoverAsync(int id);
    }

    public class InsumoRepository : IInsumoRepository
    {
        private readonly ApplicationDbContext _context;

        public InsumoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Insumo> AtualizarAsync(Insumo insumo)
        {
            try
            {
                _context.Insumos.Update(insumo);
                await _context.SaveChangesAsync();
                return insumo;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao atualizar insumo. Causa: ${ex}.");
            }
        }

        public async Task<Insumo> BuscarPorIdAsync(int id)
        {
            var insumo = await _context.Insumos
                .AsNoTracking()
                .Include(i => i.Fornecedor)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (insumo == null)
            {
                throw new ResourceNotFoundException($"Insumo com id {id} não encontrado.");
            }

            return insumo;
        }

        public async Task<IEnumerable<Insumo>> BuscarTodosAsync()
        {
            var insumos = await _context.Insumos
                .AsNoTracking()
                .Include(i => i.Fornecedor)
                .ToListAsync();

            if(insumos.IsNullOrEmpty())
            {
                throw new ResourceNotFoundException("Nenhum insumo encontrado.");
            }

            return insumos;
        }

        public async Task<Insumo> CadastrarAsync(Insumo insumo)
        {
            try
            {
                _context.Insumos.Add(insumo);
                await _context.SaveChangesAsync();
                return insumo;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao cadastrar insumo. Causa: ${ex}.");
            }
        }

        public async Task<Insumo> RemoverAsync(int id)
        {
            var insumo = await BuscarPorIdAsync(id);

            try
            {
                _context.Insumos.Remove(insumo);
                await _context.SaveChangesAsync();
                return insumo;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao remover insumo. Causa: ${ex}.");
            }
        }
    }
}
