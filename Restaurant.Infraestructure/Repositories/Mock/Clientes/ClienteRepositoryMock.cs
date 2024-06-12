
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;

namespace Restaurant.Infrastructure.Repositories.Mock
{
    public class ClienteRepositoryMock : IClienteRepository
    {
        private readonly List<Cliente> _context;

        public ClienteRepositoryMock()
        {
            _context = new List<Cliente>();
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return _context.ToList();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var cliente = _context.FirstOrDefault(c => c.IdCliente == id);

            if (cliente == null)
            {
                throw new KeyNotFoundException("Cliente no encontrado");
            }

            return  cliente;
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

            cliente.IdCliente = _context.Count > 0 ? _context.Max(c => c.IdCliente) + 1 : 1;
            _context.Add(cliente);
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

            var existingCliente = _context.FirstOrDefault(c => c.IdCliente == cliente.IdCliente);
            if (existingCliente == null)
            {
                throw new KeyNotFoundException("Cliente no encontrado");
            }

            existingCliente.Nombre = cliente.Nombre;
            existingCliente.Telefono = cliente.Telefono;
            existingCliente.Email = cliente.Email;
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var cliente = _context.FirstOrDefault(c => c.IdCliente == id);
            if (cliente == null)
            {
                throw new KeyNotFoundException("Cliente no encontrado");
            }

            _context.Remove(cliente);
        }
    }
}
