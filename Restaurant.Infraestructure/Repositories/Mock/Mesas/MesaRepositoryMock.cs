
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;

namespace Restaurant.Infraestructure.Repositories.Mock.Mesas
{
    public class MesaRepositoryMock : IMesaRepository
    {
        private readonly List<Mesa> _mesas;

        public MesaRepositoryMock()
        {
            _mesas = new List<Mesa>
            {
                 new Mesa { IdMesa = 1, Capacidad = 4, Estado = "Disponible" },
                new Mesa { IdMesa = 2, Capacidad = 6, Estado = "Ocupado" }
            };
        }

        public async Task<IEnumerable<Mesa>> GetAllAsync()
        {
            return await Task.Run(() => _mesas.ToList());
        }

        public async Task<Mesa> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var mesa = _mesas.FirstOrDefault(m => m.IdMesa == id);

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

            if (_mesas.Any(m => m.IdMesa == mesa.IdMesa))
            {
                throw new InvalidOperationException("Ya existe una mesa con el mismo Id.");
            }

            _mesas.Add(mesa);
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

            var existingMesa = _mesas.FirstOrDefault(m => m.IdMesa == mesa.IdMesa);
            if (existingMesa == null)
            {
                throw new KeyNotFoundException("Mesa no encontrada");
            }

            existingMesa.Capacidad = mesa.Capacidad;
            existingMesa.Estado = mesa.Estado;
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var mesa = _mesas.FirstOrDefault(m => m.IdMesa == id);
            if (mesa == null)
            {
                throw new KeyNotFoundException("Mesa no encontrada");
            }

            _mesas.Remove(mesa);
        }
    }
}