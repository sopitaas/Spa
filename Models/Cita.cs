using System;

namespace Spa.Models
{
    public class Cita
    {
        public int Id { get; set; }

        // Agrupamos en la entidad Cliente para corregir el error
        public Cliente Cliente { get; set; } = new Cliente();

        // Agrupamos en la entidad Servicio para que sea un diseño limpio
        public Servicio Servicio { get; set; } = new Servicio();

        public DateTime FechaHora { get; set; }
        public int CantidadPersonas { get; set; }
        public decimal TotalFinal { get; set; }
        public bool Confirmada { get; set; }
    }
}