using System;
using Spa.Models;

namespace Spa.Interfaces
{
    public interface ICitaService
    {
        Cita AgendarCita(
            Cliente cliente,
            Servicio servicio,
            DateTime fecha,
            int cantidadPersonas,
            ICalculadorDescuento estrategiaDescuento);
    }
}