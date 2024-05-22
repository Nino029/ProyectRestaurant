
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Infraestructure.Context;

namespace Restaurant.Infraestructure.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly ApplicationDbContext _context;

        public MenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Menu>> GetAllAsync()
        {
            return await _context.Set<Menu>().ToListAsync();
        }

        public async Task<Menu> GetByIdAsync(int id)
        {
            return await _context.Set<Menu>().FindAsync(id);
        }

        public async Task AddAsync(Menu menu)
        {
            await _context.Set<Menu>().AddAsync(menu);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Menu menu)
        {
            _context.Set<Menu>().Update(menu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var menu = await _context.Set<Menu>().FindAsync(id);
            if (menu != null)
            {
                _context.Set<Menu>().Remove(menu);
                await _context.SaveChangesAsync();
            }
        }
    }
}
