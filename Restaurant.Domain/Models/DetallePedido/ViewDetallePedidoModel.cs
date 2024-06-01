

namespace Restaurant.Domain.Models.DetallePedido
{
    public class ViewDetallePedidoModel
    {

        public int IdDetallePedido { get; set; }
        public int IdPedido { get; set; }
        public string ?NombrePlato { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }

    }
}
