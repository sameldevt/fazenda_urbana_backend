using AutoMapper;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IFornecedorService
    {
        Task<List<FornecedorDto>> BuscarTodosAsync();
        Task<FornecedorDto> BuscarPorIdAsync(int id);
        Task<FornecedorDto> CadastrarAsync(CadastrarFornecedorDto cadastrarFornecedorDto);
        Task<FornecedorDto> AtualizarAsync(FornecedorDto atualzarFornecedorDto);
        Task<FornecedorDto> RemoverAsync(int id);
    }

    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task<List<FornecedorDto>> BuscarTodosAsync()
        {
            var fornecedores = await _fornecedorRepository.BuscarTodosAsync();

            return _mapper.Map<List<FornecedorDto>>(fornecedores);
        }

        public async Task<FornecedorDto> BuscarPorIdAsync(int id)
        {
            var fornecedor = await _fornecedorRepository.BuscarPorIdAsync(id);

            return _mapper.Map<FornecedorDto>(fornecedor);
        }

        public async Task<FornecedorDto> CadastrarAsync(CadastrarFornecedorDto cadastrarFornecedorDto)
        {
            var fornecedor = _mapper.Map<Fornecedor>(cadastrarFornecedorDto);

            var fornecedorCadastrado = await _fornecedorRepository.CadastrarAsync(fornecedor);

            return _mapper.Map<FornecedorDto>(fornecedorCadastrado);
        }

        public async Task<FornecedorDto> AtualizarAsync(FornecedorDto atualizarFornecedorDto)
        {
            var fornecedor = await _fornecedorRepository.BuscarPorIdAsync(atualizarFornecedorDto.Id);

            fornecedor = _mapper.Map<Fornecedor>(atualizarFornecedorDto);

            var fornecedorAtualizado = await _fornecedorRepository.AtualizarAsync(fornecedor);

            return _mapper.Map<FornecedorDto>(fornecedorAtualizado);
        }

        public async Task<FornecedorDto> RemoverAsync(int id)
        {
            var fornecedor = await _fornecedorRepository.RemoverAsync(id);

            return _mapper.Map<FornecedorDto>(fornecedor);
        }
    }
}
