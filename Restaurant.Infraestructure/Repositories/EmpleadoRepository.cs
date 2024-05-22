using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Infraestructure.Context;

namespace Restaurant.Infraestructure.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            return await _context.Set<Empleado>().ToListAsync();
        }

        public async Task<Empleado> GetByIdAsync(int id)
        {
            return await _context.Set<Empleado>().FindAsync(id);
        }

        public async Task AddAsync(Empleado empleado)
        {
            await _context.Set<Empleado>().AddAsync(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Empleado empleado)
        {
            _context.Set<Empleado>().Update(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var empleado = await _context.Set<Empleado>().FindAsync(id);
            if (empleado != null)
            {
                _context.Set<Empleado>().Remove(empleado);
                await _context.SaveChangesAsync();
            }
        }
    }
}
