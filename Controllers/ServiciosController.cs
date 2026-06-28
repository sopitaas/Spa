using Microsoft.AspNetCore.Mvc;

namespace Spa.Controllers
{
    public class ServiciosController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Home/servicios.cshtml");
        }
    }
}
