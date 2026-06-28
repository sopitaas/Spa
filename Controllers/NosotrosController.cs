using Microsoft.AspNetCore.Mvc;

namespace Spa.Controllers
{
    public class NosotrosController : Controller
    {
        public IActionResult Index()
        {
            // Renderizar la vista existente ubicada en Views/Home/nosotros.cshtml
            return View("~/Views/Home/nosotros.cshtml");
        }
    }
}
