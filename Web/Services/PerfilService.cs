using _.Web.Models;
using _.Web.Repositories;

namespace _.Web.Services
{
    public interface IPerfilService
    {
        Task<Perfil> BuscarAsync(int id);
        Task AtualizarAsync(Perfil perfil);
        Task RegistrarAsync(Perfil perfil);
        Task RecuperarSenhaAsync(string email);
    }

    public class PerfilService : IPerfilService
    {
        private readonly IPerfilRepository _repository;

        public PerfilService(IPerfilRepository repository)
        {
            _repository = repository;
        }

        public Task<Perfil> BuscarAsync(int id) =>
            _repository.BuscarAsync(id);

        public Task AtualizarAsync(Perfil perfil) =>
            _repository.AtualizarAsync(perfil);

        public Task RegistrarAsync(Perfil perfil) =>
            _repository.RegistrarAsync(perfil);

        public Task RecuperarSenhaAsync(string email)
        {
            // Lógica para recuperação de senha
            return Task.CompletedTask;
        }
    }

}
