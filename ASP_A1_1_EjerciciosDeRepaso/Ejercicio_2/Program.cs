/*
  Saludo personalizado
  Pide al usuario su nombre y muestra un mensaje: “Hola, [nombre], bienvenido al programa”.
*/

public class Saludo
{
    static void Main(string[] args)
    {
        Console.WriteLine("Dime tu nombre: ");
        string nombre = Console.ReadLine();

        Console.WriteLine($" Hola, {nombre}, bienvenido al programa");
    }
}