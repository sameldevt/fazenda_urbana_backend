using Data;
using Model.Entities;

namespace Repositories
{
    public interface IFaleConoscoRepository
    {
        FaleConosco RegistrarFaleConoscoMensagem(FaleConosco faleConosco);
    }

    public class FaleConoscoRepository : IFaleConoscoRepository
    {
        private readonly ApplicationDbContext _context;

        public FaleConoscoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public FaleConosco RegistrarFaleConoscoMensagem(FaleConosco faleConosco)
        {
            _context.FaleConosco.Add(faleConosco);
            _context.SaveChanges();

            return faleConosco;
        }
    }
}
