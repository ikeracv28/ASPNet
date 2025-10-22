class Programa
{
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

    public static void Main()
    {
        var l1 = datos.Select(d => d.Split(";").Take(2));
        var l2 = datos.SelectMany(d => d.Split(";")[0].Take(2));

    }
}