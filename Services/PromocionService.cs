using Microsoft.EntityFrameworkCore;
using Spa.Data;
using Spa.Interfaces;
using Spa.Models;

namespace Spa.Services
{
    public class PromocionService : IPromocionService
    {
        private readonly SpaDbContext _context;

        public PromocionService(SpaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Promocion>> ObtenerTodasAsync()
            => await _context.Promociones.ToListAsync();

        public async Task<Promocion?> ObtenerPorIdAsync(int id)
            => await _context.Promociones.FindAsync(id);

        public async Task CrearAsync(Promocion promocion)
        {
            _context.Promociones.Add(promocion);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Promocion promocion)
        {
            _context.Promociones.Update(promocion);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var promo = await _context.Promociones.FindAsync(id);
            if (promo != null)
            {
                _context.Promociones.Remove(promo);
                await _context.SaveChangesAsync();
            }
        }
    }
}