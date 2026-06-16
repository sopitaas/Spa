namespace Spa.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Dni { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string TipoCliente { get; set; } = "Regular";

        // Para login de clientes registrados
        public string? Correo { get; set; }

        public string? Password { get; set; }
    }
}
