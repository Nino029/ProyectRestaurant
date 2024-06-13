using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entitites;

namespace Restaurant.Infraestructure.Context
{
    public class ApplicationDbContext : DbContext
    {



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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region "Table"

            modelBuilder.Entity<Cliente>()
            .ToTable("Clientes");

            modelBuilder.Entity<DetallePedido>()
          .ToTable("DetallePedidos");

            modelBuilder.Entity<Empleado>()
          .ToTable("Empleados");

            modelBuilder.Entity<Factura>()
          .ToTable("Facturas");

            modelBuilder.Entity<Menu>()
          .ToTable("Menus");

            modelBuilder.Entity<Mesa>()
          .ToTable("Mesas");

            modelBuilder.Entity<Pedido>()
          .ToTable("Pedidos");
            #endregion

            #region "Primary keys"
            modelBuilder.Entity<Cliente>()
                .HasKey(x => x.IdCliente);

            modelBuilder.Entity<DetallePedido>()
                .HasKey(x => x.IdDetallePedido);

            modelBuilder.Entity<Empleado>()
            .HasKey(x => x.IdEmpleado);

            modelBuilder.Entity<Factura>()
            .HasKey(x => x.IdFactura);

            modelBuilder.Entity<Menu>()
            .HasKey(x => x.IdPlato);

            modelBuilder.Entity<Mesa>()
            .HasKey(x => x.IdMesa);

            modelBuilder.Entity<Pedido>()
            .HasKey(x => x.IdPedido);

          

            #endregion
        }
    }
}
