
// Ejericico 1 
// Suma de dos números
//Crea un programa que pida dos números por consola y muestre su suma.
//Bonus: muestra también la resta, multiplicación y división

using System.Net.NetworkInformation;

public class Calculadora
{
    static void Main(string[] args)
    {

        while (true)
        {
            Menu();
            Console.WriteLine("Elije una opcion del menu: \n");
            int eleccion = int.Parse(Console.ReadLine());
            switch (eleccion)
            {
                case 1:
                    Suma();
                    break;
                case 2:
                    Resta();
                    break;
                case 3:
                    Multiplicacion();
                    break;
                case 4:
                    Division();
                    break;
                case 5:
                    return;
            }
        }

        static void Menu()
        {
            Console.WriteLine("======== Menu ========");
            Console.WriteLine("1. Suma");
            Console.WriteLine("2. Resta");
            Console.WriteLine("3. Multiplicacion");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Salir\n");

        }

        static void Suma()
        {
            try
            {
                Console.WriteLine("Dime el primer número: ");
                double a = int.Parse(Console.ReadLine());

                Console.WriteLine("Dime el segundo número: ");
                double b = int.Parse(Console.ReadLine());

                double resultado = a + b;
                Console.WriteLine("El resultado de la suma es: " + resultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Introduce un numero valido");

            }
        }

        static void Resta()
        {
            try
            {
                Console.WriteLine("Dime el primer número: ");
                double a = int.Parse(Console.ReadLine());

                Console.WriteLine("Dime el segundo número: ");
                double b = int.Parse(Console.ReadLine());

                double resultado = a - b;
                Console.WriteLine("El resultado de la resta es: " + resultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Introduce un numero valido");

            }
        }

        static void Multiplicacion()
        {
            try
            {
                Console.WriteLine("Dime el primer número: ");
                double a = int.Parse(Console.ReadLine());

                Console.WriteLine("Dime el segundo número: ");
                double b = int.Parse(Console.ReadLine());

                double resultado = a * b;
                Console.WriteLine("El resultado de la multiplicacion es: " + resultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Introduce un numero valido");

            }
        }

        static void Division()
        {
            try
            {
                Console.WriteLine("Dime el primer número: ");
                double a = int.Parse(Console.ReadLine());

                Console.WriteLine("Dime el segundo número: ");
                double b = int.Parse(Console.ReadLine());

                double resultado = a / b;
                Console.WriteLine("El resultado de la division es: " + resultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Introduce un numero valido");

            }
        }
    }
}


