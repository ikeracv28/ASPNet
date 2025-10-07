using System;
using System.Collections.Generic;



// Reutiliza la clase Producto del ejercicio 8 (no la declares aquí)

using Ejercicio_8;
using Ejercicio_8.Ejercicio_8;
using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Ejercicio_11
{
    public static void Main(string[] args)
    {
        var prod1 = new ProductoDetallado("Laptop", "Electrónica", 1500);
        prod1["peso"] = "2 Kg";
        prod1["color"] = "Negro";
        prod1.Precio = -500; // No será negativo

        var prod2 = new ProductoDetallado("Mesa", "Mueble", 200);
        prod2["material"] = "Madera";
        prod2["peso"] = "20 Kg";

        var prod3 = new ProductoDetallado("Libro", "Educativo", 30);
        prod3["autor"] = "J.K. Rowling";
        prod3["idioma"] = "Español";
        prod3.Precio = 25;

        prod1.Datos();
        prod2.Datos();
        prod3.Datos();
    }
}

public class ProductoDetallado : Producto
{
    private Dictionary<string, string> caracteristicas = new();

    public ProductoDetallado(string nombre, string descripcion, double precio)
        : base(nombre, descripcion, precio)
    { }

    public ProductoDetallado() : base() { }

    // Indexador para acceder a características
    public string this[string key]
    {
        get => caracteristicas.ContainsKey(key) ? caracteristicas[key] : null;
        set => caracteristicas[key] = value;
    }

    // Método para mostrar información detallada
    public override void Datos()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Descripción: {Descripcion}");
        Console.WriteLine($"Precio: {Precio:C}");
        Console.WriteLine("Características:");
        foreach (var kvp in caracteristicas)
        {
            Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
        }
        Console.WriteLine("-------------------------");
    }
}