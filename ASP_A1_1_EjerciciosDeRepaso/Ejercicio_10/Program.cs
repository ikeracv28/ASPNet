using System;
using System.Collections.Generic;

class Programa
{
    static void Main(string[] args)
    {
        List<Producto> productos = new List<Producto>();
        double total = 0;

        Console.Write("¿Cuántos productos quieres añadir? ");
        int cantidad;
        while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
        {
            Console.Write("Introduce un número entero positivo: ");
        }

        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine($"\nProducto {i + 1}:");

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

            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine();

            productos.Add(new Producto(nombre, precio, descripcion));
        }

        Console.WriteLine("\nLista de productos:");
        foreach (var p in productos)
        {
            p.Datos();
            total += p.Precio;
        }

        Console.WriteLine($"\nPrecio total sin descuento: {total} euros");

        double descuento = total * 0.15;
        double totalConDescuento = total - descuento;

        Console.WriteLine($"Descuento aplicado: 15% ({descuento} euros)");
        Console.WriteLine($"Precio total con descuento: {totalConDescuento} euros");
    }
}