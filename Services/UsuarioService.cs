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
        Task<ClienteDto> RegistrarCliente(CadastrarUsuarioDto registrarUsuarioDto);
        Task<ClienteDto> EntrarCliente(EntrarUsuarioDto entrarUsuarioDto);
        Task<FuncionarioDto> RegistrarFuncionario(CadastrarFuncionarioDto cadastrarFuncionarioDto);
        Task<FuncionarioDto> EntrarFuncionario(EntrarFuncionarioDto entrarFuncionarioDto);
        Task<ClienteDto> RecuperarSenhaCliente(RecuperarSenhaDto recuperarSenhaDto);
        Task<FuncionarioDto> RecuperarSenhaFuncionario(RecuperarSenhaDto recuperarSenhaDto);
        Task<ClienteDto> CadastrarEndereco(CadastrarEnderecoDto cadastrarEnderecoDto);
        Task<List<PedidoDto>> BuscarPedidos(int id);
    }

    public class UsuarioService : IUsuarioService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IClienteRepository clienteRepository, IFuncionarioRepository funcionarioRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        public async Task<ClienteDto> CadastrarEndereco(CadastrarEnderecoDto cadastrarEnderecoDto)
        {
            var usuario = await VerificarExistenciaUsuario(cadastrarEnderecoDto.Email);

            if (usuario == null)
            {
                throw new ResourceNotFoundException($"Usuário com e-mail {cadastrarEnderecoDto.Email} não encontrado.");
            }

            usuario.Enderecos.Add(_mapper.Map<Endereco>(cadastrarEnderecoDto));

            await _clienteRepository.AtualizarSenhaAsync(usuario);

            return _mapper.Map<ClienteDto>(usuario);

        }

        public async Task<ClienteDto> EntrarCliente(EntrarUsuarioDto entrarUsuarioDto)
        {
            var usuario = await VerificarExistenciaUsuario(entrarUsuarioDto.Email);

            if (usuario == null)
            {
                throw new ResourceNotFoundException($"Usuário com e-mail {entrarUsuarioDto.Email} não encontrado.");
            }

            //var senhaDesencriptada = AesEncryption.Decrypt(usuario.Senha);

            //if (senhaDesencriptada != entrarUsuarioDto.Senha)
            //{
            //    throw new InvalidCredentialsException("Senha inválida.");
            //}

            if(usuario.Senha != entrarUsuarioDto.Senha)
            {
                throw new InvalidCredentialsException("Senha inválida.");
            }

            return _mapper.Map<ClienteDto>(usuario);
        }

        public async Task<ClienteDto> RecuperarSenhaCliente(RecuperarSenhaDto recuperarSenhaDto)
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

        public async Task<ClienteDto> RegistrarCliente(CadastrarUsuarioDto registrarUsuarioDto)
        {
            var usuario = await VerificarExistenciaUsuario(registrarUsuarioDto.Contato.Email);

            if(usuario != null)
            {
                throw new UserAlreadyRegisteredException("Usuário já registrado.");
            }

            usuario = _mapper.Map<Cliente>(registrarUsuarioDto);

            //usuario.Senha = AesEncryption.Encrypt(usuario.Senha);
            usuario.Senha = registrarUsuarioDto.Senha;

            await _clienteRepository.CadastrarAsync(usuario);

            return _mapper.Map<ClienteDto>(usuario);
        }

        public async Task<FuncionarioDto> EntrarFuncionario(EntrarFuncionarioDto entrarFuncionarioDto)
        {
            var usuario = await VerificarExistenciaFuncionario(entrarFuncionarioDto.Email);

            if (usuario == null)
            {
                throw new ResourceNotFoundException($"Usuário com e-mail {entrarFuncionarioDto.Email} não encontrado.");
            }

            //var senhaDesencriptada = AesEncryption.Decrypt(usuario.Senha);

            //if (senhaDesencriptada != entrarUsuarioDto.Senha)
            //{
            //    throw new InvalidCredentialsException("Senha inválida.");
            //}

            if (usuario.Senha != entrarFuncionarioDto.Senha)
            {
                throw new InvalidCredentialsException("Senha inválida.");
            }

            return _mapper.Map<FuncionarioDto>(usuario);
        }

        public async Task<FuncionarioDto> RegistrarFuncionario(CadastrarFuncionarioDto cadastrarFuncionarioDto)
        {
            var usuario = await VerificarExistenciaFuncionario(cadastrarFuncionarioDto.Contato.Email);

            if (usuario != null)
            {
                throw new UserAlreadyRegisteredException("Usuário já registrado.");
            }

            usuario = _mapper.Map<Funcionario>(cadastrarFuncionarioDto);

            //usuario.Senha = AesEncryption.Encrypt(usuario.Senha);
            usuario.Senha = cadastrarFuncionarioDto.Senha;

            await _funcionarioRepository.CadastrarAsync(usuario);

            return _mapper.Map<FuncionarioDto>(usuario);
        }

        public async Task<FuncionarioDto> RecuperarSenhaFuncionario(RecuperarSenhaDto recuperarSenhaDto)
        {
            var funcionario = await VerificarExistenciaFuncionario(recuperarSenhaDto.Email);

            if (funcionario == null)
            {
                throw new ResourceNotFoundException($"Funcionário com e-mail {recuperarSenhaDto.Email} não encontrado.");
            }

            if (funcionario.Contato.Email != recuperarSenhaDto.Email)
            {
                throw new InvalidCredentialsException("E-mail inválido.");
            }

            funcionario.Senha = recuperarSenhaDto.NovaSenha;

            await _funcionarioRepository.AtualizarSenhaAsync(funcionario);

            return _mapper.Map<FuncionarioDto>(funcionario);
        }

        private async Task<Funcionario> VerificarExistenciaFuncionario(string email)
        {
            return await _funcionarioRepository.BuscarPorEmailAsync(email);
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