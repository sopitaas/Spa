namespace Spa.Models
{
    public class Cliente
    {
        public string Dni { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string TipoCliente { get; set; } = "Regular";
    }
}
