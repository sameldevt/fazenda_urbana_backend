using Model.Entities;

namespace Model.Dtos
{
    public interface IClienteDto : IDto { }

    public class ClienteDtoFactory
    {
        public static IClienteDto Criar(TipoDto tipoDto, Cliente cliente)
        {
            return tipoDto switch
            {
                TipoDto.Visualizar => new VisualizarClienteDto(cliente),
                TipoDto.Cadastrar => new CadastrarClienteDto(cliente),
                TipoDto.Atualizar => new AtualizarClienteDto(cliente)
            };
        }
    }

    public record VisualizarClienteDto : IClienteDto
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public string Telefone { get; init; }
        public string Email { get; init; }
        public string Logradouro { get; init; }
        public string Numero { get; init; }
        public string Cidade { get; init; }
        public string CEP { get; init; }
        public string Complemento { get; init; }
        public string Estado { get; init; }
        public string InformacoesAdicionais { get; init; }

        public VisualizarClienteDto() { }

        public VisualizarClienteDto(Cliente cliente) : this()
        {
            Id = cliente.Id;
            Nome = cliente.Nome;
            Telefone = cliente.Contato?.Telefone ?? "Telefone indispon�vel.";
            Email = cliente.Contato?.Email ?? "Email indispon�vel.";
            Logradouro = cliente.Endereco?.Logradouro ?? "Logradouro indispon�vel.";
            Numero = cliente.Endereco?.Numero ?? "N�mero indispon�vel.";
            Cidade = cliente.Endereco?.Cidade ?? "Cidade indispon�vel.";
            CEP = cliente.Endereco?.CEP ?? "CEP indispon�vel.";
            Complemento = cliente.Endereco?.Complemento ?? "Complemento indispon�vel.";
            Estado = cliente.Endereco?.Estado ?? "Estado indispon�vel.";
            InformacoesAdicionais = cliente.Endereco?.InformacoesAdicionais ?? "Informa��es adicionais indispon�veis.";
        }
    }

    public record CadastrarClienteDto : IClienteDto
    {
        public string Nome { get; init; }
        public string Senha { get; init; }
        public string Telefone { get; init; }
        public string Email { get; init; }
        public string Logradouro { get; init; }
        public string Numero { get; init; }
        public string Cidade { get; init; }
        public string CEP { get; init; }
        public string Complemento { get; init; }
        public string Estado { get; init; }
        public string InformacoesAdicionais { get; init; }

        public CadastrarClienteDto() { }

        public CadastrarClienteDto(Cliente cliente) : this()
        {
            Nome = cliente.Nome;
            Senha = cliente.Senha;
            Telefone = cliente.Contato.Telefone;
            Email = cliente.Contato.Email;
            Logradouro = cliente.Endereco.Logradouro;
            Numero = cliente.Endereco.Numero;
            Cidade = cliente.Endereco.Cidade;
            CEP = cliente.Endereco.CEP;
            Complemento = cliente.Endereco.Complemento;
            Estado = cliente.Endereco.Estado;
            InformacoesAdicionais = cliente.Endereco.InformacoesAdicionais;
        }
    }

    public record AtualizarClienteDto : IClienteDto
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public string Telefone { get; init; }
        public string Email { get; init; }
        public string Logradouro { get; init; }
        public string Numero { get; init; }
        public string Cidade { get; init; }
        public string CEP { get; init; }
        public string Complemento { get; init; }
        public string Estado { get; init; }
        public string InformacoesAdicionais { get; init; }

        public AtualizarClienteDto() { }

        public AtualizarClienteDto(Cliente cliente) : this()
        {
            Id = cliente.Id;
            Nome = cliente.Nome;
            Telefone = cliente.Contato.Telefone;
            Email = cliente.Contato.Email;
            Logradouro = cliente.Endereco.Logradouro;
            Numero = cliente.Endereco.Numero;
            Cidade = cliente.Endereco.Cidade;
            CEP = cliente.Endereco.CEP;
            Complemento = cliente.Endereco.Complemento;
            Estado = cliente.Endereco.Estado;
            InformacoesAdicionais = cliente.Endereco.InformacoesAdicionais;
        }
    }

}