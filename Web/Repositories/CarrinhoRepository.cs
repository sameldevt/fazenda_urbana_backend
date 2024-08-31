using _.Data;
using _.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _.Web.Repositories
{
    public interface ICarrinhoRepository
    {
        Task<IEnumerable<ItemCarrinho>> ListarItensAsync();
        Task AdicionarItemAsync(ItemCarrinho item);
        Task AtualizarItemAsync(int id, ItemCarrinho item);
        Task RemoverItemAsync(int id);
    }

    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly ApplicationDbContext _context;

        public CarrinhoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemCarrinho>> ListarItensAsync() =>
            await _context.ItensCarrinho.ToListAsync();

        public async Task AdicionarItemAsync(ItemCarrinho item)
        {
            _context.ItensCarrinho.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarItemAsync(int id, ItemCarrinho item)
        {
            var itemExistente = await _context.ItensCarrinho.FindAsync(id);
            if (itemExistente != null)
            {
                itemExistente.Quantidade = item.Quantidade;
                itemExistente.PrecoUnitario = item.PrecoUnitario;
                itemExistente.Quantidade = item.Quantidade;

                _context.ItensCarrinho.Update(itemExistente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoverItemAsync(int id)
        {
            var item = await _context.ItensCarrinho.FindAsync(id);
            if (item != null)
            {
                _context.ItensCarrinho.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }

}
