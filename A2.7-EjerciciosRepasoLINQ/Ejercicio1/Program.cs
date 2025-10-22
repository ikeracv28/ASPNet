public class Ejercicio1
{
    // Ejercicio 1: Filtrado Simple
    // Dada la siguiente lista
    // 1. Usando sintaxis de consulta, filtra los números mayores a 5


    // 2. Usando sintaxis de método, filtra los números pares

    // 3. Filtra los números que sean múltiplos de 3


    public static void Main(string[] args)
    {

     var numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


  

        // 1️⃣ USANDO SINTAXIS DE CONSULTA: filtra los números mayores a 5
        var mayoresA5 =
            from n in numeros     // recorremos cada número de la lista
            where n > 5           // condición: mayor que 5
            select n;             // seleccionamos ese número

        Console.WriteLine("Números mayores a 5 (consulta): " + string.Join(", ", mayoresA5));

        // y ahora sintaxis metodo
        var mayoresA5metodo = numeros.Where(n => n > 5);
        Console.WriteLine("numeros mayores a 5 (metodo):  " + string.Join(", ", mayoresA5metodo));

        //-----------------------------------------------------------------------------------------------------------------------------

        // 2️ USANDO SINTAXIS DE MÉTODO: filtra los números pares
        var pares = numeros.Where(n => n % 2 == 0);  // solo los que al dividir entre 2 dan resto 0

        Console.WriteLine("Números pares (método): " + string.Join(", ", pares));

        //usando consulta
        var paresConsulta = from n in numeros where n % 2 == 0 select n;

        Console.WriteLine("Números pares (consulta): " + string.Join(", ", pares));

        //-----------------------------------------------------------------------------------------------------------------

        // 3️⃣ Filtra los números que sean múltiplos de 3
        // Puedes hacerlo con cualquiera de las dos sintaxis, aquí las dos:
        var multiplos3_consulta =
            from n in numeros
            where n % 3 == 0
            select n;

        // con metodo
        var multiplos3_Method = numeros.Where(n => n % 3 == 0);

        Console.WriteLine("Múltiplos de 3 (consulta): " + string.Join(", ", multiplos3_consulta));
        Console.WriteLine("Múltiplos de 3 (método): " + string.Join(", ", multiplos3_Method));
    }
}






