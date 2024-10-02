using Data;
using Exceptions;
using Model.Entities;

namespace Repositories
{
    public interface IFaleConoscoRepository
    {
        Task<FaleConosco> RegistrarFaleConoscoMensagem(FaleConosco faleConosco);
    }

    public class FaleConoscoRepository : IFaleConoscoRepository
    {
        private readonly ApplicationDbContext _context;

        public FaleConoscoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FaleConosco> RegistrarFaleConoscoMensagem(FaleConosco faleConosco)
        {
            try
            {
                _context.FaleConosco.Add(faleConosco);
                await _context.SaveChangesAsync();
                return faleConosco;
            }

            catch (Exception ex) 
            {
                throw new DatabaseManipulationException($"Erro ao registrar mensagem de fale conosco. Causa: ${ex}.");
            }

        }
    }
}
