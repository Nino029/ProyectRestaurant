﻿using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Infraestructure.Context;


namespace Restaurant.Infraestructure.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            return await _context.Set<Empleado>().ToListAsync();
        }

        public async Task<Empleado> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var empleado = await _context.Set<Empleado>().FindAsync(id);

            if (empleado == null)
            {
                throw new KeyNotFoundException("Empleado no encontrado");
            }

            return empleado;
        }

        public async Task AddAsync(Empleado empleado)
        {
            if (empleado == null)
            {
                throw new ArgumentNullException(nameof(empleado), "El empleado no puede ser nulo");
            }

            await _context.Set<Empleado>().AddAsync(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Empleado empleado)
        {
            if (empleado == null)
            {
                throw new ArgumentNullException(nameof(empleado), "El empleado no puede ser nulo");
            }

            if (empleado.IdEmpleado <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(empleado.IdEmpleado));
            }

            var existingEmpleado = await _context.Set<Empleado>().FindAsync(empleado.IdEmpleado);
            if (existingEmpleado == null)
            {
                throw new KeyNotFoundException("Empleado no encontrado");
            }

            _context.Entry(existingEmpleado).CurrentValues.SetValues(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var empleado = await _context.Set<Empleado>().FindAsync(id);
            if (empleado == null)
            {
                throw new KeyNotFoundException("Empleado no encontrado");
            }

            _context.Set<Empleado>().Remove(empleado);
            await _context.SaveChangesAsync();
        }
    }
}
