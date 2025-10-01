/*Clase Producto básica
Crea una clase Producto con atributos: Nombre, descripción, precio.
Constructor que inicialice estos valores.
Método Datos() que muestre la información del producto.
Crea 2-3 objetos en Main() y llama al método Datos() de cada uno.
*/
class Programa
{
    static void Main(string[] args)
       {
        Producto producto1 = new Producto("raton", 12.5, "inalambrico");
        Producto producto2 = new Producto("teclado", 25.5, "mecanico");
        Producto producto3 = new Producto("pantalla", 150.9, "Curva");

        producto1.Datos();
        producto2.Datos();
        producto3.Datos();

        producto2.Precio = -123;
        producto2.Datos();

        //raton (esto se llama propiedad indexada)
        producto1["conector"] = "USB-C";
        Console.WriteLine($"Conector; {producto1["conector"]}");
        

        //teclado
        producto2["teclas"] = "102";
        producto1.Datos();
    }
}
