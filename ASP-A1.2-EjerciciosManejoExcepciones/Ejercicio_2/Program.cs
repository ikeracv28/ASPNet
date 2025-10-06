/*
 * Objetivo: Usar Dictionary.TryGetValue.
Descripción: crear un diccionario con nombres de alumnos y edades, y buscar un nombre de forma segura usando TryGetValue.
Diccionario:
Ana → 25
Luis → 30
Entrada de usuario:
Ingresa nombre del alumno: Ana
Ingresa nombre del alumno: Pedro


Salida de consola:
Edad: 25
Alumno no encontrado
*/

class Ejercicio_2
{
    static void Main(string[] args)
    {
        var dic = new Dictionary<string, int>
        {
            { "iker", 22 },
            { "rafa", 25 }
        };

        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine("Ingresa el nombre del alumno: ");
            string nombre = Console.ReadLine();

            if (dic.TryGetValue(nombre, out int edad))
                Console.WriteLine($"Edad: {edad}");
            else
                Console.WriteLine("Alumno no encontrado");
        }
    }
}