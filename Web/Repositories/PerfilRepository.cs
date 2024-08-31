using _.Data;
using _.Web.Models;

namespace _.Web.Repositories
{
    public interface IPerfilRepository
    {
        Task<Perfil> BuscarAsync(int id);
        Task AtualizarAsync(Perfil perfil);
        Task RegistrarAsync(Perfil perfil);
    }

    public class PerfilRepository : IPerfilRepository
    {
        private readonly ApplicationDbContext _context;

        public PerfilRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Perfil> BuscarAsync(int id) =>
            await _context.Perfils.FindAsync(id);

        public async Task AtualizarAsync(Perfil perfil)
        {
            _context.Perfils.Update(perfil);
            await _context.SaveChangesAsync();
        }

        public async Task RegistrarAsync(Perfil perfil)
        {
            _context.Perfils.Add(perfil);
            await _context.SaveChangesAsync();
        }
    }

}
