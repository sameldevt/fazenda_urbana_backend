using AutoMapper;
using Exceptions;
using Model.Dtos;
using Model.Entities;
using Repositories;
using Model.Common;

namespace Services
{
    public interface IUsuarioService
    {
        Task<VisualizarClienteDto> Registrar(RegistrarUsuarioDto registrarUsuarioDto);
        Task<VisualizarClienteDto> Entrar(EntrarUsuarioDto entrarUsuarioDto);
        Task<VisualizarClienteDto> RecuperarSenha(RecuperarSenhaDto recuperarSenhaDto);
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

        public async Task<VisualizarClienteDto> Entrar(EntrarUsuarioDto entrarUsuarioDto)
        {
            var usuario = await VerificarExistenciaUsuario(entrarUsuarioDto.Email);

            if (usuario == null)
            {
                throw new ResourceNotFoundException($"Usu�rio com e-mail {entrarUsuarioDto.Email} n�o encontrado.");
            }

            if (usuario.Senha != entrarUsuarioDto.Senha)
            {
                throw new InvalidCredentialsException("Senha inv�lida.");
            }

            return _mapper.Map<VisualizarClienteDto>(usuario);
        }

        public async Task<VisualizarClienteDto> RecuperarSenha(RecuperarSenhaDto recuperarSenhaDto)
        {
            var usuario = await VerificarExistenciaUsuario(recuperarSenhaDto.Email);

            if (usuario == null)
            {
                throw new ResourceNotFoundException($"Usu�rio com e-mail {recuperarSenhaDto.Email} n�o encontrado.");
            }

            if (usuario.Contato.Email != recuperarSenhaDto.Email)
            {
                throw new InvalidCredentialsException("E-mail inv�lido.");
            }

            usuario.Senha = recuperarSenhaDto.NovaSenha;

            await _clienteRepository.AtualizarSenhaAsync(usuario);

            return _mapper.Map<VisualizarClienteDto>(usuario);
        }

        public async Task<VisualizarClienteDto> Registrar(RegistrarUsuarioDto registrarUsuarioDto)
        {
            var usuario = await VerificarExistenciaUsuario(registrarUsuarioDto.Email);

            if(usuario != null)
            {
                throw new UserAlreadyRegisteredException("Usu�rio j� registrado.");
            }

            usuario = _mapper.Map<Cliente>(registrarUsuarioDto);

            await _clienteRepository.CadastrarAsync(usuario);

            return _mapper.Map<VisualizarClienteDto>(usuario);
        }

        private async Task<Cliente> VerificarExistenciaUsuario(string email)
        {
            return await _clienteRepository.BuscarPorEmailAsync(email);
        }
    }
}