
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entitites;


namespace Restaurant.Infraestructure.Context;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI;Database=RestauranteDB;Trusted_Connection=true;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D59466424CDE4BFD");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.IdDetallePedido).HasName("PK__DetalleP__48AFFD95A0447F63");

            entity.ToTable("DetallePedido");

            entity.Property(e => e.IdDetallePedido).ValueGeneratedNever();
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK__DetallePe__IdPed__4316F928");

            entity.HasOne(d => d.IdPlatoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdPlato)
                .HasConstraintName("FK__DetallePe__IdPla__440B1D61");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__CE6D8B9E9AAF3239");

            entity.ToTable("Empleado");

            entity.Property(e => e.IdEmpleado).ValueGeneratedNever();
            entity.Property(e => e.Cargo).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__Factura__50E7BAF18FB3789A");

            entity.ToTable("Factura");

            entity.Property(e => e.IdFactura).ValueGeneratedNever();
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK__Factura__IdPedid__46E78A0C");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdPlato).HasName("PK__Menu__4C943920AACE2645");

            entity.ToTable("Menu");

            entity.Property(e => e.IdPlato).ValueGeneratedNever();
            entity.Property(e => e.Categoria).HasMaxLength(20);
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.IdMesa).HasName("PK__Mesa__4D7E81B12A5AAFBC");

            entity.ToTable("Mesa");

            entity.Property(e => e.IdMesa).ValueGeneratedNever();
            entity.Property(e => e.Estado).HasMaxLength(20);
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__Pedido__9D335DC309428258");

            entity.ToTable("Pedido");

            entity.Property(e => e.IdPedido).ValueGeneratedNever();
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Pedido__IdClient__3F466844");

            entity.HasOne(d => d.IdMesaNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdMesa)
                .HasConstraintName("FK__Pedido__IdMesa__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
