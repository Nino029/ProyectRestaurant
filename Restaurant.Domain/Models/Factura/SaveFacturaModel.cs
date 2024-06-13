using System.Text.Json;

namespace Restaurant.Domain.Models.Factura
{
    public class SaveFacturaModel
    {

        public int IdPedido { get; set; } 
        public decimal Total { get; set; }
       
        public DateTime Fecha { get; set; } 

    }
}
