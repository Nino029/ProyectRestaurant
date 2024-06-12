using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Infraestructure.Repositories.Mock.Pedidos;
using Xunit;

namespace Restaurant.Unit.Test.PedidoTest
{
    public class PedidoRepositoryTest
    {
        private readonly IPedidoRepository _repository;

        public PedidoRepositoryTest()
        {
            _repository = new PedidoRepositoryMock();
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllPedidos()
        {
            // Act
            var pedidos = await _repository.GetAllAsync();

            // Assert
            Assert.NotNull(pedidos);
            Assert.Equal(2, pedidos.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ExistingId_ShouldReturnPedido()
        {
            // Arrange
            int existingId = 1;

            // Act
            var pedido = await _repository.GetByIdAsync(existingId);

            // Assert
            Assert.NotNull(pedido);
            Assert.Equal(existingId, pedido.IdPedido);
        }

        [Fact]
        public async Task GetByIdAsync_NonExistingId_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            int nonExistingId = 99;

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () => await _repository.GetByIdAsync(nonExistingId));
        }

        [Fact]
        public async Task AddAsync_ValidPedido_ShouldAddPedido()
        {
            // Arrange
            var newPedido = new Pedido { IdPedido = 3, IdCliente = 3, IdMesa = 3, Fecha = DateOnly.FromDateTime(DateTime.Now), Total = 200.00m };

            // Act
            await _repository.AddAsync(newPedido);
            var addedPedido = await _repository.GetByIdAsync(newPedido.IdPedido);

            // Assert
            Assert.NotNull(addedPedido);
            Assert.Equal(newPedido.IdPedido, addedPedido.IdPedido);
        }

        [Fact]
        public async Task AddAsync_DuplicateId_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var duplicatePedido = new Pedido { IdPedido = 1, IdCliente = 3, IdMesa = 3, Fecha = DateOnly.FromDateTime(DateTime.Now), Total = 200.00m };

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await _repository.AddAsync(duplicatePedido));
        }

        [Fact]
        public async Task UpdateAsync_ExistingPedido_ShouldUpdatePedido()
        {
            // Arrange
            var updatedPedido = new Pedido { IdPedido = 1, IdCliente = 1, IdMesa = 1, Fecha = DateOnly.FromDateTime(DateTime.Now), Total = 500.00m };

            // Act
            await _repository.UpdateAsync(updatedPedido);
            var result = await _repository.GetByIdAsync(updatedPedido.IdPedido);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedPedido.Total, result.Total);
        }

        [Fact]
        public async Task UpdateAsync_NonExistingPedido_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var nonExistingPedido = new Pedido { IdPedido = 99, IdCliente = 3, IdMesa = 3, Fecha = DateOnly.FromDateTime(DateTime.Now), Total = 200.00m };

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () => await _repository.UpdateAsync(nonExistingPedido));
        }

        [Fact]
        public async Task DeleteAsync_ExistingPedido_ShouldDeletePedido()
        {
            // Arrange
            int existingId = 2;

            // Act
            await _repository.DeleteAsync(existingId);

            // Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () => await _repository.GetByIdAsync(existingId));
        }

        [Fact]
        public async Task DeleteAsync_NonExistingPedido_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            int nonExistingId = 99;

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () => await _repository.DeleteAsync(nonExistingId));
        }
    }
}
