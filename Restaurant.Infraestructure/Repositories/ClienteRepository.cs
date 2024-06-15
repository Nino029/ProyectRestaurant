using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Infraestructure.Context;
using System.Runtime.Serialization;


namespace Restaurant.Infraestructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Set<Cliente>().ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var cliente = await _context.Set<Cliente>().FindAsync(id);

            if (cliente == null)
            {
                throw new KeyNotFoundException("Cliente no encontrado");
            }

            return cliente;
        }

        public async Task AddAsync(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser nulo");
            }

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                throw new ArgumentException("El nombre del cliente es obligatorio", nameof(cliente.Nombre));
            }

            await _context.Set<Cliente>().AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser nulo");
            }

            if (cliente.IdCliente <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(cliente.IdCliente));
            }

            var existingCliente = await _context.Set<Cliente>().FindAsync(cliente.IdCliente);
            if (existingCliente == null)
            {
                throw new KeyNotFoundException("Cliente no encontrado"); 
            }

            _context.Entry(existingCliente).CurrentValues.SetValues(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var cliente = await _context.Set<Cliente>().FindAsync(id);
            if (cliente == null)
            {
                throw new KeyNotFoundException("Cliente no encontrado"); 
            }

            _context.Set<Cliente>().Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
