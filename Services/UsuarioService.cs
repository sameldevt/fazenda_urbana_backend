using AutoMapper;
using Exceptions;
using Model.Dtos;
using Model.Entities;
using Repositories;
using Model.Common;
using Encrypt;
using Logging;

namespace Services
{
    public interface IUsuarioService
    {
        Task<ClienteDto> Registrar(CadastrarUsuarioDto registrarUsuarioDto);
        Task<ClienteDto> Entrar(EntrarUsuarioDto entrarUsuarioDto);
        Task<ClienteDto> RecuperarSenha(RecuperarSenhaDto recuperarSenhaDto);
    }

    public class UsuarioService : IUsuarioService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteDto> Entrar(EntrarUsuarioDto entrarUsuarioDto)
        {
            var usuario = await VerificarExistenciaUsuario(entrarUsuarioDto.Email);

            if (usuario == null)
            {
                throw new ResourceNotFoundException($"Usuário com e-mail {entrarUsuarioDto.Email} não encontrado.");
            }

            var senhaDesencriptada = AesEncryption.Decrypt(usuario.Senha);

            if (senhaDesencriptada != entrarUsuarioDto.Senha)
            {
                throw new InvalidCredentialsException("Senha inválida.");
            }

            return _mapper.Map<ClienteDto>(usuario);
        }

        public async Task<ClienteDto> RecuperarSenha(RecuperarSenhaDto recuperarSenhaDto)
        {
            var usuario = await VerificarExistenciaUsuario(recuperarSenhaDto.Email);

            if (usuario == null)
            {
                throw new ResourceNotFoundException($"Usuário com e-mail {recuperarSenhaDto.Email} não encontrado.");
            }

            if (usuario.Contato.Email != recuperarSenhaDto.Email)
            {
                throw new InvalidCredentialsException("E-mail inválido.");
            }

            usuario.Senha = recuperarSenhaDto.NovaSenha;

            await _clienteRepository.AtualizarSenhaAsync(usuario);

            return _mapper.Map<ClienteDto>(usuario);
        }

        public async Task<ClienteDto> Registrar(CadastrarUsuarioDto registrarUsuarioDto)
        {
            var usuario = await VerificarExistenciaUsuario(registrarUsuarioDto.Contato.Email);

            if(usuario != null)
            {
                throw new UserAlreadyRegisteredException("Usuário já registrado.");
            }

            usuario = _mapper.Map<Cliente>(registrarUsuarioDto);

            usuario.Senha = AesEncryption.Encrypt(usuario.Senha);

            await _clienteRepository.CadastrarAsync(usuario);

            return _mapper.Map<ClienteDto>(usuario);
        }

        private async Task<Cliente> VerificarExistenciaUsuario(string email)
        {
            return await _clienteRepository.BuscarPorEmailAsync(email);
        }
    }
}