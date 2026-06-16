using Spa.Interfaces;
using Spa.Models;
using Spa.Data;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Spa.Services
{
    // SRP: Requerimiento 1: Su única función es coordinar el flujo del agendamiento.
    public class CitaService : ICitaService
    {
        private readonly SpaDbContext _context;
        private readonly INotificador _notificador;

        // DIP: Inyectamos la interfaz del notificador
        public CitaService(SpaDbContext context, INotificador notificador)
        {
            _context = context;
            _notificador = notificador;
        }

        public Cita AgendarCita(Cliente cliente, Servicio servicio, DateTime fecha, int cantidadPersonas, ICalculadorDescuento estrategiaDescuento)
        {
            // OCP: El cálculo del total se delega a la estrategia
            decimal totalCalculado = estrategiaDescuento.CalcularTotal(servicio, cantidadPersonas);
            var clienteExistente = _context.Clientes.FirstOrDefault(c => c.Dni == cliente.Dni);
            if (clienteExistente == null)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                clienteExistente = cliente;
            }
            var nuevaCita = new Cita
            {
                ClienteId = clienteExistente.Id,
                ServicioId = servicio.Id,
                FechaHora = fecha,
                CantidadPersonas = cantidadPersonas,
                TotalFinal = totalCalculado,
                Confirmada = true
            };
            _context.Citas.Add(nuevaCita);
            _context.SaveChanges();
            nuevaCita.Cliente = clienteExistente;
            nuevaCita.Servicio = servicio;
            // SRP: El servicio no sabe armar textos ni canales de envío, le delega la notificación al componente experto
            _notificador.EnviarConfirmacion(nuevaCita);

            return nuevaCita;
        }
    }
}