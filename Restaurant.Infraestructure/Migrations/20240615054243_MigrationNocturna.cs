using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationNocturna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedidos_Menus_IdPlatoNavigationIdPlato",
                table: "DetallePedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedidos_Pedidos_IdPedidoNavigationIdPedido",
                table: "DetallePedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_IdClienteNavigationIdCliente",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Mesas_IdMesaNavigationIdMesa",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_IdClienteNavigationIdCliente",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_IdMesaNavigationIdMesa",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_DetallePedidos_IdPedidoNavigationIdPedido",
                table: "DetallePedidos");

            migrationBuilder.DropIndex(
                name: "IX_DetallePedidos_IdPlatoNavigationIdPlato",
                table: "DetallePedidos");

            migrationBuilder.DropColumn(
                name: "IdClienteNavigationIdCliente",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "IdMesaNavigationIdMesa",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "IdPedidoNavigationIdPedido",
                table: "DetallePedidos");

            migrationBuilder.DropColumn(
                name: "IdPlatoNavigationIdPlato",
                table: "DetallePedidos");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdCliente",
                table: "Pedidos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdMesa",
                table: "Pedidos",
                column: "IdMesa");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_IdPedido",
                table: "DetallePedidos",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_IdPlato",
                table: "DetallePedidos",
                column: "IdPlato");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedidos_Menus_IdPlato",
                table: "DetallePedidos",
                column: "IdPlato",
                principalTable: "Menus",
                principalColumn: "IdPlato");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedidos_Pedidos_IdPedido",
                table: "DetallePedidos",
                column: "IdPedido",
                principalTable: "Pedidos",
                principalColumn: "IdPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_IdCliente",
                table: "Pedidos",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Mesas_IdMesa",
                table: "Pedidos",
                column: "IdMesa",
                principalTable: "Mesas",
                principalColumn: "IdMesa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedidos_Menus_IdPlato",
                table: "DetallePedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedidos_Pedidos_IdPedido",
                table: "DetallePedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_IdCliente",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Mesas_IdMesa",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_IdCliente",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_IdMesa",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_DetallePedidos_IdPedido",
                table: "DetallePedidos");

            migrationBuilder.DropIndex(
                name: "IX_DetallePedidos_IdPlato",
                table: "DetallePedidos");

            migrationBuilder.AddColumn<int>(
                name: "IdClienteNavigationIdCliente",
                table: "Pedidos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdMesaNavigationIdMesa",
                table: "Pedidos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPedidoNavigationIdPedido",
                table: "DetallePedidos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPlatoNavigationIdPlato",
                table: "DetallePedidos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdClienteNavigationIdCliente",
                table: "Pedidos",
                column: "IdClienteNavigationIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdMesaNavigationIdMesa",
                table: "Pedidos",
                column: "IdMesaNavigationIdMesa");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_IdPedidoNavigationIdPedido",
                table: "DetallePedidos",
                column: "IdPedidoNavigationIdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_IdPlatoNavigationIdPlato",
                table: "DetallePedidos",
                column: "IdPlatoNavigationIdPlato");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedidos_Menus_IdPlatoNavigationIdPlato",
                table: "DetallePedidos",
                column: "IdPlatoNavigationIdPlato",
                principalTable: "Menus",
                principalColumn: "IdPlato");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedidos_Pedidos_IdPedidoNavigationIdPedido",
                table: "DetallePedidos",
                column: "IdPedidoNavigationIdPedido",
                principalTable: "Pedidos",
                principalColumn: "IdPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_IdClienteNavigationIdCliente",
                table: "Pedidos",
                column: "IdClienteNavigationIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Mesas_IdMesaNavigationIdMesa",
                table: "Pedidos",
                column: "IdMesaNavigationIdMesa",
                principalTable: "Mesas",
                principalColumn: "IdMesa");
        }
    }
}
