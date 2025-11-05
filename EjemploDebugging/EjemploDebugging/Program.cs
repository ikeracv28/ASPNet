using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploDebugging
{
    internal class Program

    {
        static void Main(string[] args)
        {
            Console.Write("Hola buenas tardes");

            string patata = Console.ReadLine();

            int valor = Convert.ToInt32(patata);

            for (int i = 0; i < valor; i++)
            {
                Console.Write("Valor de i: " + valor);

            }
        }
    }
}
