using AutoMapper;
using Exceptions;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IMensagemContatoService
    {
        Task<MensagemContatoDto> CadastrarMensagemAsync(CadastrarMensagemContatoDto cadastrarMensagemDto);
        Task<List<MensagemContatoDto>> BuscarTodasMensagensAsync();
        Task<MensagemContatoDto> BuscarMensagemPorIdAsync(int id);
        Task<MensagemContatoDto> AtualizarMensagemAsync(MensagemContatoDto atualizarMensagemDto);
        Task<MensagemContatoDto> RemoverMensagemAsync(int id);
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

        public async Task<MensagemContatoDto> CadastrarMensagemAsync(CadastrarMensagemContatoDto cadastrarMensagemDto)
        {
            var mensagemContato = _mapper.Map<MensagemContato>(cadastrarMensagemDto);

            var mensagemContatoRegistrada = await _mensagemContatoRepository.CadastrarAsync(mensagemContato);

            return _mapper.Map<MensagemContatoDto>(mensagemContatoRegistrada);
        }

        public async Task<List<MensagemContatoDto>> BuscarTodasMensagensAsync()
        {
            var mensagens = await _mensagemContatoRepository.BuscarTodasAsync();
            return _mapper.Map<List<MensagemContatoDto>>(mensagens);
        }

        public async Task<MensagemContatoDto> BuscarMensagemPorIdAsync(int id)
        {
            var mensagem = await _mensagemContatoRepository.BuscarPorIdAsync(id);
            return _mapper.Map<MensagemContatoDto>(mensagem);
        }

        public async Task<MensagemContatoDto> AtualizarMensagemAsync(MensagemContatoDto atualizarMensagemDto)
        {
            var mensagemExistente = await _mensagemContatoRepository.BuscarPorIdAsync(atualizarMensagemDto.Id);

            mensagemExistente = _mapper.Map<MensagemContato>(atualizarMensagemDto);

            var mensagemAtualizada = await _mensagemContatoRepository.AtualizarAsync(mensagemExistente);
            return _mapper.Map<MensagemContatoDto>(mensagemAtualizada);
        }

        public async Task<MensagemContatoDto> RemoverMensagemAsync(int id)
        {
            var mensagemRemovida = await _mensagemContatoRepository.RemoverAsync(id);
            return _mapper.Map<MensagemContatoDto>(mensagemRemovida);
        }
    }
}
