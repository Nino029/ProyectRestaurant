﻿using System.Text.Json.Serialization;

namespace Restaurant.Infraestructure.Models.Mesa
{
    public class UpdateMesaModel
    {
        [JsonIgnore]
        public int IdMesa { get; set; }
        public int? Capacidad { get; set; }
        public string? Estado { get; set; }
    }
}
