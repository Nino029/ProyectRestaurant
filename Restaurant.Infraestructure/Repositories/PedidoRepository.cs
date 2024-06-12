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
            return await _context.Set<Pedido>().ToListAsync();
        }

        public async Task<Pedido> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var pedido = await _context.Set<Pedido>().FirstOrDefaultAsync(p => p.IdPedido == id);

            if (pedido == null)
            {
                throw new KeyNotFoundException("Pedido no encontrado");
            }

            return pedido;
        }

        public async Task AddAsync(Pedido pedido)
        {
            if (pedido == null)
            {
                throw new ArgumentNullException(nameof(pedido), "El pedido no puede ser nulo");
            }

            await _context.Set<Pedido>().AddAsync(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pedido pedido)
        {
            if (pedido == null)
            {
                throw new ArgumentNullException(nameof(pedido), "El pedido no puede ser nulo");
            }

            if (pedido.IdPedido <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(pedido.IdPedido));
            }

            var existingPedido = await _context.Set<Pedido>().FindAsync(pedido.IdPedido);
            if (existingPedido == null)
            {
                throw new KeyNotFoundException("Pedido no encontrado");
            }

            _context.Entry(existingPedido).CurrentValues.SetValues(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var pedido = await _context.Set<Pedido>().FindAsync(id);
            if (pedido == null)
            {
                throw new KeyNotFoundException("Pedido no encontrado");
            }

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
        }
    }
}
