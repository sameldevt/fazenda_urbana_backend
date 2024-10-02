using Model.Entities;

namespace Model.Dtos
{
    public enum ClienteDtoTipo
    {
        Visualizar,
        Cadastrar,
        Atualizar,
    }

    public interface IClienteDto { }

    public static class ClienteDtoFactory
    {
        public static IClienteDto Criar(ClienteDtoTipo tipoDto, Cliente cliente)
        {
            return tipoDto switch
            {
                ClienteDtoTipo.Visualizar => new VisualizarClienteDto(cliente),
                ClienteDtoTipo.Cadastrar => new CadastrarClienteDto(cliente),
                ClienteDtoTipo.Atualizar => new AtualizarClienteDto(cliente),
            };
        }
    }

    public record VisualizarClienteDto
   (
       int Id,
       string Nome,
       string Telefone,
       string Email,
       string Logradouro,
       string Numero,
       string Cidade,
       string CEP,
       string Complemento,
       string Estado,
       string InformacoesAdicionais
    ) : IClienteDto
    {
        public VisualizarClienteDto(Cliente cliente) : this(
             Id: cliente.Id,
             Nome: cliente.Nome,
             Telefone: cliente.Contato.Telefone,
             Email: cliente.Contato.Email,
             Logradouro: cliente.Endereco.Logradouro,
             Numero: cliente.Endereco.Numero,
             Cidade: cliente.Endereco.Cidade,
             CEP: cliente.Endereco.CEP,
             Complemento: cliente.Endereco.Complemento,
             Estado: cliente.Endereco.Estado,
             InformacoesAdicionais: cliente.Endereco.InformacoesAdicionais
        )
        { }
    }

    public record CadastrarClienteDto
    (
      string Nome,
      string Senha,
      string Telefone,
      string Email,
      string Logradouro,
      string Numero,
      string Cidade,
      string CEP,
      string Complemento,
      string Estado,
      string InformacoesAdicionais
    ): IClienteDto
    {
        public CadastrarClienteDto(Cliente cliente) : this(
            cliente.Nome,
            cliente.Senha,
            cliente.Contato.Telefone,
            cliente.Contato.Email,
            cliente.Endereco.Logradouro,
            cliente.Endereco.Numero,
            cliente.Endereco.Cidade,
            cliente.Endereco.CEP,
            cliente.Endereco.Complemento,
            cliente.Endereco.Estado,
            cliente.Endereco.InformacoesAdicionais
        )
        { }
    }

    public record AtualizarClienteDto
    (
      int Id,
      string Nome,
      string Telefone,
      string Email,
      string Logradouro,
      string Numero,
      string Cidade,
      string CEP,
      string Complemento,
      string Estado,
      string InformacoesAdicionais
    ) : IClienteDto
    {
        public AtualizarClienteDto(Cliente cliente) : this(
            cliente.Id,
            cliente.Nome,
            cliente.Contato.Telefone,
            cliente.Contato.Email,
            cliente.Endereco.Logradouro,
            cliente.Endereco.Numero,
            cliente.Endereco.Cidade,
            cliente.Endereco.CEP,
            cliente.Endereco.Complemento,
            cliente.Endereco.Estado,
            cliente.Endereco.InformacoesAdicionais
        )
        { }
    }
}