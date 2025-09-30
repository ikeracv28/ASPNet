public class Programa
{
    public static void Main(string[] args)
    {
        //Console.WriteLine("Hello World");

        //Console.Write("Introduce la nota: ");
        //string nota = Console.ReadLine();
        //int nota1 = int.Parse(nota);

        //if (nota1 < 11)
        //{
        //    if (nota1 >= 9)
        //    {
        //        Console.WriteLine("Sobresaliente");
        //    }
        //    else if (nota1 >= 7)
        //    {
        //        Console.WriteLine("Notable");
        //    }
        //    else if (nota1 >= 5)
        //    {
        //        Console.WriteLine("Aprobado");
        //    }
        //    else if (nota1 >= 4)
        //    {
        //        Console.WriteLine("Suspenso");
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("Nota no valida");
        //}

        //switch (nota1)
        //{
        //    case 0:
        //    case 1:
        //    case 2:
        //    case 3:
        //    case 4:
        //        Console.WriteLine("Suspenso");
        //        break;
        //    case 5:
        //    case 6:
        //        Console.WriteLine("Aprobado");
        //        break;
        //    case 7:
        //    case 8:
        //        Console.WriteLine("Notable");
        //        break;
        //    case 9:
        //    case 10:
        //        Console.WriteLine("Sobresaliente");
        //        break;
        //    default:
        //        Console.WriteLine("NPI");
        //        break;
        //        /*default
        //         * con break
        //         * al final
        //         */
        //}


        // for (int i = 0; i < 10; i +=2) esto mostraria los pares
        // for (int i = 1; i < 10; i +=2) esto mostraria los impares
        for (int i = 1; i < 10; i ++)
        {
            //if (i == 5) continue;  // el continuea salta el 5 pero sigue con el bucle
            // Si ponemos un break, saldra del bucle al llegar a 5

            Console.WriteLine($"i = {i}");
        }

        // Array 
        string[] ciudades = { "Madrid", "Barcelona", "Bilbao" };

        // Manera de mostrar el primer dato del array.
        Console.WriteLine($"La primera ciudad es: {ciudades[0]}");

        // Y este es por si no quieres leer todas las ciudades, ya que puedes elegir desde donde empezar a leer.
        for (int i = 0; i < ciudades.Length; i++)
        {
            string ciudad = ciudades[i];
            Console.WriteLine($"Ciudad: {ciudad}");
        }

        // Es mas correcto si quieres recorrer todas las ciudades, es el que se suele usar para arrays.
        foreach (string ciudad in ciudades)
        {
            Console.WriteLine($"Ciudad: {ciudad}");
        }


        // Bucle para que siga pidiendo numeros hasta que uno sea negativo
        //Aqui pedimos el numero
        Console.WriteLine("Introduce un número (negativo para terminar): ");

        //Lo pasamos a int
        int n = int.Parse(Console.ReadLine());

        //Hacemos bucle while para que siga pidiendo a no ser que sea negativo
        while(n >= 0)
        {
            Console.WriteLine($"Has introducido {n}");
            Console.WriteLine("Introduce un número (negativo para terminar): ");
            n = int.Parse(Console.ReadLine());
        }

        // Este es un do while, hace lo mismo la diferencia que siempre lo ejecuta una vez, a diferencia del while
        //int n1 = 0;
        //do
        //{
        //    Console.WriteLine($"Has introducido {n1}");
        //    Console.WriteLine("Introduce un número (negativo para terminar): ");
        //    n1 = int.Parse(Console.ReadLine());
        //}while (n1 >= 0);

    }
}
