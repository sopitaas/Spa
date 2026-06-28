using Microsoft.AspNetCore.Mvc;

namespace Spa.Controllers
{
    public class PromocionesController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Home/promociones.cshtml");
        }
    }
}
