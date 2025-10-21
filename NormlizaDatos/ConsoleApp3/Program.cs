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

        // --- LINQ tipo SQL ---
        var nombresEquipos = (
            from linea in datos
            from nombre in linea.Split(';').Take(2)
            select nombre
        ).Distinct();

        var equipos = (
            from nombre in nombresEquipos
            select new Equipo
            {
                Id = nombresEquipos.ToList().IndexOf(nombre) + 1,
                Nombre = nombre
            }).ToList();

        var nombresCompeticiones = (
            from linea in datos
            select linea.Split(';')[3]
        ).Distinct();

        var competiciones = (
            from nombre in nombresCompeticiones
            select new Competicion
            {
                Id = nombresCompeticiones.ToList().IndexOf(nombre) + 1,
                Nombre = nombre
            }).ToList();

        var partidos =
            (from linea in datos.Select((value, index) => new { value, index })
             let partes = linea.value.Split(';')
             select new Partido
             {
                 Id = linea.index + 1,
                 Equipo1Id = equipos.First(e => e.Nombre == partes[0]).Id,
                 Equipo2Id = equipos.First(e => e.Nombre == partes[1]).Id,
                 CompeticionId = competiciones.First(c => c.Nombre == partes[3]).Id,
                 Resultado = partes[2],
                 Fecha = DateOnly.Parse(partes[4])
             }).ToList();

        // --- Salida ---
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
