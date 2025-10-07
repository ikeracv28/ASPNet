using System;
using System.Collections.Generic;

class Ejercicio_4
{
    static void Main(string[] args)
    {
        var productos = new Dictionary<string, int>
        {
            { "Laptop", 1500 },
            { "Mouse", 25 },
            { "Teclado", 45 }
        };

        for (int i = 0; i < 3; i++)
        {
            try
            {
                Console.Write("Ingresa producto: ");
                string entrada = Console.ReadLine();

                // Separar producto y cantidad si existe
                var partes = entrada.Split(", cantidad:");
                string producto = partes[0].Trim();

                if (!productos.TryGetValue(producto, out int precio))
                {
                    Console.WriteLine("Producto no encontrado");
                    continue;
                }

                if (partes.Length < 2)
                {
                    Console.WriteLine("Cantidad no válida");
                    continue;
                }

                if (!int.TryParse(partes[1].Trim(), out int cantidad))
                {
                    Console.WriteLine("Cantidad no válida");
                    continue;
                }

                Console.WriteLine($"Total: {precio * cantidad}");
            }
            catch
            {
                Console.WriteLine("Entrada no válida");
            }
        }
    }
}