/*
 * Objetivo: Usar try/catch y TryParse.
Descripción: pedir un número, convertirlo a entero de forma segura usando TryParse y manejar números negativos con try/catch.
Entrada de usuario:
Ingresa un número: abc
Ingresa un número: -5
Ingresa un número: 10
Salida de consola:
Valor no válido
Error: El número no puede ser negativo
Número aceptado: 10
*/

class Ejercicio_1
{
    static void Main(string[] args)
    {

        Conversion();
    }

    static int Conversion()
    {
        while (true)
        {
            Console.WriteLine("Dime un numero: ");
            string numero = Console.ReadLine();
            if(int.TryParse(numero, out int salida) &&  salida >= 0)
            {
                Console.WriteLine("Numero aceptado: " + salida);
                return salida;
               
            }
            else
            {
                Console.WriteLine("Numero no valido");
            }
        }
    }
}