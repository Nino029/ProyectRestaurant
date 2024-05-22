using Restaurant.Domain.Entitites;


namespace Restaurant.Domain.Interfaces.IRepositories
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Menu>> GetAllAsync();
        Task<Menu> GetByIdAsync(int id);
        Task AddAsync(Menu menu);
        Task UpdateAsync(Menu menu);
        Task DeleteAsync(int id);
    }

}
