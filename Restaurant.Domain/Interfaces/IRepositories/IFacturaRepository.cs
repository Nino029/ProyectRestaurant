

using Restaurant.Domain.Entitites;

namespace Restaurant.Domain.Interfaces.IRepositories
{
    public interface IFacturaRepository
    {
        Task<IEnumerable<Factura>> GetAllAsync();
        Task<Factura> GetByIdAsync(int id);
        Task AddAsync(Factura factura);
        Task UpdateAsync(Factura factura);
        Task DeleteAsync(int id);
    }
}
