using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Infraestructure.Context;

namespace Restaurant.Infraestructure.Repositories
{
    public class DetallePedidoRepository : IDetallePedidoRepository
    {
        private readonly ApplicationDbContext _context;

        public DetallePedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetallePedido>> GetAllAsync()
        {
            return await _context.Set<DetallePedido>()
                                 .Include(dp => dp.IdPedidoNavigation)
                                 .Include(dp => dp.IdPlatoNavigation)
                                 .ToListAsync();
        }

        public async Task<DetallePedido> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var detallePedido = await _context.Set<DetallePedido>()
                                              .Include(dp => dp.IdPedidoNavigation)
                                              .Include(dp => dp.IdPlatoNavigation)
                                              .FirstOrDefaultAsync(dp => dp.IdDetallePedido == id);

            if (detallePedido == null)
            {
                throw new KeyNotFoundException("Detalle de Pedido no encontrado");
            }

            return detallePedido;
        }

        public async Task AddAsync(DetallePedido detallePedido)
        {
            if (detallePedido == null)
            {
                throw new ArgumentNullException(nameof(detallePedido), "El detalle de pedido no puede ser nulo");
            }

            await _context.Set<DetallePedido>().AddAsync(detallePedido);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DetallePedido detallePedido)
        {
            if (detallePedido == null)
            {
                throw new ArgumentNullException(nameof(detallePedido), "El detalle de pedido no puede ser nulo");
            }

            if (detallePedido.IdDetallePedido <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(detallePedido.IdDetallePedido));
            }

            var existingDetallePedido = await _context.Set<DetallePedido>().FindAsync(detallePedido.IdDetallePedido);
            if (existingDetallePedido == null)
            {
                throw new KeyNotFoundException("Detalle de Pedido no encontrado");
            }

            _context.Entry(existingDetallePedido).CurrentValues.SetValues(detallePedido);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var detallePedido = await _context.Set<DetallePedido>().FindAsync(id);
            if (detallePedido == null)
            {
                throw new KeyNotFoundException("Detalle de Pedido no encontrado");
            }

            _context.Set<DetallePedido>().Remove(detallePedido);
            await _context.SaveChangesAsync();
        }
    }
}
