using System;
using System.Collections.Generic;
using System.Linq;

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

        // Normalizar equipos
        var equipos = datos
            .SelectMany(l => l.Split(';').Take(2)) // solo los dos primeros campos (equipos)
            .Distinct()
            .Select((nombre, index) => new Equipo { Id = index + 1, Nombre = nombre })
            .ToList();

        // Normalizar competiciones
        var competiciones = datos
            .Select(l => l.Split(';')[3])
            .Distinct()
            .Select((nombre, index) => new Competicion { Id = index + 1, Nombre = nombre })
            .ToList();

        // Normalizar partidos
        var partidos = datos
            .Select((linea, index) =>
            {
                var partes = linea.Split(';');
                return new Partido
                {
                    Id = index + 1,
                    Equipo1Id = equipos.First(e => e.Nombre == partes[0]).Id,
                    Equipo2Id = equipos.First(e => e.Nombre == partes[1]).Id,
                    CompeticionId = competiciones.First(c => c.Nombre == partes[3]).Id,
                    Resultado = partes[2],
                    Fecha = DateOnly.Parse(partes[4])
                };
            }).ToList();

        // Salida
        Console.WriteLine("Equipos:");
        equipos.ForEach(e => Console.WriteLine($"{e.Id}: {e.Nombre}"));

        Console.WriteLine("\nCompeticiones:");
        competiciones.ForEach(c => Console.WriteLine($"{c.Id}: {c.Nombre}"));

        Console.WriteLine("\nPartidos:");
        partidos.ForEach(p =>
            Console.WriteLine($"{p.Id}: Equipo1={p.Equipo1Id}, Equipo2={p.Equipo2Id}, Competicion={p.CompeticionId}, Resultado={p.Resultado}, Fecha={p.Fecha}")
        );
    }
}
