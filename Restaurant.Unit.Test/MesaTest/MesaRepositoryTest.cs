using Xunit;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Infraestructure.Repositories.Mock.Mesas;

namespace Restaurant.Unit.Test.MesaTest
{
    public class MesaRepositoryTest
    {
        private readonly IMesaRepository _repository;

        public MesaRepositoryTest()
        {
            _repository = new MesaRepositoryMock();
        }

        [Fact]
        public async Task AddAsync_ShouldAddNewMesa()
        {
            // Arrange
            var newMesa = new Mesa { IdMesa = 3, Capacidad = 8, Estado = "Disponible" };

            // Act
            await _repository.AddAsync(newMesa);
            var addedMesa = await _repository.GetByIdAsync(3);

            // Assert
            Assert.NotNull(addedMesa);
            Assert.Equal(newMesa.Capacidad, addedMesa.Capacidad);
            Assert.Equal(newMesa.Estado, addedMesa.Estado);
        }

        [Fact]
        public async Task GetByIdAsync_ExistingMesa_ShouldReturnMesa()
        {
            // Act
            var mesa = await _repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(mesa);
            Assert.Equal(1, mesa.IdMesa);
        }

        [Fact]
        public async Task GetByIdAsync_NonExistingMesa_ShouldThrowKeyNotFoundException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _repository.GetByIdAsync(99));
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateExistingMesa()
        {
            // Arrange
            var updatedMesa = new Mesa { IdMesa = 1, Capacidad = 10, Estado = "Reservada" };

            // Act
            await _repository.UpdateAsync(updatedMesa);
            var mesa = await _repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(mesa);
            Assert.Equal(updatedMesa.Capacidad, mesa.Capacidad);
            Assert.Equal(updatedMesa.Estado, mesa.Estado);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteExistingMesa()
        {
            // Arrange
            var existingId = 2;

            // Act
            await _repository.DeleteAsync(existingId);

            // Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _repository.GetByIdAsync(existingId));
        }
    }
}