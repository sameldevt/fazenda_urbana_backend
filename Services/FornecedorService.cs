using Microsoft.EntityFrameworkCore.Diagnostics;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IFornecedorService
    {
        Task<List<IFornecedorDto>> BuscarTodosAsync();
        Task<IFornecedorDto> BuscarPorIdAsync(int id);
        Task<IFornecedorDto> CadastrarAsync(CadastrarFornecedorDto cadastrarFornecedorDto);
        Task<IFornecedorDto> AtualizarAsync(AtualizarFornecedorDto atualzarFornecedorDto);
        Task<IFornecedorDto> RemoverAsync(int id);
    }

    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<List<IFornecedorDto>> BuscarTodosAsync()
        {
            var fornecedores = await _fornecedorRepository.BuscarTodosAsync();

            return fornecedores.Select(f => FornecedorDtoFactory.Criar(TipoDto.Visualizar, f)).ToList();
        }

        public async Task<IFornecedorDto> BuscarPorIdAsync(int id)
        {
            var fornecedor = await _fornecedorRepository.BuscarPorIdAsync(id);

            return FornecedorDtoFactory.Criar(TipoDto.Visualizar, fornecedor);
        }

        public async Task<IFornecedorDto> CadastrarAsync(CadastrarFornecedorDto cadastrarFornecedorDto)
        {
            var fornecedor = new Fornecedor(cadastrarFornecedorDto);

            var fornecedorCadastrado = await _fornecedorRepository.CadastrarAsync(fornecedor);
            
            return FornecedorDtoFactory.Criar(TipoDto.Visualizar, fornecedor);
        }

        public async Task<IFornecedorDto> AtualizarAsync(AtualizarFornecedorDto atualizarFornecedorDto)
        {
            var id = atualizarFornecedorDto.Id;

            var fornecedor = await _fornecedorRepository.BuscarPorIdAsync(id);

            fornecedor = new Fornecedor(atualizarFornecedorDto);

            await _fornecedorRepository.AtualizarAsync(fornecedor);

            return FornecedorDtoFactory.Criar(TipoDto.Visualizar, fornecedor);
        }

        public async Task<IFornecedorDto> RemoverAsync(int id)
        {
            var fornecedor = await _fornecedorRepository.RemoverAsync(id);

            return FornecedorDtoFactory.Criar(TipoDto.Visualizar, fornecedor);
        }
    }
}
