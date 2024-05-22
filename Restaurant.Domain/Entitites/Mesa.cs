

namespace Restaurant.Domain.Entitites;

public partial class Mesa
{
    public int IdMesa { get; set; }

    public int? Capacidad { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
