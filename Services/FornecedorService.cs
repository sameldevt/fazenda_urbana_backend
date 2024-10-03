using AutoMapper;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Model.Dtos;
using Model.Entities;
using Repositories;

namespace Services
{
    public interface IFornecedorService
    {
        Task<List<VisualizarFornecedorDto>> BuscarTodosAsync();
        Task<VisualizarFornecedorDto> BuscarPorIdAsync(int id);
        Task<VisualizarFornecedorDto> CadastrarAsync(CadastrarFornecedorDto cadastrarFornecedorDto);
        Task<VisualizarFornecedorDto> AtualizarAsync(AtualizarFornecedorDto atualzarFornecedorDto);
        Task<VisualizarFornecedorDto> RemoverAsync(int id);
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

        public async Task<List<VisualizarFornecedorDto>> BuscarTodosAsync()
        {
            var fornecedores = await _fornecedorRepository.BuscarTodosAsync();

            return _mapper.Map<List<VisualizarFornecedorDto>>(fornecedores);
        }

        public async Task<VisualizarFornecedorDto> BuscarPorIdAsync(int id)
        {
            var fornecedor = await _fornecedorRepository.BuscarPorIdAsync(id);

            return _mapper.Map<VisualizarFornecedorDto>(fornecedor);
        }

        public async Task<VisualizarFornecedorDto> CadastrarAsync(CadastrarFornecedorDto cadastrarFornecedorDto)
        {
            var fornecedor = _mapper.Map<Fornecedor>(cadastrarFornecedorDto);

            var fornecedorCadastrado = await _fornecedorRepository.CadastrarAsync(fornecedor);

            return _mapper.Map<VisualizarFornecedorDto>(fornecedorCadastrado);
        }

        public async Task<VisualizarFornecedorDto> AtualizarAsync(AtualizarFornecedorDto atualizarFornecedorDto)
        {
            var fornecedor = await _fornecedorRepository.BuscarPorIdAsync(atualizarFornecedorDto.Id);

            fornecedor = _mapper.Map<Fornecedor>(atualizarFornecedorDto);

            var fornecedorAtualizado = await _fornecedorRepository.AtualizarAsync(fornecedor);

            return _mapper.Map<VisualizarFornecedorDto>(fornecedorAtualizado);
        }

        public async Task<VisualizarFornecedorDto> RemoverAsync(int id)
        {
            var fornecedor = await _fornecedorRepository.RemoverAsync(id);

            return _mapper.Map<VisualizarFornecedorDto>(fornecedor);
        }
    }
}
