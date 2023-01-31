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

        public HomeController(ILogger<HomeController> logger, IRepositorioProyecto repositorio)
        {
            _logger = logger;
            repositorioProyectos = repositorio;
        }

        public IActionResult Index()
        {                 
            
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            var modelo = new Models.HomeIndexViewModel() { Proyectos= proyectos };

            return View(modelo);
        }

        

        public IActionResult Privacy()
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