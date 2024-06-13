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
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var mesa = await _context.Set<Mesa>().FindAsync(id);

            if (mesa == null)
            {
                throw new KeyNotFoundException("Mesa no encontrada");
            }

            return mesa;
        }

        public async Task AddAsync(Mesa mesa)
        {
            if (mesa == null)
            {
                throw new ArgumentNullException(nameof(mesa), "La mesa no puede ser nula");
            }

            await _context.Set<Mesa>().AddAsync(mesa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Mesa mesa)
        {
            if (mesa == null)
            {
                throw new ArgumentNullException(nameof(mesa), "La mesa no puede ser nula");
            }

            if (mesa.IdMesa <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(mesa.IdMesa));
            }

            var existingMesa = await _context.Set<Mesa>().FindAsync(mesa.IdMesa);
            if (existingMesa == null)
            {
                throw new KeyNotFoundException("Mesa no encontrada");
            }

            _context.Entry(existingMesa).CurrentValues.SetValues(mesa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var mesa = await _context.Set<Mesa>().FindAsync(id);
            if (mesa == null)
            {
                throw new KeyNotFoundException("Mesa no encontrada");
            }

            _context.Set<Mesa>().Remove(mesa);
            await _context.SaveChangesAsync();
        }
    }
}