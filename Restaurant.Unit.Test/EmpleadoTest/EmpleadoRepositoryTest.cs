using Xunit;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Infraestructure.Repositories.Mock.Empleados;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Unit.Test.EmpleadoTest
{
    public class EmpleadoRepositoryTest
    {
        private readonly IEmpleadoRepository _repository;

        public EmpleadoRepositoryTest()
        {
            _repository = new EmpleadoRepositoryMock();
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllEmpleados()
        {
            // Act
            var empleados = await _repository.GetAllAsync();

            // Assert
            Assert.NotNull(empleados);
            Assert.Equal(2, empleados.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ExistingId_ShouldReturnEmpleado()
        {
            // Arrange
            int id = 1;

            // Act
            var empleado = await _repository.GetByIdAsync(id);

            // Assert
            Assert.NotNull(empleado);
            Assert.Equal(id, empleado.IdEmpleado);
        }

        [Fact]
        public async Task GetByIdAsync_NonExistingId_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            int id = 999; // Assuming this id does not exist in mock data

            // Act / Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () => await _repository.GetByIdAsync(id));
        }

        [Fact]
        public async Task AddAsync_ShouldAddNewEmpleado()
        {
            // Arrange
            var newEmpleado = new Empleado { IdEmpleado = 3, Nombre = "Nuevo Empleado", Cargo = "Cargo Nuevo" };

            // Act
            await _repository.AddAsync(newEmpleado);

            // Assert
            var addedEmpleado = await _repository.GetByIdAsync(newEmpleado.IdEmpleado);
            Assert.NotNull(addedEmpleado);
            Assert.Equal(newEmpleado.IdEmpleado, addedEmpleado.IdEmpleado);
            Assert.Equal(newEmpleado.Nombre, addedEmpleado.Nombre);
            Assert.Equal(newEmpleado.Cargo, addedEmpleado.Cargo);
        }

        [Fact]
        public async Task AddAsync_ExistingId_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var existingEmpleado = new Empleado { IdEmpleado = 1, Nombre = "Empleado Existente", Cargo = "Cargo Existente" };

            // Act / Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await _repository.AddAsync(existingEmpleado));
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateExistingEmpleado()
        {
            // Arrange
            int id = 1;
            var updatedEmpleado = new Empleado { IdEmpleado = id, Nombre = "Empleado Actualizado", Cargo = "Cargo Actualizado" };

            // Act
            await _repository.UpdateAsync(updatedEmpleado);

            // Assert
            var empleado = await _repository.GetByIdAsync(id);
            Assert.NotNull(empleado);
            Assert.Equal(updatedEmpleado.IdEmpleado, empleado.IdEmpleado);
            Assert.Equal(updatedEmpleado.Nombre, empleado.Nombre);
            Assert.Equal(updatedEmpleado.Cargo, empleado.Cargo);
        }

        [Fact]
        public async Task UpdateAsync_NonExistingId_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var updatedEmpleado = new Empleado { IdEmpleado = 999, Nombre = "Empleado Actualizado", Cargo = "Cargo Actualizado" };

            // Act / Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () => await _repository.UpdateAsync(updatedEmpleado));
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteExistingEmpleado()
        {
            // Arrange
            int id = 2;

            // Act
            await _repository.DeleteAsync(id);

            // Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () => await _repository.GetByIdAsync(id));
        }

        [Fact]
        public async Task DeleteAsync_NonExistingId_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            int id = 999; // Assuming this id does not exist in mock data

            // Act / Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () => await _repository.DeleteAsync(id));
        }
    }
}
