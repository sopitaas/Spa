using System;
using Spa.Interfaces;
using Spa.Models;

namespace Spa.Services
{
    public class NotificadorConsola : INotificador
    {
        public void EnviarConfirmacion(Cita cita)
        {
            // SRP RF3: Simulación por consola/log usando los datos de las entidades agrupadas en Cita
            Console.WriteLine("==================================================================");
            Console.WriteLine($"[NOTIFICACIÓN SISTEMA]: Alerta enviada con éxito.");
            Console.WriteLine($"Cliente: {cita.Cliente.Nombre} {cita.Cliente.Apellido} (DNI: {cita.Cliente.Dni})");
            Console.WriteLine($"Servicio reservado: {cita.Servicio.Nombre} ({cita.Servicio.Duracion})");
            Console.WriteLine($"Fecha/Hora: {cita.FechaHora} | Para: {cita.CantidadPersonas} persona(s)");
            Console.WriteLine($"Monto Final Procesado: S/. {cita.TotalFinal}");
            Console.WriteLine("==================================================================");
        }
    }
}