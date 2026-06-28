using Spa.Models;

namespace Spa.Interfaces
{
    // DIP: Es una abstracción pura. El sistema depende de esta interfaz 
    public interface ICalculadorDescuento
    {
        decimal CalcularTotal(Servicio servicio, int cantidadPersonas);
    }
}