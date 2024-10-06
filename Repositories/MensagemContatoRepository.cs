using Data;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Model.Dtos;
using Model.Entities;

namespace Repositories
{
    public interface IMensagemContatoRepository
    {
        Task<MensagemContato> CadastrarAsync(MensagemContato mensagemContato);
        Task<MensagemContato> BuscarPorIdAsync(int id);
        Task<List<MensagemContato>> BuscarTodasAsync();
        Task<MensagemContato> AtualizarAsync(MensagemContato mensagemContato);
        Task<MensagemContato> RemoverAsync(int id);
    }

    public class MensagemContatoRepository : IMensagemContatoRepository
    {
        private readonly ApplicationDbContext _context;

        public MensagemContatoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MensagemContato>> BuscarTodasAsync()
        {
            var mensagens = await _context.MensagensContato.AsNoTracking().ToListAsync();

            if (mensagens.IsNullOrEmpty())
            {
                throw new ResourceNotFoundException("Nenhuma mensagem encontrada.");
            }

            return mensagens;
        }

        public async Task<MensagemContato> BuscarPorIdAsync(int id)
        {
            var mensagem = await _context.MensagensContato.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (mensagem == null)
            {
                throw new ResourceNotFoundException($"Mensagem com id {id} não encontrada.");
            }

            return mensagem;
        }

        public async Task<MensagemContato> CadastrarAsync(MensagemContato mensagemContato)
        {
            try
            {
                _context.MensagensContato.Add(mensagemContato);
                await _context.SaveChangesAsync();
                return mensagemContato;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao cadastrar mensagem. Causa: {ex}.");
            }
        }

        public async Task<MensagemContato> AtualizarAsync(MensagemContato mensagemContato)
        {
            try
            {
                _context.MensagensContato.Update(mensagemContato);
                await _context.SaveChangesAsync();
                return mensagemContato;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao atualizar mensagem. Causa: {ex}.");
            }
        }

        public async Task<MensagemContato> RemoverAsync(int id)
        {
            var mensagem = await BuscarPorIdAsync(id);

            if (mensagem == null)
            {
                throw new ResourceNotFoundException($"Mensagem com id {id} não encontrada.");
            }

            try
            {
                _context.MensagensContato.Remove(mensagem);
                await _context.SaveChangesAsync();
                return mensagem;
            }
            catch (Exception ex)
            {
                throw new DatabaseManipulationException($"Erro ao remover mensagem. Causa: {ex}.");
            }
        }
    }
}
