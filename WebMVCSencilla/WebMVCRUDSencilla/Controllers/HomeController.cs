using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVCRUDSencilla.Models;

namespace WebMVCRUDSencilla.Controllers
{
    public class HomeController : Controller
    {
        // **Nueva Colección Estática:** Simula la Base de Datos.
        // Se inicializa una sola vez cuando la clase se carga.
        private static List<Estudiante> _listaEstudiantes = new List<Estudiante>
        {
            new Estudiante { Id = 1, Nombre = "Ana García", Curso = "C# Básico", Edad = 20 },
            new Estudiante { Id = 2, Nombre = "Luis Pérez", Curso = "ASP.NET Core", Edad = 22 },
            new Estudiante { Id = 3, Nombre = "Marta Ruiz", Curso = "MVC", Edad = 21 }
        };

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // R: Read (Leer todos)
        public IActionResult Index()
        {
            // Ahora devolvemos la lista estática
            return View(_listaEstudiantes);
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
        // C: Create (Mostrar Formulario - GET)
        // URL: /Home/Crear
        public IActionResult Crear()
        {
            // Simplemente devuelve una vista vacía para el formulario
            return View();
        }

        // C: Create (Procesar Formulario - POST)
        [HttpPost] // Indica que solo maneja solicitudes POST
        [ValidateAntiForgeryToken] // Buena práctica de seguridad
        public IActionResult Crear(Estudiante nuevoEstudiante)
        {
            if (ModelState.IsValid) // Verifica si el modelo cumple las reglas
            {
                // 1. Asignar un nuevo ID
                int nextId = _listaEstudiantes.Any() ? _listaEstudiantes.Max(e => e.Id) + 1 : 1;
                nuevoEstudiante.Id = nextId;

                // 2. Añadir a la "base de datos" (la lista estática)
                _listaEstudiantes.Add(nuevoEstudiante);

                // 3. Redirigir al listado (patrón PRG - Post/Redirect/Get)
                return RedirectToAction(nameof(Index));
            }
            // Si el modelo no es válido, vuelve a mostrar el formulario con los datos ingresados
            return View(nuevoEstudiante);
        }

        // U: Update (Mostrar Formulario de Edición - GET)
        // URL: /Home/Editar/5
        public IActionResult Editar(int id)
        {
            // 1. Buscar el estudiante por ID en la lista estática
            var estudianteAEditar = _listaEstudiantes.FirstOrDefault(e => e.Id == id);

            if (estudianteAEditar == null)
            {
                // Si no se encuentra, podrías redirigir a un error o al Index
                return NotFound(); // Retorna un código de estado 404
            }

            // 2. Devolver la vista, pasando el objeto encontrado
            return View(estudianteAEditar);
        }

        // U: Update (Procesar Formulario de Edición - POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Estudiante estudianteConCambios)
        {
            // El 'estudianteConCambios' llega con el Id y los nuevos datos del formulario.
            if (ModelState.IsValid)
            {
                // 1. Buscar el índice del estudiante original en la lista estática
                var index = _listaEstudiantes.FindIndex(e => e.Id == estudianteConCambios.Id);

                if (index != -1)
                {
                    // 2. Reemplazar el objeto existente con el objeto actualizado del formulario
                    _listaEstudiantes[index] = estudianteConCambios;

                    // 3. Redirigir al listado
                    return RedirectToAction(nameof(Index));
                }
                // Si no se encuentra, aún así devolvemos la vista con un mensaje de error o 404
                return NotFound();
            }

            // Si el modelo no es válido, vuelve a mostrar el formulario de edición
            return View(estudianteConCambios);
        }

        // D: Delete (Eliminar por ID - POST)
        // Usamos [HttpPost] y el parámetro 'id' para evitar que se elimine con una simple URL GET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(int id)
        {
            // 1. Buscar el estudiante en la lista estática
            var estudianteAEliminar = _listaEstudiantes.FirstOrDefault(e => e.Id == id);

            if (estudianteAEliminar != null)
            {
                // 2. Eliminar el estudiante
                _listaEstudiantes.Remove(estudianteAEliminar);
            }

            // 3. Redirigir al listado actualizado
            return RedirectToAction(nameof(Index));
        }



    }
}
