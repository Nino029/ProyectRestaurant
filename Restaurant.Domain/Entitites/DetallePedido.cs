

namespace Restaurant.Domain.Entitites;

public partial class DetallePedido
{
    public int IdDetallePedido { get; set; } 

    public int? IdPedido { get; set; }

    public int? IdPlato { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Subtotal { get; set; }

    public virtual Pedido? IdPedidoNavigation { get; set; }

    public virtual Menu? IdPlatoNavigation { get; set; }
}
