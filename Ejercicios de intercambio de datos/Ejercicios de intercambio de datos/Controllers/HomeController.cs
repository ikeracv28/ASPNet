using System.Diagnostics;
using Ejercicios_de_intercambio_de_datos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicios_de_intercambio_de_datos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult Articulo(int id)
        {
         
            ViewBag.TituloPagina = "Mi perfil de usuario";
            ViewData["FechaActual"] = DateTime.Now.ToShortDateString();


            return View();
        }
    }
}
