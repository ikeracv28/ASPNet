using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMVCSencilla.Models;

namespace WebMVCSencilla.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // La acción Index() manejará la solicitud HTTP GET a la página de inicio.
        public IActionResult Index()
        {
            // 1. Crear y poblar la colección
            List<Estudiante> listaEstudiantes = new List<Estudiante>
            {
                new Estudiante { Id = 1, Nombre = "Ana García", Curso = "C# Básico", Edad = 20 },
                new Estudiante { Id = 2, Nombre = "Luis Pérez", Curso = "ASP.NET Core", Edad = 22 },
                new Estudiante { Id = 3, Nombre = "Marta Ruiz", Curso = "MVC", Edad = 21 }
            };

            // 2. Pasar la colección a la Vista (`Index.cshtml`)
            // En MVC, el objeto se pasa como argumento del método View().
            return View(listaEstudiantes);
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
