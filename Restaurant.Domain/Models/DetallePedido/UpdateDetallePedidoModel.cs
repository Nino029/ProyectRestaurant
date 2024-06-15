

using System.Text.Json.Serialization;

namespace Restaurant.Infraestructure.Models.DetallePedido
{
    public class UpdateDetallePedidoModel
    {
        [JsonIgnore]
        public int IdDetallePedido { get; set; }
        public int? IdPedido { get; set; }
        public int? IdPlato { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Subtotal { get; set; }

    }
}
