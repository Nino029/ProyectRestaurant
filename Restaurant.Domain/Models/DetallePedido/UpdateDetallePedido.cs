

namespace Restaurant.Infraestructure.Models.DetallePedido
{
    public class UpdateDetallePedido
    {
        public int IdDetallePedido { get; set; }
        public int IdPedido { get; set; }
        public string NombrePlato { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }


    }
}
