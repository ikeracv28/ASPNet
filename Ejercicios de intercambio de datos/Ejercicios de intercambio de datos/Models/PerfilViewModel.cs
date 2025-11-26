namespace Ejercicios_de_intercambio_de_datos.Models
{
    public class PerfilViewModel
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public bool EsAdmin { get; set; }

        public PerfilViewModel(string nombre, string email, bool esAdmin)
        {
            this.Nombre = nombre;
            this.Email = email;
            this.EsAdmin = esAdmin;
        }

    }
}
