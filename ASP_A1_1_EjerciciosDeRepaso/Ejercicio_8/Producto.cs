/*
class Producto
{
    //private string _nombre = "";
    private double _precio = 0;
    //private string _descripcion = "";

    private Dictionary<string, string> _caracteristicas= new Dictionary<string, string>();

    // propiedad indexada, para meterle caracteristicas propias de cada producto
    public string this [string key]
    {
        get {return _caracteristicas[key];}
        set { _caracteristicas[key] = value;}
    }

    public string Nombre { set; get; }
    public double Precio
    {
        set
        {
            if (value < 0) _precio = 0;
            else _precio = value;
        }
        get { return _precio; }
    }
    public string Descripcion { set; get; }

    public Producto(string nombre, double precio, string descripcion)
    {
        //this._nombre = nombre;
        //this._precio = precio;
        //this._descripcion = descripcion;
        Nombre = nombre;
        Precio = precio;
        Descripcion = descripcion;
        
    }



    public void Datos()
    {
        Console.WriteLine($"{Nombre}  {Precio} {Descripcion}");

        // escribo las caracteristicas que tiene cada uno
        Console.WriteLine("Caracteristicas: ");
        foreach (string c in _caracteristicas.Keys)
        {
            Console.WriteLine($"\t {c} : {this[c]}");
        }
    }
}
*/
using Ejercicio_8;
using System;

namespace Ejercicio_8
{
    namespace Ejercicio_8
    {
        public class Producto
        {
            // Propiedades públicas para acceso Get/Set
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            private double precio;

            // Constructor sin parámetros para compatibilidad
            public Producto() { }

            // Constructor con parámetros para inicialización completa
            public Producto(string nombre, string descripcion, double precio)
            {
                Nombre = nombre;
                Descripcion = descripcion;
                Precio = precio;
            }

            // Propiedad con validación para precio
            public double Precio
            {
                get => precio;
                set => precio = value < 0 ? 0 : value;
            }

            public virtual void Datos()
            {
                Console.WriteLine($"El producto: {Nombre} tiene la descripción: {Descripcion} y un precio de : {Precio:C}");
            }
        }
    }
}