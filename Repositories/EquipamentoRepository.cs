using Data;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Model.Entities;

namespace Repositories
{
    public interface IEquipamentoRepository
    {
        Task<IEnumerable<Equipamento>> BuscarTodosAsync();
        Task<Equipamento> BuscarPorIdAsync(int id);
        Task<Equipamento> CadastrarAsync(Equipamento equipamento);
        Task<Equipamento> AtualizarAsync(Equipamento equipamento);
        Task<Equipamento> RemoverAsync(int id);
    }
    public class EquipamentoRepository : IEquipamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public EquipamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Equipamento> AtualizarAsync(Equipamento equipamento)
        {
            try
            {
                _context.Equipamentos.Update(equipamento);
                await _context.SaveChangesAsync();
                return equipamento;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao atualizar equipamento. Causa: ${ex}.");
            }
        }

        public async Task<Equipamento> BuscarPorIdAsync(int id)
        {
            var equipamento = await _context.Equipamentos
                           .AsNoTracking()
                           .Include(e => e.Fornecedor)
                           .Include(e => e.Fazenda)
                           .FirstOrDefaultAsync(i => i.Id == id);

            if (equipamento == null)
            {
                throw new ResourceNotFoundException($"Equipamento com id {id} não encontrado.");
            }

            return equipamento;
        }

        public async Task<IEnumerable<Equipamento>> BuscarTodosAsync()
        {
            var equipamentos = await _context.Equipamentos
                          .AsNoTracking()
                          .Include(e => e.Fornecedor)
                          .Include(e => e.Fazenda)
                          .ToListAsync();

            if (equipamentos.IsNullOrEmpty())
            {
                throw new ResourceNotFoundException("Nenhum equipamento encontrado.");
            }

            return equipamentos;
        }

        public async Task<Equipamento> CadastrarAsync(Equipamento equipamento)
        {
            try
            {
                _context.Equipamentos.Add(equipamento);
                await _context.SaveChangesAsync();
                return equipamento;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao cadastrar equipamento. Causa: ${ex}.");
            }
        }

        public async Task<Equipamento> RemoverAsync(int id)
        {
            var equipamento = await BuscarPorIdAsync(id);

            try
            {
                _context.Equipamentos.Remove(equipamento);
                await _context.SaveChangesAsync();
                return equipamento;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao remover equipamento. Causa: ${ex}.");
            }
        }
    }
}
