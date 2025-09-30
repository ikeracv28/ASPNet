using System;

class Program
{
    // Array donde vamos a guardar los numeros
    static double[] numeros;

    static void Main()
    {
        Console.WriteLine("=== Analizador de Números=== \n");

        //Aqui iremos añadiendo el flujo del programa paso a paso
        // 1) Pedir cuantos números
        // 2) Leer los numeros (for)
        // 3) Resumen: suma, media, mínimo, máximo
        // 4) Menu interactivo (While) con opciones y foreach/for
        MuestraMenu();
        int eleccion = (int)LeeNumero();

        // Switch para usar el menu
        switch (eleccion)
        {
            case 1:
                LeerTodosLosNumeros();
                break;
            case 6:
                return;
        }

        // --- A partir de aqui iremos agregando metodos de apoyo ---

        static void MuestraMenu()
        {
            Console.WriteLine("(1) Leer números");
            Console.WriteLine("(2) Calcular suma");
            Console.WriteLine("(3) Calcular media");
            Console.WriteLine("(4) Calcular mínimo");
            Console.WriteLine("(5) Calcular máximo");
            Console.WriteLine("(6) Salir");

            //Console.WriteLine("Elige una opción del menu: ");
            //int eleccion = int.Parse(Console.ReadLine());
        }

        // Opcion 1: Leer Numeros
        //Esta funcion es para que el usuario me diga los numeros con lo que vamos a jugar y hacer las cuentas del menu.
        static void LeerTodosLosNumeros()
        {
            Console.WriteLine("¿Cuántos números?");
            int cuenta = (int)LeeNumero();

            // Dimension del array
            numeros = new double[cuenta];

            for (int i = 0; i < numeros.Length; i++)
            {
                numeros[i] = LeeNumero();
            }
        }

        //Metodo auxiliar para leer double desde consola
        //Con control de errores
        static double LeeNumero()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Introduce un número: ");
                    double num = double.Parse(Console.ReadLine());
                    return num;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Introduce un número valido");
                }
            }
        }
    }
}
