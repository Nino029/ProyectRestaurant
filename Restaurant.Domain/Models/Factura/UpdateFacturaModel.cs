using System.Text.Json.Serialization;


namespace Restaurant.Infraestructure.Models.Factura
{
    public class UpdateFacturaModel
    {
        [JsonIgnore]

        public int IdFactura { get; set; } 
        public int IdPedido { get; set; } 
        public decimal Total { get; set; } 
        public DateTime Fecha { get; set; } 

    }
}
