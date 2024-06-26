﻿using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Infraestructure.Context;


namespace Restaurant.Infraestructure.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly ApplicationDbContext _context;

        public MenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Menu>> GetAllAsync()
        {
            return await _context.Set<Menu>().ToListAsync();
        }

        public async Task<Menu> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var menu = await _context.Set<Menu>().FindAsync(id);

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

            await _context.Set<Menu>().AddAsync(menu);
            await _context.SaveChangesAsync();
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

            var existingMenu = await _context.Set<Menu>().FindAsync(menu.IdPlato);
            if (existingMenu == null)
            {
                throw new KeyNotFoundException("Menú no encontrado");
            }

            _context.Entry(existingMenu).CurrentValues.SetValues(menu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var menu = await _context.Set<Menu>().FindAsync(id);
            if (menu == null)
            {
                throw new KeyNotFoundException("Menú no encontrado");
            }

            _context.Set<Menu>().Remove(menu);
            await _context.SaveChangesAsync();
        }
    }
}
