using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Infraestructure.Context;


namespace Restaurant.Infraestructure.Repositories
{
    public class MesaRepository : IMesaRepository
    {
        private readonly ApplicationDbContext _context;

        public MesaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mesa>> GetAllAsync()
        {
            return await _context.Set<Mesa>().ToListAsync();
        }

        public async Task<Mesa> GetByIdAsync(int id)
        {
            return await _context.Set<Mesa>().FindAsync(id);
        }

        public async Task AddAsync(Mesa mesa)
        {
            await _context.Set<Mesa>().AddAsync(mesa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Mesa mesa)
        {
            _context.Set<Mesa>().Update(mesa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var mesa = await _context.Set<Mesa>().FindAsync(id);
            if (mesa != null)
            {
                _context.Set<Mesa>().Remove(mesa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
