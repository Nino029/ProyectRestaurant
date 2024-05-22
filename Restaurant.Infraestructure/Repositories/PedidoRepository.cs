using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Infraestructure.Context;


namespace Restaurant.Infraestructure.Repositories
{

  public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _context;

        public PedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            return await _context.Set<Pedido>()
                .ToListAsync();
        }

        public async Task<Pedido> GetByIdAsync(int id)
        {
            return await _context.Set<Pedido>()
           .FirstOrDefaultAsync(p => p.IdPedido == id);
        }

        public async Task AddAsync(Pedido pedido)
        {
            await _context.Set<Pedido>().AddAsync(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pedido pedido)
        {
            _context.Set<Pedido>().Update(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pedido = await _context.Set<Pedido>().FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }
    }
}
