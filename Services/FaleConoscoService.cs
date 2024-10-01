using Model.Entities;
using Repositories;

namespace Services
{
    public interface IFaleConoscoService
    {
        FaleConosco EnviarMensagemAsync(FaleConosco mensagem);
    }

    public class FaleConoscoService : IFaleConoscoService
    {
        private readonly IFaleConoscoRepository _faleConoscoRepository;
        public FaleConoscoService(IFaleConoscoRepository faleConoscoRepository)
        {
            _faleConoscoRepository = faleConoscoRepository;
        }

        public FaleConosco EnviarMensagemAsync(FaleConosco mensagem)
        {
            return _faleConoscoRepository.RegistrarFaleConoscoMensagem(mensagem);
        }
    }

}
