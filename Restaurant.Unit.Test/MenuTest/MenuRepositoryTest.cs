using System.Threading.Tasks;
using Xunit;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Infraestructure.Repositories.Mock.Menus;

namespace Restaurant.Unit.Test.MenuTest
{
    public class MenuRepositoryTest
    {
        private readonly IMenuRepository _repository;

        public MenuRepositoryTest()
        {
            _repository = new MenuRepositoryMock();
        }

        [Fact]
        public async Task AddAsync_ShouldAddNewMenu()
        {
            // Arrange
            var newMenu = new Menu { IdPlato = 3, Nombre = "Plato3", Precio = 20.00m };

            // Act
            await _repository.AddAsync(newMenu);
            var addedMenu = await _repository.GetByIdAsync(3);

            // Assert
            Assert.NotNull(addedMenu);
            Assert.Equal(newMenu.Nombre, addedMenu.Nombre);
            Assert.Equal(newMenu.Precio, addedMenu.Precio);
        }

        [Fact]
        public async Task GetByIdAsync_ExistingMenu_ShouldReturnMenu()
        {
            // Act
            var menu = await _repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(menu);
            Assert.Equal(1, menu.IdPlato);
        }

        [Fact]
        public async Task GetByIdAsync_NonExistingMenu_ShouldThrowKeyNotFoundException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _repository.GetByIdAsync(99));
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateExistingMenu()
        {
            // Arrange
            var updatedMenu = new Menu { IdPlato = 1, Nombre = "UpdatedPlato1", Precio = 25.00m };

            // Act
            await _repository.UpdateAsync(updatedMenu);
            var menu = await _repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(menu);
            Assert.Equal(updatedMenu.Nombre, menu.Nombre);
            Assert.Equal(updatedMenu.Precio, menu.Precio);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteExistingMenu()
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
