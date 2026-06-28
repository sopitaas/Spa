using Microsoft.AspNetCore.Mvc;
using Spa.Interfaces;
using Spa.Models;
using Spa.Services;
using System;

namespace Spa.Controllers
{
    public class CitaController : Controller
    {
        private readonly ICitaService _citaService;

        // DIP: El controlador no depende de la clase fija CitaService, depende de la interfaz ICitaService
        public CitaController(ICitaService citaService)
        {
            _citaService = citaService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("Crear");
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View("~/Views/Home/cita.cshtml");
        }

        // SRP: Requerimiento01: Solo recibe los datos de la web, elige la estrategia y delega el agendamiento. 
        [HttpPost]
        public IActionResult Crear(string dni, string nombre, string apellido, string tipoCliente, string idServicio, int cantidadPersonas, DateTime fecha)
        {
            var servicioSeleccionado = new Servicio
            {
                IdServicio = idServicio,
                Nombre = idServicio == "masaje-relajante" ? "Masaje Relajante" : "Tratamiento Facial",
                Duracion = "60 min",
                PrecioBase = idServicio == "masaje-relajante" ? 120.00m : 80.00m
            };

            var cliente = new Cliente
            {
                Dni = dni,
                Nombre = nombre,
                Apellido = apellido,
                TipoCliente = tipoCliente
            };

            // OCP: Permite cambiar o asignar la estrategia de descuento (VIP o Sin Descuento) usando polimorfismo sin alterar el flujo principal
            ICalculadorDescuento estrategia = tipoCliente == "VIP"
                ? new DescuentoVIP()
                : new SinDescuento();
            // RF1, RF2 y RF3 ejecutados aquí de forma limpia
            Cita citaProcesada = _citaService.AgendarCita(cliente, servicioSeleccionado, fecha, cantidadPersonas, estrategia);

            return View("~/Views/Home/bienvenida.cshtml", citaProcesada);
        }
    }
}