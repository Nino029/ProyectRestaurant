
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;

namespace Restaurant.Infraestructure.Repositories.Mock.DetallePedidos
{
    public class DetallePedidoRepositoryMock : IDetallePedidoRepository
    {
        private readonly List<DetallePedido> _detallePedidos;

        public DetallePedidoRepositoryMock()
        {
            _detallePedidos = new List<DetallePedido>();
        }

        public async Task<IEnumerable<DetallePedido>> GetAllAsync()
        {
            return await Task.Run(() => _detallePedidos.ToList());
        }

        public async Task<DetallePedido> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var detallePedido = _detallePedidos.FirstOrDefault(dp => dp.IdDetallePedido == id);

            if (detallePedido == null)
            {
                throw new KeyNotFoundException("Detalle de Pedido no encontrado");
            }

            return detallePedido;
        }

        public async Task AddAsync(DetallePedido detallePedido)
        {
            if (detallePedido == null)
            {
                throw new ArgumentNullException(nameof(detallePedido), "El detalle de pedido no puede ser nulo");
            }

            _detallePedidos.Add(detallePedido);
        }

        public async Task UpdateAsync(DetallePedido detallePedido)
        {
            if (detallePedido == null)
            {
                throw new ArgumentNullException(nameof(detallePedido), "El detalle de pedido no puede ser nulo");
            }

            if (detallePedido.IdDetallePedido <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(detallePedido.IdDetallePedido));
            }

            var existingDetallePedido = _detallePedidos.FirstOrDefault(dp => dp.IdDetallePedido == detallePedido.IdDetallePedido);
            if (existingDetallePedido == null)
            {
                throw new KeyNotFoundException("Detalle de Pedido no encontrado");
            }

            existingDetallePedido.IdPedido = detallePedido.IdPedido;
            existingDetallePedido.IdPlato = detallePedido.IdPlato;
            existingDetallePedido.Cantidad = detallePedido.Cantidad;
            existingDetallePedido.Subtotal = detallePedido.Subtotal;
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var detallePedido = _detallePedidos.FirstOrDefault(dp => dp.IdDetallePedido == id);
            if (detallePedido == null)
            {
                throw new KeyNotFoundException("Detalle de Pedido no encontrado");
            }

            _detallePedidos.Remove(detallePedido);
        }

    }
}
