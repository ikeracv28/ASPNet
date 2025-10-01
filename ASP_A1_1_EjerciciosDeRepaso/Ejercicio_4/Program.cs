/*
 * Ejercicio_4
Mayor de dos números
Pide dos números y muestra cuál es mayor.
Si son iguales, muestra un mensaje “Los números son iguales”.
*/

public class NumeroMayor
{
    static void Main(string[] args)
    {
        int numero1 = PedirNumero();
        int numero2 = PedirNumero();
        if (numero1 > numero2)
        {
            Console.WriteLine($"El numero {numero1} es mayor que el {numero2}");
        }
        else if (numero1 < numero2)
        {
            Console.WriteLine($"El numero {numero2} es mayor que el {numero1}");
        }
        else if (numero2 == numero1)
        {
            Console.WriteLine("Los numeros son iguales");
        }
    }

        static int PedirNumero()
        {
            while (true)
            {
                Console.WriteLine("Dime un numero: ");
                string numero1 = Console.ReadLine();

                if (int.TryParse(numero1, out int salidaNumero))
                {
                    return salidaNumero;
                } else
                {
                    Console.WriteLine("Numero no valido");
                }
            }

        }
    }
