using Spa.Models;

namespace Spa.Interfaces
{
    public interface IPromocionService
    {
        Task<List<Promocion>> ObtenerTodasAsync();
        Task<Promocion?> ObtenerPorIdAsync(int id);
        Task CrearAsync(Promocion promocion);
        Task ActualizarAsync(Promocion promocion);
        Task EliminarAsync(int id);
    }
}