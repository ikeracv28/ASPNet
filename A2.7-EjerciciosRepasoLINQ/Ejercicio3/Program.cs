
public class Persona
{
    public string Nombre { get; set; } = string.Empty;
    public int Edad { get; set; }
}

public class Ejercicio3
{
    public static void Main(string[] args)
    {
        var personas = new List<Persona>

    {

        new Persona { Nombre = "Ana", Edad = 25 },

        new Persona { Nombre = "Luis", Edad = 30 },

        new Persona { Nombre = "María", Edad = 22 }

    };

        // 1. Ordena por edad de forma ascendente

        //con metodo
        var edadAscendenteMetodo = personas.OrderBy(p => p.Edad).Select(p => p.Edad);
        Console.WriteLine("Edades ordenadas de manera ascendente (metodo): " + string.Join(", ", edadAscendenteMetodo));

        //con consulta
        var edadAscendenteConsulta = from p in personas orderby p.Edad select p.Edad;
        Console.WriteLine("Edades ordenadas de manera ascendente (consulta): " + string.Join(", ", edadAscendenteConsulta));

        // 2. Ordena por nombre de forma descendente

        //con metodo
        var nombreAscendenteMetodo = personas.OrderBy(p => p.Nombre).Select(p => p.Nombre);
        Console.WriteLine("Nombres ordenados de manera ascendente (metodo): " + string.Join(", ", nombreAscendenteMetodo));

        //con consulta
        var nombreAscendenteConsulta = from p in personas orderby p.Nombre select p.Nombre;
        Console.WriteLine("Nombres ordenados de manera ascendente (consulta): " + string.Join(", ", nombreAscendenteConsulta));

        // 3. Ordena por edad descendente y luego por nombre ascendente

        //con metodo
        var edadYnombreAscendenteMetodo = personas.OrderByDescending(p => p.Edad).ThenBy(p => p.Nombre).Select(p => $"{p.Nombre} {p.Edad}");
        Console.WriteLine("Personas ordenadas (edad desc, nombbre asc) (método): " + string.Join(", ", edadYnombreAscendenteMetodo));
    }
}