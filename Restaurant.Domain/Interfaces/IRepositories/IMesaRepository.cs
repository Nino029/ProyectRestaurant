using Restaurant.Domain.Entitites;


namespace Restaurant.Domain.Interfaces.IRepositories
{
    public interface IMesaRepository
    {
        Task<IEnumerable<Mesa>> GetAllAsync();
        Task<Mesa> GetByIdAsync(int id);
        Task AddAsync(Mesa mesa);
        Task UpdateAsync(Mesa mesa);
        Task DeleteAsync(int id);
    }
}
