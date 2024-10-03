using AutoMapper;
using Exceptions;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IUsuarioService
    {
        Task<bool> Registrar(RegistrarUsuarioDto registrarUsuarioDto);
        Task<bool> Entrar(EntrarUsuarioDto entrarUsuarioDto);
        Task<bool> RecuperarSenha(RecuperarSenhaDto recuperarSenhaDto);
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

        public async Task<bool> Entrar(EntrarUsuarioDto entrarUsuarioDto)
        {
            var usuario = await VerificarExistenciaUsuario(entrarUsuarioDto.Email);

            if (usuario == null)
            {
                throw new ResourceNotFoundException($"Usuário com e-mail {entrarUsuarioDto.Email} não encontrado.");
            }

            if (usuario.Senha != entrarUsuarioDto.Senha)
            {
                throw new InvalidCredentialsException("Senha inválida.");
            }

            return true;
        }

        public async Task<bool> RecuperarSenha(RecuperarSenhaDto recuperarSenhaDto)
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

            usuario = _mapper.Map<Cliente>(recuperarSenhaDto);

            await _clienteRepository.AtualizarSenhaAsync(usuario);

            return true;
        }

        public async Task<bool> Registrar(RegistrarUsuarioDto registrarUsuarioDto)
        {
            var usuario = await VerificarExistenciaUsuario(registrarUsuarioDto.Email);

            if(usuario != null)
            {
                throw new UserAlreadyRegisteredException("Usuário já registrado.");
            }

            usuario = _mapper.Map<Cliente>(registrarUsuarioDto);

            await _clienteRepository.CadastrarAsync(usuario);

            return true;
        }

        private async Task<Cliente> VerificarExistenciaUsuario(string email)
        {
            return await _clienteRepository.BuscarPorEmailAsync(email);
        }
    }
}