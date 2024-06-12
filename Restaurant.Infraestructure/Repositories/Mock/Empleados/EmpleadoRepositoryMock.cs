
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;

namespace Restaurant.Infraestructure.Repositories.Mock.Empleados
{
    public class EmpleadoRepositoryMock : IEmpleadoRepository
    {
        private readonly List<Empleado> _empleados;

        public EmpleadoRepositoryMock()
        {
            _empleados = new List<Empleado>
            {
                
            };
        }

        public async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            return await Task.Run(() => _empleados.ToList());
        }

        public async Task<Empleado> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var empleado = _empleados.FirstOrDefault(e => e.IdEmpleado == id);

            if (empleado == null)
            {
                throw new KeyNotFoundException("Empleado no encontrado");
            }

            return empleado;
        }

        public async Task AddAsync(Empleado empleado)
        {
            if (empleado == null)
            {
                throw new ArgumentNullException(nameof(empleado), "El empleado no puede ser nulo");
            }

            if (_empleados.Any(e => e.IdEmpleado == empleado.IdEmpleado))
            {
                throw new InvalidOperationException("Ya existe un empleado con el mismo Id.");
            }

            _empleados.Add(empleado);
        }

        public async Task UpdateAsync(Empleado empleado)
        {
            if (empleado == null)
            {
                throw new ArgumentNullException(nameof(empleado), "El empleado no puede ser nulo");
            }

            if (empleado.IdEmpleado <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(empleado.IdEmpleado));
            }

            var existingEmpleado = _empleados.FirstOrDefault(e => e.IdEmpleado == empleado.IdEmpleado);
            if (existingEmpleado == null)
            {
                throw new KeyNotFoundException("Empleado no encontrado");
            }

            existingEmpleado.Nombre = empleado.Nombre;
            existingEmpleado.Cargo = empleado.Cargo;
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var empleado = _empleados.FirstOrDefault(e => e.IdEmpleado == id);
            if (empleado == null)
            {
                throw new KeyNotFoundException("Empleado no encontrado");
            }

            _empleados.Remove(empleado);
        }
    }
}
