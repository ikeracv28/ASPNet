class Ejercicio2
{
    public static void Main(string[] args)
    {

        // lista de palabras
        var palabras = new List<string> { "casa", "coche", "árbol", "mesa", "silla" };

        // 1. Selecciona solo las palabras que tengan más de 4 letras

        //con metodo
        var palabrasmas4letrasMetodo = palabras.Where(p => p.Length > 4);
        Console.WriteLine("Palabras + de 4 letras (método): " + string.Join(", ", palabrasmas4letrasMetodo));

        //con consulta
        var palabrasmas4letrasConsulta = from p in palabras where p.Length > 4 select p;
        Console.WriteLine("Palabras + de 4 letras (consulta): " + string.Join(", ", palabrasmas4letrasConsulta));

        // 2. Transforma cada palabra a mayúsculas

        //con metodo
        var palabraAmayusculas = palabras.Select(p => p.ToUpper());
        Console.WriteLine("Palabras convertida a mayusculas (método): " + string.Join(", ", palabraAmayusculas));

        //con consulta
        var palabraAmayusculasConsulta = from p in palabras select p.ToUpper();
        Console.WriteLine("Palabras convertida a mayusculas (consulta): " + string.Join(", ", palabraAmayusculasConsulta));


        // 3. Crea un nuevo tipo anónimo con la palabra y su longitud

        // con metodo
        var anonimo = palabras.Select(p => new { palabra = p, numero = p.Length });
        Console.WriteLine("Palabras Tipo anonimo (método): " + string.Join(", ", anonimo));

    }
}
