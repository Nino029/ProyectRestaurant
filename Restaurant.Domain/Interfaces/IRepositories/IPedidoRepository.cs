using Restaurant.Domain.Entitites;


namespace Restaurant.Domain.Interfaces.IRepositories
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> GetAllAsync();
        Task<Pedido> GetByIdAsync(int id);
        Task AddAsync(Pedido pedido);
        Task UpdateAsync(Pedido pedido);
        Task DeleteAsync(int id);
    }
}
