using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Infraestructure.Repositories.Mock.DetallePedidos;

namespace Restaurant.Unit.Test.DetallePedidoRepository
{
    public class DetallePedidoRepositoryTest
    {
        private readonly IDetallePedidoRepository _repository;

        public DetallePedidoRepositoryTest()
        {
            _repository = new DetallePedidoRepositoryMock();
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllDetallePedidos()
        {
            // Arrange
            var detallePedidos = new List<DetallePedido>
            {
                new DetallePedido { IdDetallePedido = 1, IdPedido = 1, IdPlato = 1, Cantidad = 2, Subtotal = 20 },
                new DetallePedido { IdDetallePedido = 2, IdPedido = 2, IdPlato = 2, Cantidad = 1, Subtotal = 15 },
                new DetallePedido { IdDetallePedido = 3, IdPedido = 1, IdPlato = 3, Cantidad = 3, Subtotal = 30 }
            };

            foreach (var detallePedido in detallePedidos)
            {
                await _repository.AddAsync(detallePedido);
            }

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.Equal(detallePedidos.Count, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectDetallePedido()
        {
            // Arrange
            var detallePedido = new DetallePedido { IdDetallePedido = 1, IdPedido = 1, IdPlato = 1, Cantidad = 2, Subtotal = 20 };
            await _repository.AddAsync(detallePedido);

            // Act
            var result = await _repository.GetByIdAsync(detallePedido.IdDetallePedido);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(detallePedido.IdDetallePedido, result.IdDetallePedido);
            Assert.Equal(detallePedido.IdPedido, result.IdPedido);
            Assert.Equal(detallePedido.IdPlato, result.IdPlato);
            Assert.Equal(detallePedido.Cantidad, result.Cantidad);
            Assert.Equal(detallePedido.Subtotal, result.Subtotal);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrowExceptionWhenIdNotFound()
        {
            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () => await _repository.GetByIdAsync(999));
        }

        [Fact]
        public async Task AddAsync_ShouldAddNewDetallePedido()
        {
            // Arrange
            var detallePedido = new DetallePedido { IdDetallePedido = 1, IdPedido = 1, IdPlato = 1, Cantidad = 2, Subtotal = 20 };

            // Act
            await _repository.AddAsync(detallePedido);
            var result = await _repository.GetByIdAsync(detallePedido.IdDetallePedido);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(detallePedido.IdDetallePedido, result.IdDetallePedido);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateExistingDetallePedido()
        {
            // Arrange
            var detallePedido = new DetallePedido { IdDetallePedido = 1, IdPedido = 1, IdPlato = 1, Cantidad = 2, Subtotal = 20 };
            await _repository.AddAsync(detallePedido);

            var updatedDetallePedido = new DetallePedido
            {
                IdDetallePedido = detallePedido.IdDetallePedido,
                IdPedido = 2,
                IdPlato = 2,
                Cantidad = 3,
                Subtotal = 30
            };

            // Act
            await _repository.UpdateAsync(updatedDetallePedido);
            var result = await _repository.GetByIdAsync(detallePedido.IdDetallePedido);

            // Assert
            Assert.Equal(updatedDetallePedido.IdPedido, result.IdPedido);
            Assert.Equal(updatedDetallePedido.IdPlato, result.IdPlato);
            Assert.Equal(updatedDetallePedido.Cantidad, result.Cantidad);
            Assert.Equal(updatedDetallePedido.Subtotal, result.Subtotal);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowExceptionWhenIdNotFound()
        {
            // Arrange
            var detallePedido = new DetallePedido { IdDetallePedido = 1, IdPedido = 1, IdPlato = 1, Cantidad = 2, Subtotal = 20 };

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () => await _repository.UpdateAsync(detallePedido));
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteDetallePedido()
        {
            // Arrange
            var detallePedido = new DetallePedido { IdDetallePedido = 1, IdPedido = 1, IdPlato = 1, Cantidad = 2, Subtotal = 20 };
            await _repository.AddAsync(detallePedido);

            // Act
            await _repository.DeleteAsync(detallePedido.IdDetallePedido);
            

            // Assert
            Assert.ThrowsAsync<KeyNotFoundException>(async () => await _repository.GetByIdAsync(detallePedido.IdDetallePedido));
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowExceptionWhenIdNotFound()
        {
            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () => await _repository.DeleteAsync(999));
        }
    }
}
