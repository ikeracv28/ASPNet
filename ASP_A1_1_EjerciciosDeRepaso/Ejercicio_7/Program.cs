/*
 * Pide al usuario el nombre de un corredor.


Pide al usuario los tiempos de tres carreras en segundos.


Crea un método llamado CalcularPromedio que reciba esos tres tiempos y devuelva el tiempo medio.


Muestra un mensaje en pantalla con el siguiente formato:
Hola, [nombre], tu tiempo medio es: [promedio] segundos
*/


public class Media
{
    static void Main(string[] args)
    {
        Console.WriteLine("Dime tu nombre: ");
        string nombre = Console.ReadLine();

        double tiempo1 = Filtro();
        double tiempo2 = Filtro();
        double tiempo3 = Filtro();

        double media = CalcularPromedio(tiempo1, tiempo2, tiempo3);
        Console.WriteLine($"Hola, {nombre}, tu tiempo medio es: {media} segundos ");

    }


    static double Filtro()
    {
        while (true) {
            Console.WriteLine("Dime el tiempo de tu carrera: ");
            string tiempo = Console.ReadLine();
            if (double.TryParse(tiempo, out double salida)){
                return salida;
            } else
            {
                Console.WriteLine("Introduce un número valido");
            }
        }
    }
    static double CalcularPromedio(double tiempo1, double tiempo2, double tiempo3)
    {
        return  (tiempo1 + tiempo2 + tiempo3) / 3; 
    }
}