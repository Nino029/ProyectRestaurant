using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;

namespace Restaurant.Infraestructure.Repositories.Mock.Pedidos
{
    public class PedidoRepositoryMock : IPedidoRepository
    {
        private readonly List<Pedido> _pedidos;

        public PedidoRepositoryMock()
        {
            _pedidos = new List<Pedido>
            {
                new Pedido { IdPedido = 1, IdCliente = 1, IdMesa = 1, Fecha = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), Total = 100.00m },
                new Pedido { IdPedido = 2, IdCliente = 2, IdMesa = 2, Fecha = DateOnly.FromDateTime(DateTime.Now), Total = 150.50m }
            };
        }

        public async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            return await Task.Run(() => _pedidos.ToList());
        }

        public async Task<Pedido> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var pedido = _pedidos.FirstOrDefault(p => p.IdPedido == id);

            if (pedido == null)
            {
                throw new KeyNotFoundException("Pedido no encontrado");
            }

            return await Task.FromResult(pedido);
        }

        public async Task AddAsync(Pedido pedido)
        {
            if (pedido == null)
            {
                throw new ArgumentNullException(nameof(pedido), "El pedido no puede ser nulo");
            }

            if (_pedidos.Any(p => p.IdPedido == pedido.IdPedido))
            {
                throw new InvalidOperationException("Ya existe un pedido con el mismo Id.");
            }

            _pedidos.Add(pedido);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Pedido pedido)
        {
            if (pedido == null)
            {
                throw new ArgumentNullException(nameof(pedido), "El pedido no puede ser nulo");
            }

            if (pedido.IdPedido <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(pedido.IdPedido));
            }

            var existingPedido = _pedidos.FirstOrDefault(p => p.IdPedido == pedido.IdPedido);
            if (existingPedido == null)
            {
                throw new KeyNotFoundException("Pedido no encontrado");
            }

            existingPedido.IdCliente = pedido.IdCliente;
            existingPedido.IdMesa = pedido.IdMesa;
            existingPedido.Fecha = pedido.Fecha;
            existingPedido.Total = pedido.Total;
            existingPedido.DetallePedidos = pedido.DetallePedidos;
            existingPedido.Facturas = pedido.Facturas;
            existingPedido.IdClienteNavigation = pedido.IdClienteNavigation;
            existingPedido.IdMesaNavigation = pedido.IdMesaNavigation;

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var pedido = _pedidos.FirstOrDefault(p => p.IdPedido == id);
            if (pedido == null)
            {
                throw new KeyNotFoundException("Pedido no encontrado");
            }

            _pedidos.Remove(pedido);
            await Task.CompletedTask;
        }
    }
}
