﻿

namespace Restaurant.Infraestructure.Models.Factura
{
    public class UpdateFacturaModel
    {

        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int IdPedido { get; set; }

    }
}
