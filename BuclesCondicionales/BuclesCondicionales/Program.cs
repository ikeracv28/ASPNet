
public class Programa
{
    public static void Main(string[] args)
    {
         
        Console.WriteLine("Hello World!");

        Console.Write("Introduce la nota: ");
        string nota = Console.ReadLine();
        int nota1 = int.Parse(nota);
        
        if (nota1 >= 5)
        {
            Console.WriteLine("Estas aprobado");
        }
        else
        {
            Console.WriteLine("No has aprobado");
        }
    
    }
}
