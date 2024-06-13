
namespace Restaurant.Domain.Models.Factura
{
    public class SaveFacturaModel
    {
        
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int IdPedido { get; set; }

    }
}
