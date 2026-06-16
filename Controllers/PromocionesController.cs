
using Microsoft.AspNetCore.Mvc;
using Spa.Data;

namespace Spa.Controllers
{
    public class PromocionesController : Controller
    {
        private readonly SpaDbContext _context;

        public PromocionesController(SpaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var promociones = _context.Promociones
                                      .Where(p => p.Activa)
                                      .ToList();

            return View("~/Views/Home/promociones.cshtml", promociones);
        }
    }
}