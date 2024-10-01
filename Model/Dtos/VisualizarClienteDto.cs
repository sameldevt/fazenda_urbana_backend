using Model.Entities;

namespace Model.Dtos
{
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
    )
    {
        public static VisualizarClienteDto ConverterCliente(Cliente cliente)
        {
            if(cliente  == null)
            {
                return Vazio();
            }

            return new VisualizarClienteDto
            (
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
            );
        }

        public static VisualizarClienteDto Vazio()
        {
            return new VisualizarClienteDto
           (
               0,
               "",
               "",
               "",
               "",
               "",
               "",
               "",
               "",
               "",
               ""
           );
        }
    }
}