

namespace Restaurant.Domain.Models.DetallePedido
{
    public class SaveDetallePedidoModel
    {

        public int IdPedido { get; set; }
        public int IdPlato { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
