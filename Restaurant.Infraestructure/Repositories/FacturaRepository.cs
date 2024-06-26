﻿using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Infraestructure.Context;


namespace Restaurant.Infraestructure.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly ApplicationDbContext _context;

        public FacturaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Factura>> GetAllAsync()
        {
            return await _context.Set<Factura>().ToListAsync();
        }

        public async Task<Factura> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var factura = await _context.Set<Factura>().FindAsync(id);

            if (factura == null)
            {
                throw new KeyNotFoundException("Factura no encontrada");
            }

            return factura;
        }

        public async Task AddAsync(Factura factura)
        {
            if (factura == null)
            {
                throw new ArgumentNullException(nameof(factura), "La factura no puede ser nula");
            }

            await _context.Set<Factura>().AddAsync(factura);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Factura factura)
        {
            if (factura == null)
            {
                throw new ArgumentNullException(nameof(factura), "La factura no puede ser nula");
            }

            if (factura.IdFactura <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(factura.IdFactura));
            }

            var existingFactura = await _context.Set<Factura>().FindAsync(factura.IdFactura);
            if (existingFactura == null)
            {
                throw new KeyNotFoundException("Factura no encontrada");
            }

            _context.Entry(existingFactura).CurrentValues.SetValues(factura);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            var factura = await _context.Set<Factura>().FindAsync(id);
            if (factura == null)
            {
                throw new KeyNotFoundException("Factura no encontrada");
            }

            _context.Set<Factura>().Remove(factura);
            await _context.SaveChangesAsync();
        }
    }
}
