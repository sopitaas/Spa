using Spa.Interfaces;
using Spa.Models;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Spa.Services
{
    // SRP: Requerimiento 1: Su única función es coordinar el flujo del agendamiento.
    public class CitaService : ICitaService
    {
        private readonly INotificador _notificador;

        // DIP: Inyectamos la interfaz del notificador
        public CitaService(INotificador notificador)
        {
            _notificador = notificador;
        }

        public Cita AgendarCita(Cliente cliente, Servicio servicio, DateTime fecha, int cantidadPersonas, ICalculadorDescuento estrategiaDescuento)
        {
            // OCP: El cálculo del total se delega a la estrategia
            decimal totalCalculado = estrategiaDescuento.CalcularTotal(servicio, cantidadPersonas);

            var nuevaCita = new Cita
            {
                Id = new Random().Next(1, 10000),
                Cliente = cliente,
                Servicio = servicio,
                FechaHora = fecha,
                CantidadPersonas = cantidadPersonas,
                TotalFinal = totalCalculado,
                Confirmada = true
            };

            // SRP: El servicio no sabe armar textos ni canales de envío, le delega la notificación al componente experto
            _notificador.EnviarConfirmacion(nuevaCita);

            return nuevaCita;
        }
    }
}