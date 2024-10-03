using AutoMapper;
using Exceptions;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IMensagemContatoService
    {
        Task<VisualizarMensagemDto> CadastrarMensagemAsync(RegistrarMensagemDto cadastrarMensagemDto);
        Task<List<VisualizarMensagemDto>> BuscarTodasMensagensAsync();
        Task<VisualizarMensagemDto> BuscarMensagemPorIdAsync(int id);
        Task<VisualizarMensagemDto> AtualizarMensagemAsync(AtualizarMensagemDto atualizarMensagemDto);
        Task<VisualizarMensagemDto> RemoverMensagemAsync(int id);
    }

    public class MensagemContatoService : IMensagemContatoService
    {
        private readonly IMensagemContatoRepository _mensagemContatoRepository;
        private readonly IMapper _mapper;

        public MensagemContatoService(IMensagemContatoRepository mensagemContatoRepository, IMapper mapper)
        {
            _mensagemContatoRepository = mensagemContatoRepository;
            _mapper = mapper;
        }

        public async Task<VisualizarMensagemDto> CadastrarMensagemAsync(RegistrarMensagemDto cadastrarMensagemDto)
        {
            var mensagemContato = _mapper.Map<MensagemContato>(cadastrarMensagemDto);

            var mensagemContatoRegistrada = await _mensagemContatoRepository.CadastrarAsync(mensagemContato);

            return _mapper.Map<VisualizarMensagemDto>(mensagemContatoRegistrada);
        }

        public async Task<List<VisualizarMensagemDto>> BuscarTodasMensagensAsync()
        {
            var mensagens = await _mensagemContatoRepository.BuscarTodasAsync();
            return _mapper.Map<List<VisualizarMensagemDto>>(mensagens);
        }

        public async Task<VisualizarMensagemDto> BuscarMensagemPorIdAsync(int id)
        {
            var mensagem = await _mensagemContatoRepository.BuscarPorIdAsync(id);
            return _mapper.Map<VisualizarMensagemDto>(mensagem);
        }

        public async Task<VisualizarMensagemDto> AtualizarMensagemAsync(AtualizarMensagemDto atualizarMensagemDto)
        {
            var mensagemExistente = await _mensagemContatoRepository.BuscarPorIdAsync(atualizarMensagemDto.Id);

            mensagemExistente = _mapper.Map<MensagemContato>(atualizarMensagemDto);

            var mensagemAtualizada = await _mensagemContatoRepository.AtualizarAsync(mensagemExistente);
            return _mapper.Map<VisualizarMensagemDto>(mensagemAtualizada);
        }

        public async Task<VisualizarMensagemDto> RemoverMensagemAsync(int id)
        {
            var mensagemRemovida = await _mensagemContatoRepository.RemoverAsync(id);
            return _mapper.Map<VisualizarMensagemDto>(mensagemRemovida);
        }
    }
}
