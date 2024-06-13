using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.IdEmpleado);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    IdPlato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.IdPlato);
                });

            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    IdMesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacidad = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.IdMesa);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: true),
                    IdMesa = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdClienteNavigationIdCliente = table.Column<int>(type: "int", nullable: true),
                    IdMesaNavigationIdMesa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_IdClienteNavigationIdCliente",
                        column: x => x.IdClienteNavigationIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK_Pedidos_Mesas_IdMesaNavigationIdMesa",
                        column: x => x.IdMesaNavigationIdMesa,
                        principalTable: "Mesas",
                        principalColumn: "IdMesa");
                });

            migrationBuilder.CreateTable(
                name: "DetallePedidos",
                columns: table => new
                {
                    IdDetallePedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPedido = table.Column<int>(type: "int", nullable: true),
                    IdPlato = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdPedidoNavigationIdPedido = table.Column<int>(type: "int", nullable: true),
                    IdPlatoNavigationIdPlato = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedidos", x => x.IdDetallePedido);
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Menus_IdPlatoNavigationIdPlato",
                        column: x => x.IdPlatoNavigationIdPlato,
                        principalTable: "Menus",
                        principalColumn: "IdPlato");
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Pedidos_IdPedidoNavigationIdPedido",
                        column: x => x.IdPedidoNavigationIdPedido,
                        principalTable: "Pedidos",
                        principalColumn: "IdPedido");
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    IdFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPedido = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: true),
                    IdPedidoNavigationIdPedido = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK_Facturas_Pedidos_IdPedidoNavigationIdPedido",
                        column: x => x.IdPedidoNavigationIdPedido,
                        principalTable: "Pedidos",
                        principalColumn: "IdPedido");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_IdPedidoNavigationIdPedido",
                table: "DetallePedidos",
                column: "IdPedidoNavigationIdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_IdPlatoNavigationIdPlato",
                table: "DetallePedidos",
                column: "IdPlatoNavigationIdPlato");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_IdPedidoNavigationIdPedido",
                table: "Facturas",
                column: "IdPedidoNavigationIdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdClienteNavigationIdCliente",
                table: "Pedidos",
                column: "IdClienteNavigationIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdMesaNavigationIdMesa",
                table: "Pedidos",
                column: "IdMesaNavigationIdMesa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallePedidos");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Mesas");
        }
    }
}
