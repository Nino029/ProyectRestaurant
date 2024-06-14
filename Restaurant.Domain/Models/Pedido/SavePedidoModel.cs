

namespace Restaurant.Domain.Models.Pedido
{
    public class SavePedidoModel
    {
        public int? IdCliente { get; set; }
        public int? IdMesa { get; set; }
        public DateOnly? Fecha { get; set; }
        public decimal? Total { get; set; }
    }
}
