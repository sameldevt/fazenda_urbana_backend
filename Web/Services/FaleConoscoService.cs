using _.Web.Models;
using _.Web.Repositories;

namespace _.Web.Services
{
    public interface IFaleConoscoService
    {
        Task EnviarMensagemAsync(FaleConosco mensagem);
    }

    public class FaleConoscoService : IFaleConoscoService
    {
        private readonly IFaleConoscoRepository _faleConoscoRepository;
        public FaleConoscoService(IFaleConoscoRepository faleConoscoRepository) 
        {
            _faleConoscoRepository = faleConoscoRepository;
        }

        public Task EnviarMensagemAsync(FaleConosco mensagem)
        {
            _faleConoscoRepository.RegistrarFaleConoscoMensagem(mensagem);
            
            return Task.CompletedTask;
        }
    }

}
