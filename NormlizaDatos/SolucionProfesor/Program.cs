static internal class Program
{
    static void Main()
    {
        Console.WriteLine("=== Sin LINQ ===");
        SinLINQ();
        Console.WriteLine();

        Console.WriteLine("=== LINQ con sintaxis de método ===");
        LINQSintaxisMetodo();
        Console.WriteLine();

        Console.WriteLine("=== LINQ con sintaxis tipo SQL ===");
        LINQSintaxisSQL();
    }

    static void SinLINQ()
    {
        // Diccionarios para asignar IDs únicos
        Dictionary<string, Equipo> equiposDict = new Dictionary<string, Equipo>();
        Dictionary<string, Competicion> competicionesDict = new Dictionary<string, Competicion>();

        List<Partido> partidos = new List<Partido>();
        int equipoId = 1;
        int competicionId = 1;
        int partidoId = 1;

        foreach (var linea in datos)
        {
            string[] partes = linea.Split(';');
            string nombreEquipo1 = partes[0];
            string nombreEquipo2 = partes[1];
            string resultado = partes[2];
            string nombreCompeticion = partes[3];
            DateOnly fecha = DateOnly.Parse(partes[4]);

            // Registrar equipos si no existen
            if (!equiposDict.ContainsKey(nombreEquipo1))
            {
                equiposDict[nombreEquipo1] = new Equipo { Id = equipoId++, Nombre = nombreEquipo1 };
            }
            if (!equiposDict.ContainsKey(nombreEquipo2))
            {
                equiposDict[nombreEquipo2] = new Equipo { Id = equipoId++, Nombre = nombreEquipo2 };
            }

            // Registrar competición si no existe
            if (!competicionesDict.ContainsKey(nombreCompeticion))
            {
                competicionesDict[nombreCompeticion] = new Competicion { Id = competicionId++, Nombre = nombreCompeticion };
            }

            // Crear el partido
            partidos.Add(new Partido
            {
                Id = partidoId++,
                Equipo1Id = equiposDict[nombreEquipo1].Id,
                Equipo2Id = equiposDict[nombreEquipo2].Id,
                CompeticionId = competicionesDict[nombreCompeticion].Id,
                Resultado = resultado,
                Fecha = fecha
            });
        }

        // Mostrar resultados
        Console.WriteLine("Equipos:");
        foreach (var e in equiposDict.Values)
        {
            Console.WriteLine($"{e.Id}: {e.Nombre}");
        }
        Console.WriteLine();

        Console.WriteLine("Competiciones:");
        foreach (var c in competicionesDict.Values)
        {
            Console.WriteLine($"{c.Id}: {c.Nombre}");
        }
        Console.WriteLine();

        Console.WriteLine("Partidos:");
        foreach (var p in partidos)
        {
            Console.WriteLine($"{p.Id}: Equipo1={p.Equipo1Id}, Equipo2={p.Equipo2Id}, Competicion={p.CompeticionId}, Resultado={p.Resultado}, Fecha={p.Fecha}");
        }
    }

    static void LINQSintaxisMetodo()
    {
        // Equipos
        var locales = datos.Select(d => d.Split(';')[0]);
        var visitantes = datos.Select(d => d.Split(';')[1]);
        var todosLosEquipos = locales.Concat(visitantes).Distinct();

        var equipos = todosLosEquipos
            .Select((nombre, index) => new Equipo { Id = index + 1, Nombre = nombre })
            .ToList();

        // Competiciones
        var competiciones = datos
            .Select(d => d.Split(';')[3])
            //quita repetidos
            .Distinct()
            .Select((nombre, index) => new Competicion { Id = index + 1, Nombre = nombre })
            .ToList();

        // Partidos
        var partidos = datos
            .Select((d, index) => {
                var partes = d.Split(';');
                return new Partido
                {
                    Id = index + 1,
                    Equipo1Id = equipos.First(e => e.Nombre == partes[0]).Id,
                    Equipo2Id = equipos.First(e => e.Nombre == partes[1]).Id,
                    CompeticionId = competiciones.First(c => c.Nombre == partes[3]).Id,
                    Resultado = partes[2],
                    Fecha = DateOnly.Parse(partes[4])
                };
            })
            .ToList();

        // Mostrar resultados
        Console.WriteLine("Equipos:");
        equipos.ForEach(e => Console.WriteLine($"{e.Id}: {e.Nombre}"));

        Console.WriteLine("\nCompeticiones:");
        competiciones.ForEach(c => Console.WriteLine($"{c.Id}: {c.Nombre}"));

        Console.WriteLine("\nPartidos:");
        partidos.ForEach(p => Console.WriteLine($"{p.Id}: Equipo1={p.Equipo1Id}, Equipo2={p.Equipo2Id}, Competicion={p.CompeticionId}, Resultado={p.Resultado}, Fecha={p.Fecha}"));
    }

    static void LINQSintaxisSQL()
    {
        // Equipos con ID único
        var equiposQuery = (
            from nombre in datos.SelectMany(d => new[] { d.Split(';')[0], d.Split(';')[1] }).Distinct()
            select nombre
        ).Select((nombre, index) => new Equipo { Id = index + 1, Nombre = nombre });

        var equipos = equiposQuery.ToList();

        // Competiciones con ID único
        var competicionesQuery = (
            from nombre in datos.Select(d => d.Split(';')[3]).Distinct()
            select nombre
        ).Select((nombre, index) => new Competicion { Id = index + 1, Nombre = nombre });

        var competiciones = competicionesQuery.ToList();

        // Partidos
        var partidosQuery =
            from d in datos.Select((value, index) => new { value, index }) // Añadimos índice para Id
            let partes = d.value.Split(';')                                // Separar campos de la línea
            join e1 in equipos on partes[0] equals e1.Nombre               // Join con equipo local
            join e2 in equipos on partes[1] equals e2.Nombre               // Join con equipo visitante
            join c in competiciones on partes[3] equals c.Nombre           // Join con competición
            select new Partido
            {
                Id = d.index + 1,                 // Id incremental
                Equipo1Id = e1.Id,                // Id del equipo local
                Equipo2Id = e2.Id,                // Id del equipo visitante
                CompeticionId = c.Id,             // Id de la competición
                Resultado = partes[2],            // Resultado del partido
                Fecha = DateOnly.Parse(partes[4]) // Fecha del partido
            };

        /* Código alternativo para calcular partidos 
        var partidosQuery = (
            from d in datos.Select((value, index) => new { value, index })
            let partes = d.value.Split(';')
            let e1 = (from e in equipos where e.Nombre == partes[0] select e).First()
            let e2 = (from e in equipos where e.Nombre == partes[1] select e).First()
            let c = (from comp in competiciones where comp.Nombre == partes[3] select comp).First()
            select new Partido {
                Id = d.index + 1,
                Equipo1Id = e1.Id,
                Equipo2Id = e2.Id,
                CompeticionId = c.Id,
                Resultado = partes[2],
                Fecha = DateOnly.Parse(partes[4])
            }
        );
        */
        var partidos = partidosQuery.ToList();

        // Mostrar resultados
        Console.WriteLine("Equipos:");
        foreach (var e in equipos) Console.WriteLine($"{e.Id}: {e.Nombre}");

        Console.WriteLine("\nCompeticiones:");
        foreach (var c in competiciones) Console.WriteLine($"{c.Id}: {c.Nombre}");

        Console.WriteLine("\nPartidos:");
        foreach (var p in partidos)
            Console.WriteLine($"{p.Id}: Equipo1={p.Equipo1Id}, Equipo2={p.Equipo2Id}, Competicion={p.CompeticionId}, Resultado={p.Resultado}, Fecha={p.Fecha}");
    }

    static List<string> datos = new List<string> {
        "Real Madrid;Barcelona;2-1;Liga;2025-10-12",
        "Atlético de Madrid;Sevilla;1-0;Liga;2025-10-13",
        "Barcelona;Valencia;3-2;Copa del Rey;2025-10-14",
        "Sevilla;Real Madrid;0-2;Liga;2025-10-15",
        "Valencia;Atlético de Madrid;1-1;Copa del Rey;2025-10-16",
        "Real Madrid;Atlético de Madrid;2-2;Liga;2025-10-17",
        "Barcelona;Sevilla;4-0;Liga;2025-10-18",
        "Valencia;Real Madrid;0-1;Copa del Rey;2025-10-19",
        "Atlético de Madrid;Barcelona;1-3;Liga;2025-10-20",
        "Sevilla;Valencia;2-2;Copa del Rey;2025-10-21"
    };
}

class Equipo
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
}

class Competicion
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
}

class Partido
{
    public int Id { get; set; }
    public int Equipo1Id { get; set; }
    public int Equipo2Id { get; set; }
    public int CompeticionId { get; set; }
    public string? Resultado { get; set; }
    public DateOnly Fecha { get; set; }
}

