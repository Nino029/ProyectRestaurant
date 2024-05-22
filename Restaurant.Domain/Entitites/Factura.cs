

namespace Restaurant.Domain.Entitites;

public partial class Factura
{
    public int IdFactura { get; set; }

    public int? IdPedido { get; set; }

    public decimal? Total { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual Pedido? IdPedidoNavigation { get; set; }
}
