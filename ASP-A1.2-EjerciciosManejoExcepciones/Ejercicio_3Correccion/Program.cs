var lista = new String[] {"A", "B", "C", "D", "E"};
for (int ii = 0; ii < 3; ii++)
{
    Console.WriteLine("ingresa un indice: ");

    if (int.TryParse(Console.ReadLine(), out int i)){
        string palabra = lista.ElementAtOrDefault(i);

        if(palabra == null){
            Console.WriteLine("Indice fuera de rango");
        }else{
            Console.WriteLine($"Palabra: {lista[i]}");
        }
    }else{
        Console.WriteLine("Indice no valido");
    }
}