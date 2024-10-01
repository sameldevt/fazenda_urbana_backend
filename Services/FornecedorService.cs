using Microsoft.EntityFrameworkCore.Diagnostics;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IFornecedorService
    {
        Task<IEnumerable<VisualizarFornecedorDto>> BuscarTodosAsync();
        Task<VisualizarFornecedorDto> BuscarPorIdAsync(int id);
        Task<VisualizarFornecedorDto> CadastrarAsync(CadastrarFornecedorDto cadastrarFornecedorDto);
        Task<VisualizarFornecedorDto> AtualizarAsync(AtualizarFornecedorDto atualzarFornecedorDto);
        Task<VisualizarFornecedorDto> RemoverAsync(int id);
    }

    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<IEnumerable<VisualizarFornecedorDto>> BuscarTodosAsync()
        {
            var fornecedores = await _fornecedorRepository.ListarTodosAsync();
            var fornecedoresDto = new List<VisualizarFornecedorDto>();

            foreach(Fornecedor f in fornecedores)
            {
                var fornecedorDto = VisualizarFornecedorDto.ConverterObjeto(f);
                fornecedoresDto.Add(fornecedorDto);
            }

            return fornecedoresDto;
        }

        public async Task<VisualizarFornecedorDto> BuscarPorIdAsync(int id)
        {
            var fornecedor = await _fornecedorRepository.BuscarPorIdAsync(id);
        
            if(fornecedor != null)
            {
                return VisualizarFornecedorDto.ConverterObjeto(fornecedor);
            }

            return null;
        }

        public async Task<VisualizarFornecedorDto> CadastrarAsync(CadastrarFornecedorDto cadastrarFornecedorDto)
        {
            var fornecedor = ConverterDto(cadastrarFornecedorDto);

            if(await _fornecedorRepository.CadastrarAsync(fornecedor))
            {
                return VisualizarFornecedorDto.ConverterObjeto(fornecedor);
            }
            
            return null;
        }

        public async Task<VisualizarFornecedorDto> AtualizarAsync(AtualizarFornecedorDto atualizarFornecedorDto)
        {
            var id = atualizarFornecedorDto.Id;

            var fornecedor = await _fornecedorRepository.BuscarPorIdAsync(id);

            if (fornecedor != null)
            {
                fornecedor.Nome = atualizarFornecedorDto.Nome;
                fornecedor.CNPJ = atualizarFornecedorDto.CNPJ;
                fornecedor.Endereco = atualizarFornecedorDto.Endereco;
                fornecedor.Telefone = atualizarFornecedorDto.Telefone;
                fornecedor.Email = atualizarFornecedorDto.Email;
                fornecedor.Website = atualizarFornecedorDto.Website;
                fornecedor.ContatoPrincipal = atualizarFornecedorDto.ContatoPrincipal;
                fornecedor.Observacoes = atualizarFornecedorDto.Observacoes;
                fornecedor.DataCadastro = atualizarFornecedorDto.DataCadastro;

                await _fornecedorRepository.AtualizarAsync(fornecedor);
            }

            return VisualizarFornecedorDto.ConverterObjeto(fornecedor);
        }

        public async Task<VisualizarFornecedorDto> RemoverAsync(int id)
        {
            var fornecedor = await _fornecedorRepository.BuscarPorIdAsync(id);

            if (await _fornecedorRepository.RemoverAsync(fornecedor))
            {
                return VisualizarFornecedorDto.ConverterObjeto(fornecedor);
            }

            return null;
        }

        private Fornecedor ConverterDto(CadastrarFornecedorDto fornecedorDto)
        {
            return new Fornecedor(
                fornecedorDto.Nome,
                fornecedorDto.CNPJ,
                fornecedorDto.Endereco,
                fornecedorDto.Telefone,
                fornecedorDto.Email,
                fornecedorDto.Website,
                fornecedorDto.ContatoPrincipal,
                fornecedorDto.Observacoes,
                fornecedorDto.DataCadastro
            );
        }
    }
}
