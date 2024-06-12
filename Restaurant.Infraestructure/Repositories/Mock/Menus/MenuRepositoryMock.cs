

using System.Threading.Tasks;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;

namespace Restaurant.Infraestructure.Repositories.Mock.Menus
{
    public class MenuRepositoryMock : IMenuRepository
    {
        private readonly List<Menu> _menus;

        public MenuRepositoryMock()
        {
            _menus = new List<Menu>
            {
                new Menu { IdPlato = 1, Nombre = "Plato1", Precio = 10.00m },
                new Menu { IdPlato = 2, Nombre = "Plato2", Precio = 15.50m }
            };
        }

        public async Task<IEnumerable<Menu>> GetAllAsync()
        {
            return await Task.Run(() => _menus.ToList());
        }

        public async Task<Menu> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var menu = _menus.FirstOrDefault(m => m.IdPlato == id);

            if (menu == null)
            {
                throw new KeyNotFoundException("Menú no encontrado");
            }

            return menu;
        }

        public async Task AddAsync(Menu menu)
        {
            if (menu == null)
            {
                throw new ArgumentNullException(nameof(menu), "El menú no puede ser nulo");
            }

            if (_menus.Any(m => m.IdPlato == menu.IdPlato))
            {
                throw new InvalidOperationException("Ya existe un menú con el mismo Id.");
            }

            _menus.Add(menu);
        }

        public async Task UpdateAsync(Menu menu)
        {
            if (menu == null)
            {
                throw new ArgumentNullException(nameof(menu), "El menú no puede ser nulo");
            }

            if (menu.IdPlato <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(menu.IdPlato));
            }

            var existingMenu = _menus.FirstOrDefault(m => m.IdPlato == menu.IdPlato);
            if (existingMenu == null)
            {
                throw new KeyNotFoundException("Menú no encontrado");
            }

            existingMenu.Nombre = menu.Nombre;
            existingMenu.Precio = menu.Precio;
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var menu = _menus.FirstOrDefault(m => m.IdPlato == id);
            if (menu == null)
            {
                throw new KeyNotFoundException("Menú no encontrado");
            }

            _menus.Remove(menu);
        }
    }
}
