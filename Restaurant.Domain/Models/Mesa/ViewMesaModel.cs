using System;
using System.Collections.Generic;


namespace Restaurant.Domain.Models.Mesa
{
   public class ViewMesaModel
    {
        public int IdMesa { get; set; }
        public int? Capacidad { get; set; }
        public string? Estado { get; set; }
    }
}
