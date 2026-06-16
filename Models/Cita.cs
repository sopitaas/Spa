namespace Spa.Models
{
    public class Cita
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public int ServicioId { get; set; }

        public DateTime FechaHora { get; set; }

        public int CantidadPersonas { get; set; }

        public decimal TotalFinal { get; set; }

        public bool Confirmada { get; set; }

        public Cliente Cliente { get; set; } = null!;

        public Servicio Servicio { get; set; } = null!;
    }
}