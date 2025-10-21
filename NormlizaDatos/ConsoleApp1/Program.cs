using System;
using System.Collections.Generic;

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

class Program
{
    static void Main()
    {
        List<string> datos = new List<string> {
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

        List<Equipo> equipos = new List<Equipo>();
        List<Competicion> competiciones = new List<Competicion>();
        List<Partido> partidos = new List<Partido>();

        int idEquipo = 1, idCompeticion = 1, idPartido = 1;

        foreach (var linea in datos)
        {
            var partes = linea.Split(';');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string resultado = partes[2];
            string competicion = partes[3];
            DateOnly fecha = DateOnly.Parse(partes[4]);

            // EQUIPOS
            if (!equipos.Exists(e => e.Nombre == nombre1))
                equipos.Add(new Equipo { Id = idEquipo++, Nombre = nombre1 });

            if (!equipos.Exists(e => e.Nombre == nombre2))
                equipos.Add(new Equipo { Id = idEquipo++, Nombre = nombre2 });

            // COMPETICIONES
            if (!competiciones.Exists(c => c.Nombre == competicion))
                competiciones.Add(new Competicion { Id = idCompeticion++, Nombre = competicion });

            // PARTIDO
            int idEq1 = equipos.Find(e => e.Nombre == nombre1)!.Id;
            int idEq2 = equipos.Find(e => e.Nombre == nombre2)!.Id;
            int idComp = competiciones.Find(c => c.Nombre == competicion)!.Id;

            partidos.Add(new Partido
            {
                Id = idPartido++,
                Equipo1Id = idEq1,
                Equipo2Id = idEq2,
                CompeticionId = idComp,
                Resultado = resultado,
                Fecha = fecha
            });
        }

        // SALIDA
        Console.WriteLine("Equipos:");
        foreach (var e in equipos)
            Console.WriteLine($"{e.Id}: {e.Nombre}");

        Console.WriteLine("\nCompeticiones:");
        foreach (var c in competiciones)
            Console.WriteLine($"{c.Id}: {c.Nombre}");

        Console.WriteLine("\nPartidos:");
        foreach (var p in partidos)
            Console.WriteLine($"{p.Id}: Equipo1={p.Equipo1Id}, Equipo2={p.Equipo2Id}, Competicion={p.CompeticionId}, Resultado={p.Resultado}, Fecha={p.Fecha}");
    }
}
