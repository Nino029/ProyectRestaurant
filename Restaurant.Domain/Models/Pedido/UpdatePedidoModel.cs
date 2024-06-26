﻿using System.Text.Json.Serialization;

namespace Restaurant.Infraestructure.Models.Pedido
{
    public class UpdatePedidoModel
    {
        [JsonIgnore]
        public int IdPedido { get; set; }
        public int? IdCliente { get; set; }
        public int? IdMesa { get; set; }
        public DateOnly? Fecha { get; set; }
        public decimal? Total { get; set; }
    }
}
