class TablaMultiplicar
{
    public int Base { get; set; }

    // esto es que cuando lo utilicemos como un array y le pasemos un numero, me tiene que devolver lo del get
    //public int this[int n] { get => Base * n; }
    // probar otra cosa
    public int this[int n] { get => n * n;}
}


class Program
{
    static void Main()
    {
        var tb = new TablaMultiplicar();

        //tb.Base = 3;
        //Console.WriteLine($"5 * 3 = {tb[5]}");
        Console.WriteLine($"La raiz caudradada de 5 es=  {tb[5]}");
    }
}