using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spa.Data;
using Spa.Interfaces;
using Spa.Models;

namespace Spa.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly SpaDbContext _context;
        private readonly IPromocionService _promocionService;

        public AdministradorController(SpaDbContext context, IPromocionService promocionService)
        {
            _context = context;
            _promocionService = promocionService;
        }

        // ── PANEL ────────────────────────────────────────────────────────────
        public IActionResult Panel()
        {
            ViewBag.TotalClientes = _context.Clientes.Count();
            ViewBag.TotalCitas = _context.Citas.Count();
            ViewBag.TotalPromociones = _context.Promociones.Count();
            ViewBag.TotalServicios = _context.Servicios.Count();

            var citas = _context.Citas
                .Include(c => c.Cliente)
                .Include(c => c.Servicio)
                .OrderByDescending(c => c.Id)
                .ToList();

            ViewBag.Clientes = _context.Clientes
                .OrderByDescending(c => c.Id)
                .ToList();

            return View(citas);
        }

        // ── ELIMINAR CITA ────────────────────────────────────────────────────
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarCita(int id)
        {
            var cita = _context.Citas.Find(id);
            if (cita != null)
            {
                _context.Citas.Remove(cita);
                _context.SaveChanges();
                TempData["Mensaje"] = "Cita eliminada correctamente.";
            }
            return RedirectToAction("Panel");
        }

        // ── ELIMINAR CLIENTE ─────────────────────────────────────────────────
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                // Eliminar primero las citas asociadas (FK constraint)
                var citasCliente = _context.Citas.Where(c => c.ClienteId == id).ToList();
                _context.Citas.RemoveRange(citasCliente);
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
                TempData["Mensaje"] = "Cliente y sus citas eliminados correctamente.";
            }
            return RedirectToAction("Panel");
        }

        // ── PROMOCIONES ──────────────────────────────────────────────────────
        [HttpGet]
        public async Task<IActionResult> Promociones()
        {
            var promociones = await _promocionService.ObtenerTodasAsync();
            return View(promociones);
        }

        [HttpGet]
        public IActionResult CrearPromocion() => View(new Promocion());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearPromocion(Promocion promocion)
        {
            if (!ModelState.IsValid) return View(promocion);
            await _promocionService.CrearAsync(promocion);
            return RedirectToAction("Promociones");
        }

        [HttpGet]
        public async Task<IActionResult> EditarPromocion(int id)
        {
            var promo = await _promocionService.ObtenerPorIdAsync(id);
            if (promo == null) return NotFound();
            return View(promo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarPromocion(Promocion promocion)
        {
            if (!ModelState.IsValid) return View(promocion);
            await _promocionService.ActualizarAsync(promocion);
            return RedirectToAction("Promociones");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarPromocion(int id)
        {
            await _promocionService.EliminarAsync(id);
            return RedirectToAction("Promociones");
        }

        // ── LOGIN ────────────────────────────────────────────────────────────
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string usuario, string password)
        {
            var admin = _context.Administradores
                .FirstOrDefault(a =>
                    a.Usuario == usuario &&
                    a.Password == password);

            if (admin != null)
                return RedirectToAction("Panel");

            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View();
        }
    }
}
