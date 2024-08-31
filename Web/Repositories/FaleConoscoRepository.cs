using _.Data;
using _.Web.Models;

namespace _.Web.Repositories
{
    public interface IFaleConoscoRepository
    {
        void RegistrarFaleConoscoMensagem(FaleConosco faleConosco);
    }

    public class FaleConoscoRepository : IFaleConoscoRepository
    {
        private readonly ApplicationDbContext _context;
        public FaleConoscoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void RegistrarFaleConoscoMensagem(FaleConosco faleConosco)
        {
            _context.FaleConosco.Add(faleConosco);
            _context.SaveChanges();
        }
    }
}
