using Microsoft.AspNetCore.Mvc;
using ProyectoPortafolioNetCore.Interfaces;
using ProyectoPortafolioNetCore.Models;
using ProyectoPortafolioNetCore.Servicios;
using System.Diagnostics;

namespace ProyectoPortafolioNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyecto repositorioProyectos;
        private readonly IServicioEmail _servicioEmail;

        public HomeController(ILogger<HomeController> logger
                                , IRepositorioProyecto repositorio
                                , IServicioEmail servicioEmail)
        {
            _logger = logger;
            repositorioProyectos = repositorio;
            _servicioEmail = servicioEmail;
        }

        public IActionResult Index()
        {

            _logger.LogInformation("Esto es un mensaje desde el logger");
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            var modelo = new Models.HomeIndexViewModel() { Proyectos= proyectos };

            return View(modelo);
        }

        

        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }

        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(Contacto contacto)
        {
            await _servicioEmail.Enviar(contacto);

            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}