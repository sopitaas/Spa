using Microsoft.AspNetCore.Mvc;
using Spa.Data;
using Spa.Models;

namespace Spa.Controllers
{
    public class TestController : Controller
    {
        private readonly SpaDbContext _context;

        public TestController(SpaDbContext context)
        {
            _context = context;
        }

        public IActionResult CrearCliente()
        {
            var cliente = new Cliente
            {
                Dni = "12345678",
                Nombre = "Juan",
                Apellido = "Perez",
                TipoCliente = "Regular"
            };

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return Content("Cliente guardado correctamente");
        }
    }
}