namespace Spa.Models
{
    public class Promocion
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; } = new();
        public Servicio Servicio { get; set; } = new();
        public DateTime FechaHora { get; set; }
        public int CantidadPersonas { get; set; }
        public decimal TotalFinal { get; set; }
    }
}
