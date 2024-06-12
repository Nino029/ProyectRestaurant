
using Xunit;
using Restaurant.Domain.Entitites;
using Restaurant.Infrastructure.Repositories.Mock;
using Restaurant.Domain.Interfaces.IRepositories;

namespace Restaurant.Unit.Test.ClienteTest
{
    public class ClienteRepositoryTest
    {
        private readonly IClienteRepository _repository;

        public ClienteRepositoryTest()
        {
            _repository = new ClienteRepositoryMock();
        }

        [Fact]
        public async Task AgregarCliente()
        {
            // Arrange
            var cliente = new Cliente
            {
                IdCliente = 1,
                Nombre = "Cliente de Prueba",
                Telefono = "123456789",
                Email = "cliente@prueba.com"
            };

            // Act
            await _repository.AddAsync(cliente);

            // Assert
            var clienteAgregado = await _repository.GetByIdAsync(cliente.IdCliente);
            Assert.NotNull(clienteAgregado);
            Assert.Equal(cliente.IdCliente, clienteAgregado.IdCliente);
            Assert.Equal(cliente.Nombre, clienteAgregado.Nombre);
            Assert.Equal(cliente.Telefono, clienteAgregado.Telefono);
            Assert.Equal(cliente.Email, clienteAgregado.Email);
        }

        [Fact]
        public async Task ObtenerClienteID()
        {
            // Arrange
            var cliente = new Cliente
            {
                IdCliente = 2,
                Nombre = "Cliente Existente",
                Telefono = "987654321",
                Email = "existente@cliente.com"
            };
            await _repository.AddAsync(cliente);

            // Act
            var clienteObtenido = await _repository.GetByIdAsync(cliente.IdCliente);

            // Assert
            Assert.NotNull(clienteObtenido);
            Assert.Equal(cliente.IdCliente, clienteObtenido.IdCliente);
            Assert.Equal(cliente.Nombre, clienteObtenido.Nombre);
            Assert.Equal(cliente.Telefono, clienteObtenido.Telefono);
            Assert.Equal(cliente.Email, clienteObtenido.Email);
        }

        [Fact]
        public async Task ActualizarCliente()
        {
            // Arrange
            var cliente = new Cliente
            {
                IdCliente = 3,
                Nombre = "Cliente a Actualizar",
                Telefono = "555555555",
                Email = "actualizar@cliente.com"
            };
            await _repository.AddAsync(cliente);

            // Modificar los datos del cliente
            cliente.Nombre = "Cliente Actualizado";
            cliente.Telefono = "999999999";
            cliente.Email = "actualizado@cliente.com";

            // Act
            await _repository.UpdateAsync(cliente);

            // Assert
            var clienteActualizado = await _repository.GetByIdAsync(cliente.IdCliente);
            Assert.NotNull(clienteActualizado);
            Assert.Equal(cliente.IdCliente, clienteActualizado.IdCliente);
            Assert.Equal(cliente.Nombre, clienteActualizado.Nombre);
            Assert.Equal(cliente.Telefono, clienteActualizado.Telefono);
            Assert.Equal(cliente.Email, clienteActualizado.Email);
        }

        [Fact]
        public async Task EliminarCliente()
        {
            // Arrange
            var cliente = new Cliente
            {
                IdCliente = 4,
                Nombre = "Cliente a Eliminar",
                Telefono = "444444444",
                Email = "eliminar@cliente.com"
            };
            await _repository.AddAsync(cliente);

            // Act
            await _repository.DeleteAsync(cliente.IdCliente);

            // Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await _repository.GetByIdAsync(cliente.IdCliente);
            });
        }
    }
}
