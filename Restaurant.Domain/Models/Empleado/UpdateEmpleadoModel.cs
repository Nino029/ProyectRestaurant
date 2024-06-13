using System.Text.Json.Serialization;

namespace Restaurant.Infraestructure.Models.Empleado
{
    public class UpdateEmpleadoModel
    {
        [JsonIgnore]
        public int IdEmpleado { get; set; }
        public string? Nombre { get; set; }
        public string? Cargo { get; set; }

    }
}
