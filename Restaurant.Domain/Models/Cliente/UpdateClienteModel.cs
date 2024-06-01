namespace Restaurant.Infraestructure.Models.Cliente
{
    public class UpdateClienteModel
    {
        public int IdCliente { get; set; }
        public string ?Nombre { get; set; }
        public string ?Telefono { get; set; }
        public string  ?Email { get; set; }
    }
}
