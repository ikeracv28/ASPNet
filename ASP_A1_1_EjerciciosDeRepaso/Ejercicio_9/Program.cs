/*
 * Compra
En Main(), pide al usuario 3 productos con sus precios.
Calcula el total de la compra.
Bonus: hazlo sin duplicar la clase Producto, es decir, reutilizando el código de esta clase que has desarrollado para el ejercicio 8.
*/

/*
class Programa
{
    static void Main(string[] args)
    {
        Console.WriteLine("Dime 3 productos: ");


        Console.WriteLine("Nombre: ");
        string nombre = Console.ReadLine();

        Console.WriteLine("Precio: ");
        double precio = double.Parse(Console.ReadLine());

        Console.WriteLine("Descripcion: ");
        string descripcion = Console.ReadLine();

        Producto p1 = new Producto(nombre, precio, descripcion);
        Producto p2 = new Producto(nombre, precio, descripcion);
        Producto p3 = new Producto(nombre, precio, descripcion);
        



        Console.WriteLine($"{p1.Nombre}");
    }
}
*/



  class Programa
{
    static void Main(string[] args)
    {
        Producto[] productos = new Producto[3];
        double total = 0;

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Producto {i + 1}:");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            double precio;
            while (true)
            {
                Console.Write("Precio: ");
                if (double.TryParse(Console.ReadLine(), out precio) && precio >= 0)
                    break;
                Console.WriteLine("Introduce un precio válido (número positivo).");
            }

            Console.Write("Descripcion: ");
            string descripcion = Console.ReadLine();

            productos[i] = new Producto(nombre, precio, descripcion);
            total += productos[i].Precio;
        }

        Console.WriteLine("\nResumen de la compra:");
        foreach (var p in productos)
        {
            p.Datos();
        }
        Console.WriteLine($"\nTotal de la compra: {total} euros");
    }
}
