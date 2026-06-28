namespace Spa.Models
{
    public class Servicio
    {
        public string IdServicio { get; set; } = string.Empty; 
        public string Nombre { get; set; } = string.Empty;
        public decimal PrecioBase { get; set; }
        public string Duracion { get; set; } = string.Empty;  
    }
}
