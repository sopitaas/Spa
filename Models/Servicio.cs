namespace Spa.Models
{
    public class Servicio
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public decimal PrecioBase { get; set; }

        public string Duracion { get; set; } = string.Empty;
    }
}