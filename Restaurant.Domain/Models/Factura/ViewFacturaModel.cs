

namespace Restaurant.Domain.Models.Factura
{
    public  class ViewFacturaModel
    {
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int IdPedido { get; set; }

    }
}
