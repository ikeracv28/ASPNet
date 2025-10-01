/*
 * Ejercicio_6
Número par o impar
Pide un número y muestra si es par o impar usando el operador módulo %.
*/

public class ParImpar
{
    static void Main(string[] args)
    {
        int numero = PedirNumero();
        if (numero % 2 == 0)
        {
            Console.WriteLine($"El numero {numero} es par");
        }
        else if (numero % 2 != 0)
        {
            Console.WriteLine($"El numero {numero} es impar");
        }
    }
            static int PedirNumero()
            {
                while (true)
                {
                    Console.WriteLine("Introduce un número: ");
                    string numero = Console.ReadLine();

                    if (int.TryParse(numero, out int salida))
                    {
                        return salida;
                    }
                    else
                    {
                        Console.WriteLine("Introduce un número valido");
                    }
                }
            }
}