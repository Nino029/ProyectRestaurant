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
                .ToListAsync();
        }

        public async Task<DetallePedido> GetByIdAsync(int id)
        {
            return await _context.Set<DetallePedido>()
                .FirstOrDefaultAsync(dp => dp.IdDetallePedido == id);
        }

        public async Task AddAsync(DetallePedido detallePedido)
        {
            await _context.Set<DetallePedido>().AddAsync(detallePedido);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DetallePedido detallePedido)
        {
            _context.Set<DetallePedido>().Update(detallePedido);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var detallePedido = await _context.Set<DetallePedido>().FindAsync(id);
            if (detallePedido != null)
            {
                _context.Set<DetallePedido>().Remove(detallePedido);
                await _context.SaveChangesAsync();
            }
        }
    }
}
