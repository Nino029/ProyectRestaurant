using Restaurant.Domain.Entitites;


namespace Restaurant.Domain.Interfaces.IRepositories
{
    public interface IDetallePedidoRepository
    {
        Task<IEnumerable<DetallePedido>> GetAllAsync();
        Task<DetallePedido> GetByIdAsync(int id);
        Task AddAsync(DetallePedido detallePedido);
        Task UpdateAsync(DetallePedido detallePedido);
        Task DeleteAsync(int id);
    }
}
