using Spa.Interfaces;
using Spa.Models;

namespace Spa.Services
{
    // Cumple OCP: Estrategia para Clientes VIP (Aplica 15% de descuento al total)
    public class DescuentoVIP : ICalculadorDescuento
    {
        // SRP: Su única responsabilidad es aplicar la fórmula matemática del 15% de descuento para clientes VIP.
        public decimal CalcularTotal(Servicio servicio, int cantidadPersonas)
        {
            decimal subtotal = servicio.PrecioBase * cantidadPersonas;
            return subtotal * 0.85m; 
        }
    }

    // Cumple OCP: Estrategia para Clientes Regulares (Sin descuento)
    public class SinDescuento : ICalculadorDescuento
    {
        // SRP: Su única responsabilidad es calcular el precio regular, sin aplicar ninguna alteración o rebaja.
        public decimal CalcularTotal(Servicio servicio, int cantidadPersonas)
        {
            return servicio.PrecioBase * cantidadPersonas;
        }
    }
}