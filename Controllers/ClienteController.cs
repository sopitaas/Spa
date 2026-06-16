using Microsoft.AspNetCore.Mvc;
using Spa.Data;
using Spa.Models;

namespace Spa.Controllers
{
    public class ClienteController : Controller
    {
        private readonly SpaDbContext _context;

        public ClienteController(SpaDbContext context)
        {
            _context = context;
        }

        // ── GET: /Cliente/Login ──────────────────────────────────────────────
        [HttpGet]
        public IActionResult Login()
        {
            // Si ya hay sesión activa, redirigir directo al inicio
            if (HttpContext.Session.GetString("ClienteNombre") != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        // ── POST: /Cliente/Login ─────────────────────────────────────────────
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string correo, string password)
        {
            var cliente = _context.Clientes
                .FirstOrDefault(c => c.Correo == correo && c.Password == password);

            if (cliente == null)
            {
                ViewBag.Error = "Correo o contraseña incorrectos.";
                return View();
            }

            // Guardar datos de sesión
            HttpContext.Session.SetInt32("ClienteId", cliente.Id);
            HttpContext.Session.SetString("ClienteNombre", cliente.Nombre);
            HttpContext.Session.SetString("ClienteTipo", cliente.TipoCliente);

            return RedirectToAction("Index", "Home");
        }

        // ── GET: /Cliente/Registro ───────────────────────────────────────────
        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        // ── POST: /Cliente/Registro ──────────────────────────────────────────
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro(string dni, string nombre, string apellido,
                                      string correo, string password)
        {
            // Validar que el correo no esté ya registrado
            if (_context.Clientes.Any(c => c.Correo == correo))
            {
                ViewBag.Error = "Ya existe una cuenta con ese correo.";
                return View();
            }

            var nuevoCliente = new Cliente
            {
                Dni = dni,
                Nombre = nombre,
                Apellido = apellido,
                TipoCliente = "VIP",   // registrado = VIP → descuento automático
                Correo = correo,
                Password = password
            };

            _context.Clientes.Add(nuevoCliente);
            _context.SaveChanges();

            // Login automático tras registrarse
            HttpContext.Session.SetInt32("ClienteId", nuevoCliente.Id);
            HttpContext.Session.SetString("ClienteNombre", nuevoCliente.Nombre);
            HttpContext.Session.SetString("ClienteTipo", nuevoCliente.TipoCliente);

            return RedirectToAction("Index", "Home");
        }

        // ── GET: /Cliente/Logout ─────────────────────────────────────────────
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Bienvenida", "Home");
        }
    }
}
