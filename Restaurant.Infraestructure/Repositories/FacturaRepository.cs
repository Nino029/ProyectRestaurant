using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Infraestructure.Context;


namespace Restaurant.Infraestructure.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly ApplicationDbContext _context;

        public FacturaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Factura>> GetAllAsync()
        {
            return await _context.Set<Factura>()   
                .ToListAsync();
        }

        public async Task<Factura> GetByIdAsync(int id)
        {
            return await _context.Set<Factura>()
                .FirstOrDefaultAsync(f => f.IdFactura == id);
        }

        public async Task AddAsync(Factura factura)
        {
            await _context.Set<Factura>().AddAsync(factura);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Factura factura)
        {
            _context.Set<Factura>().Update(factura);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var factura = await _context.Set<Factura>().FindAsync(id);
            if (factura != null)
            {
                _context.Set<Factura>().Remove(factura);
                await _context.SaveChangesAsync();
            }
        }
    }
}
