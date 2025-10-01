/*
 * Edad en meses
Pide la edad del usuario y calcula cuántos meses ha vivido.
Muestra el resultado en consola.
*/

public class CalcularEdad
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Dime tu edad: ");
            int edad = int.Parse(Console.ReadLine());

            int edadMeses = edad * 12;
            Console.WriteLine($"Tu edad en meses es {edadMeses}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Introduce un número valido");
        }
    }
}

/*
 * public class CalcularEdad
{
    static void Main(string[] args)
    {
        int edad;
        while (true)
        {
            Console.WriteLine("Dime tu edad: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out edad) && edad >= 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Introduce un número válido y que no sea negativo");
            }
        }

        int edadMeses = edad * 12;
        Console.WriteLine($"Tu edad en meses es {edadMeses}");
    }
}
*/