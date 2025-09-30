using System;

class A
{
    public virtual void Soy()
    {
        Console.WriteLine("Soy A");
    }
}

class B: A
{
       public override void  Soy()
    {
        Console.WriteLine("Soy B");
    }
}

public class Programa 
{
    public static void Main(string[] args)
    {
        // Esta es la manera de siempre
        A a = new A();
        a.Soy();
        // Tambien se puede hacer asi directamente
        // new A().Soy();

        B b = new B();
        b.Soy();

        // pOLIMORFISMO
        A ab = new B();
        ab.Soy(); // Llama al metodo de A, no al de B
    }
}


