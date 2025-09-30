using System;

class A
{
    private int _x;

    // Constructor de A
    public A(int x)
    {
        _x = x;
        // Equivalente de this._x = x;
    }

    // para poder redefinir metodos en las clases hijas hay que poner virtual
    public virtual void Soy()
    {
        Console.WriteLine($"Soy A y x vale:  { _x}");
    }
}
class B: A
{
    private int _y;
    // Constructor de B
    public B(int x, int y ): base(x)
    {
        _y = y;
    }
    // para redefinir un metodo de la clase padre se usa override, si no seguira usando la de la clase padre
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


