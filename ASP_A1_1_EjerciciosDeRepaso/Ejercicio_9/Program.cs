/*
 * Compra
En Main(), pide al usuario 3 productos con sus precios.
Calcula el total de la compra.
Bonus: hazlo sin duplicar la clase Producto, es decir, reutilizando el código de esta clase que has desarrollado para el ejercicio 8.
*/


class Programa
{
    static void Main(string[] args)
    {
        Console.WriteLine("Nombre: ");
        string nombre = Console.ReadLine();

        Console.WriteLine("Precio: ");
        double precio = double.Parse(Console.ReadLine());

        Console.WriteLine("Descripcion: ");
        string descripcion = Console.ReadLine();

        Producto p1 = new Producto("Play 5", 400, "Rapida");
        p1.Datos();

        Console.WriteLine($"{p1.Nombre}");
    }
}