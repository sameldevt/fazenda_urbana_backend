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
        Task<ClienteDto> CadastrarEndereco(CadastrarEnderecoDto cadastrarEnderecoDto);
        Task<List<PedidoDto>> BuscarPedidos(int id);
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

        public async Task<ClienteDto> CadastrarEndereco(CadastrarEnderecoDto cadastrarEnderecoDto)
        {
            var usuario = await VerificarExistenciaUsuario(cadastrarEnderecoDto.Email);

            if (usuario == null)
            {
                throw new ResourceNotFoundException($"Usu�rio com e-mail {cadastrarEnderecoDto.Email} n�o encontrado.");
            }

            usuario.Enderecos.Add(_mapper.Map<Endereco>(cadastrarEnderecoDto));

            await _clienteRepository.AtualizarSenhaAsync(usuario);

            return _mapper.Map<ClienteDto>(usuario);

        }

        public async Task<ClienteDto> Entrar(EntrarUsuarioDto entrarUsuarioDto)
        {
            var usuario = await VerificarExistenciaUsuario(entrarUsuarioDto.Email);

            if (usuario == null)
            {
                throw new ResourceNotFoundException($"Usu�rio com e-mail {entrarUsuarioDto.Email} n�o encontrado.");
            }

            //var senhaDesencriptada = AesEncryption.Decrypt(usuario.Senha);

            //if (senhaDesencriptada != entrarUsuarioDto.Senha)
            //{
            //    throw new InvalidCredentialsException("Senha inv�lida.");
            //}

            if(usuario.Senha != entrarUsuarioDto.Senha)
            {
                throw new InvalidCredentialsException("Senha inv�lida.");
            }

            return _mapper.Map<ClienteDto>(usuario);
        }

        public async Task<ClienteDto> RecuperarSenha(RecuperarSenhaDto recuperarSenhaDto)
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

            return _mapper.Map<ClienteDto>(usuario);
        }

        public async Task<ClienteDto> Registrar(CadastrarUsuarioDto registrarUsuarioDto)
        {
            var usuario = await VerificarExistenciaUsuario(registrarUsuarioDto.Contato.Email);

            if(usuario != null)
            {
                throw new UserAlreadyRegisteredException("Usu�rio j� registrado.");
            }

            usuario = _mapper.Map<Cliente>(registrarUsuarioDto);

            //usuario.Senha = AesEncryption.Encrypt(usuario.Senha);
            usuario.Senha = registrarUsuarioDto.Senha;

            await _clienteRepository.CadastrarAsync(usuario);

            return _mapper.Map<ClienteDto>(usuario);
        }

        private async Task<Cliente> VerificarExistenciaUsuario(string email)
        {
            return await _clienteRepository.BuscarPorEmailAsync(email);
        }

        public async Task<List<PedidoDto>> BuscarPedidos(int id)
        {
            var pedidos = await _clienteRepository.BuscarPedidosPorIdAsync(id);

            return _mapper.Map<List<PedidoDto>>(pedidos);
        }
    }
}