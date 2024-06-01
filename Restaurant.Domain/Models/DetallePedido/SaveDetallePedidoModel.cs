

namespace Restaurant.Domain.Models.DetallePedido
{
    public class SaveDetallePedidoModel
    {

        public int IdPedido { get; set; }
        public string NombrePlato { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
