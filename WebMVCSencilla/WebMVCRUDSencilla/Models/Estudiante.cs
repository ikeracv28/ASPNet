namespace WebMVCRUDSencilla.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty; // Inicialización para evitar nulls
        public string Curso { get; set; } = string.Empty;
        public int Edad { get; set; }
    }
}
