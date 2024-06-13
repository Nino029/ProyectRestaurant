
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;

namespace Restaurant.Infraestructure.Repositories.Mock.Facturas
{
    public class FacturaRepositoryMock : IFacturaRepository
    {
        private readonly List<Factura> _facturas;

        public FacturaRepositoryMock()
        {
            _facturas = new List<Factura>
    {
        new Factura { IdFactura = 1, Total = 100.00m },
        new Factura { IdFactura = 2, Total = 150.50m }
    };
        }

        public async Task<IEnumerable<Factura>> GetAllAsync()
        {
            return await Task.Run(() => _facturas.ToList());
        }

        public async Task<Factura> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var factura = _facturas.FirstOrDefault(f => f.IdFactura == id);

            if (factura == null)
            {
                throw new KeyNotFoundException("Factura no encontrada");
            }

            return factura;
        }

        public async Task AddAsync(Factura factura)
        {
            if (factura == null)
            {
                throw new ArgumentNullException(nameof(factura), "La factura no puede ser nula");
            }

            if (_facturas.Any(f => f.IdFactura == factura.IdFactura))
            {
                throw new InvalidOperationException("Ya existe una factura con el mismo Id.");
            }

            _facturas.Add(factura);
        }

        public async Task UpdateAsync(Factura factura)
        {
            if (factura == null)
            {
                throw new ArgumentNullException(nameof(factura), "La factura no puede ser nula");
            }

            if (factura.IdFactura <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(factura.IdFactura));
            }

            var existingFactura = _facturas.FirstOrDefault(f => f.IdFactura == factura.IdFactura);
            if (existingFactura == null)
            {
                throw new KeyNotFoundException("Factura no encontrada");
            }

            existingFactura.IdFactura = factura.IdFactura; 
            existingFactura.Total = factura.Total; 
        }


        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var factura = _facturas.FirstOrDefault(f => f.IdFactura == id);
            if (factura == null)
            {
                throw new KeyNotFoundException("Factura no encontrada");
            }

            _facturas.Remove(factura);
        }
    }
}
