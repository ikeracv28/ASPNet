/*
 * Aprobado o suspendido
Pide una nota y muestra “Aprobado” si es ≥ 5 o “Suspendido” si es < 5.
*/

public class Calificacion
{
    static void Main(string[] args)
    {
        int nota = PedirNota();
        if (nota <= 5)
        {
            Console.WriteLine("Suspenso");
        }else if (nota >= 5)
        {
            Console.WriteLine("Aprobado");
        }
        

    }

    static int PedirNota()
    {
        while (true)
        {
            Console.WriteLine("Dime la nota: ");
            string nota = Console.ReadLine();

            if (int.TryParse(nota, out int salida))
            {
                return salida;
            }
            else
            {
                Console.WriteLine("Introduce un numero valido");
            }
        }
    }
}