using Model.Entities;
using Repositories;

namespace Services
{
    public interface IPerfilService
    {
        Task<string> BuscarAsync(int id);
        Task AtualizarAsync(string perfil);
        Task RegistrarAsync(string perfil);
        Task RecuperarSenhaAsync(string email);
    }

    public class PerfilService : IPerfilService
    {
        private readonly IClienteRepository _repository;

        public PerfilService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public Task<string> BuscarAsync(int id) { throw new NotImplementedException(); }
        //   _repository.BuscarAsync(id);

        public Task AtualizarAsync(string perfil) { throw new NotImplementedException(); }
        //    _repository.AtualizarAsync(perfil);

        public Task RegistrarAsync(string perfil) { throw new NotImplementedException(); }
        //    _repository.RegistrarAsync(perfil);

        public Task RecuperarSenhaAsync(string email)
        {
            // Lógica para recuperação de senha
            return Task.CompletedTask;
        }
    }

}
