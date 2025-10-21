namespace Modelos
{
    class Partido
    {
        public int Id { get; set; }
        public int Equipo1Id { get; set; }
        public int Equipo2Id { get; set; }
        public int CompeticionId { get; set; }
        public string? Resultado { get; set; }
        public DateOnly Fecha { get; set; }
    }
}
