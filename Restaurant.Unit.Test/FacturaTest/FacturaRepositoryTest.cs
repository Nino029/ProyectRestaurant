using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Infraestructure.Repositories.Mock.Facturas;

namespace Restaurant.Unit.Test.FacturaTest
{
    public class FacturaRepositoryTest
    {
        private readonly IFacturaRepository _repository;

        public FacturaRepositoryTest()
        {
            _repository = new FacturaRepositoryMock();
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllFacturas()
        {
            // Arrange

            // Act
            var facturas = await _repository.GetAllAsync();

            // Assert
            Assert.NotNull(facturas);
            Assert.Equal(2, facturas.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ExistingId_ShouldReturnCorrectFactura()
        {
            // Arrange
            int existingId = 1;

            // Act
            var factura = await _repository.GetByIdAsync(existingId);

            // Assert
            Assert.NotNull(factura);
            Assert.Equal(existingId, factura.IdFactura);
        }

        [Fact]
        public async Task GetByIdAsync_NonExistingId_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            int nonExistingId = 100;

            // Act / Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _repository.GetByIdAsync(nonExistingId));
        }

        [Fact]
        public async Task AddAsync_ValidFactura_ShouldAddFactura()
        {
            // Arrange
            var newFactura = new Factura { IdFactura = 3, Total = 200.00m };

            // Act
            await _repository.AddAsync(newFactura);
            var facturas = await _repository.GetAllAsync();

            // Assert
            Assert.Contains(facturas, f => f.IdFactura == newFactura.IdFactura);
        }

        [Fact]
        public async Task AddAsync_FacturaWithDuplicateId_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var existingFactura = new Factura { IdFactura = 1, Total = 150.00m };

            // Act / Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _repository.AddAsync(existingFactura));
        }

        [Fact]
        public async Task UpdateAsync_ExistingFactura_ShouldUpdateFactura()
        {
            // Arrange
            var existingFactura = await _repository.GetByIdAsync(1);
            existingFactura.Total = 120.00m;

            // Act
            await _repository.UpdateAsync(existingFactura);
            var updatedFactura = await _repository.GetByIdAsync(1);

            // Assert
            Assert.Equal(existingFactura.Total, updatedFactura.Total);
        }

        [Fact]
        public async Task UpdateAsync_NonExistingFactura_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var nonExistingFactura = new Factura { IdFactura = 100, Total = 150.00m };

            // Act / Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _repository.UpdateAsync(nonExistingFactura));
        }

        [Fact]
        public async Task DeleteAsync_ExistingFactura_ShouldDeleteFactura()
        {
            // Arrange
            int existingId = 2;

            // Act
            await _repository.DeleteAsync(existingId);

            // Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _repository.GetByIdAsync(existingId));
        }

        [Fact]
        public async Task DeleteAsync_NonExistingFactura_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            int nonExistingId = 100;

            // Act / Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _repository.DeleteAsync(nonExistingId));
        }
    }
}
