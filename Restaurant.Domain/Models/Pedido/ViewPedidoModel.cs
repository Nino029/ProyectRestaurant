

namespace Restaurant.Domain.Models.Pedido
{
    public class ViewPedidoModel
    {
        public int IdPedido { get; set; }
        public int? IdCliente { get; set; }
        public int? IdMesa { get; set; }
        public DateOnly? Fecha { get; set; }
        public decimal? Total { get; set; }
    }
}
