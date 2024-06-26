﻿using System.Text.Json.Serialization;

namespace Restaurant.Infraestructure.Models.Menu
{
    public class UpdateMenuModel
    {
        [JsonIgnore]
        public int IdPlato { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public string? Categoria { get; set; }
    }
}
