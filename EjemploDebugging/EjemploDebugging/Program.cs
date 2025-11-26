using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EjemploDebugging
{
    internal class Program

    {

        static void Main(string[] args)
        {
            //        ProcesosGuapardos p = new ProcesosGuapardos();
            //        // p.ejemplosGuapardos();
            //        int contador = 0;
            //        if (args.Length < 2)
            //        {
            //            Console.WriteLine("Uso: Subproceso_SumaParcial <inicio> <fin>");
            //            return;
            //        }

            //        int inicio = int.Parse(args[0]);
            //        int fin = int.Parse(args[1]);
            //        long suma = 0;

            //        for (int i = inicio; i <= fin; i++)
            //        {
            //            if (p.esPrimo(i))
            //            {
            //                contador++;
            //            }

            //        }

            //        Console.WriteLine(contador);

            //    }

            /////////////////////////////////  Ejemplo del profe para enseñarnoslo ////////////////////////////////////////
            //HilosAunMasGuapos hi = new HilosAunMasGuapos();


            //// con esto hacemos que sea un hilo secundario, por crearlo en Thread
            //Thread hilo = new Thread(hi.EjemploHilos0);

            //hilo.Start();


            //// como se llama directamente en el main, este sera el hilo principal
            //hi.EjemploTrabajoHiloPrincipal();
            //////////////////////////////////////////////////////////////////////////////////////////


            /////////////////////////////////  Ejemplo para practicar contador de segundos ////////////////////////////////////////
            /*
            EjercicioAfianzarHilos ejercicio = new EjercicioAfianzarHilos();

            Thread hiloEjercicio = new Thread(ejercicio.ContadorSegundos);

            hiloEjercicio.Start();

            ejercicio.CuentoCada10Segundos();
            */
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////Ejemplo para meter un parametro dentro del metodo usando object ///////////////////////////////////

            /*
            MetodoConParametrosClase hilos = new MetodoConParametrosClase();

            Thread hilo1 = new Thread(new ParameterizedThreadStart(hilos.MetodoConParametros));
            Thread hilo2 = new Thread(new ParameterizedThreadStart(hilos.MetodoConParametros));
            Thread hilo3 = new Thread(new ParameterizedThreadStart(hilos.MetodoConParametros));

            hilo1.Start('a');
            hilo2.Start('b');
            hilo3.Start('c');
            */

            ////////////////////////////////////////////// Ejemplo de Join ////////////////////////////////////////////////////

            PraacticarJoins joins = new PraacticarJoins();

            joins.EjemploTrabajoHiloPrincipalConEjHilo2();


        }







        class ProcesosGuapardos
        {
            public void EjemploProcesos0()
            {
                Console.Write("\n Hola,que programa quieres abrir?");

                bool input_valido = false;
                while (!input_valido)
                {
                    Console.Write("\n1. Calculadora\n2. Explorador de carpetas de Windows\n3. Paint\nPulsa la tecla de borrar para salir");

                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.NumPad1)
                    {
                        Console.Write("\nLanzando calaculadora...\n");
                        Process calc = Process.Start("calc.exe");

                    }
                    else if (key.Key == ConsoleKey.NumPad2)
                    {
                        Console.Write("\nLanzando explorador de carpetas...\n");
                        Process explorador = Process.Start("explorer.exe");

                    }
                    else if (key.Key == ConsoleKey.NumPad3)
                    {
                        Console.Write("\nLanzando el paint...\n");
                        Process paint = Process.Start("mspaint.exe");

                        // esto es para que no puedas escribir nada mas hasta que no cierres el programa abierto
                        paint.WaitForExit();

                        //Y esto es par limpiar el buffer, ya que si no se guarda todo lo que pulses cuando cierres el programa
                        while (Console.KeyAvailable)
                            Console.ReadKey(true);

                        Console.Write("\nCerrando Paint...\n");
                    }
                    else if (key.Key == ConsoleKey.Backspace)
                    {
                        Console.Write("\nSaliendo...\n");
                        input_valido = true; break;
                    }
                }
            }

            public bool esPrimo(int n)
            {

                if (n <= 1) return false;               // porque 0 y 1 no son primos


                for (int i = 2; i * i <= n; i++)
                {
                    if (n % i == 0)
                    {
                        return false; // si al dividir entre algun otro numero que no sea el mismo o 1 da 0 NO es primo
                    }
                }
                return true;        // no tuvo divisores, si es primo

            }

        }

        class HilosAunMasGuapos
        {
            public void EjemploHilos0()
            {
                for (int i = 0; i <= 65; i++)
                {
                    Console.WriteLine("Hilo secundario i= " + i);
                    Thread.Sleep(200);
                }
            }

            public void EjemploTrabajoHiloPrincipal()
            {
                for (int j = 0; j <= 5; j++)
                {
                    Console.WriteLine("Hilo principal j= " + j);
                    Thread.Sleep(200);
                }
                Console.WriteLine("FIn del hilo principal");
            }
        }

        class EjercicioAfianzarHilos
        {
            public void ContadorSegundos()
            {
                for (int i = 1; i <= 60; i++)
                {
                    Console.WriteLine("Hilo secundario contador de segundos= " + i);
                    Thread.Sleep(1000);
                }
            }

            public void CuentoCada10Segundos()
            {
                for (int j = 0; j <= 6; j++)
                {
                    Console.WriteLine("Hilo principal contador cada 10 segundos = " + j);
                    Thread.Sleep(10000);
                }
                Console.WriteLine("FIn del hilo principal");
            }


            
          
        }
        class MetodoConParametrosClase
        {
            public void MetodoConParametros(object valor)
            {
                int id = (int)valor;
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine("Hilo " + id + " -> iteracion " + i);
                    Thread.Sleep(1000);
                }
            }

            public void MetodoConParametrosPracticarChar(object valor)
            {
                char id = (char)valor;
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine("Hilo " + id + " -> iteracion " + i);
                    Thread.Sleep(1000);
                }
            }
        }


        // el join lo que hace es decirle espera, hasta que no acabe uno no empieces el siguiente
        class PraacticarJoins
        {
            public void EjemploHilos2(string nombre, int milisecs)
            {
                Console.WriteLine("Inicio " + nombre);
                Thread.Sleep(milisecs);
                Console.WriteLine("Fin " + nombre);
            }

            public void EjemploTrabajoHiloPrincipalConEjHilo2()
            {
                Stopwatch cronoParalelo = new Stopwatch();
                cronoParalelo.Start();

                Thread hiloA = new Thread(() => EjemploHilos2("Hilo A", 1000));
                Thread hiloB = new Thread(() => EjemploHilos2("Hilo B", 1000));

                hiloA.Start();
                hiloB.Start();

                hiloA.Join();
                hiloB.Join();

                cronoParalelo.Stop();

                Console.WriteLine("Tiempo total (paralelo) :  " + cronoParalelo.ElapsedMilliseconds + " ms");

                Stopwatch cronoEnSecuencial = new Stopwatch();

                cronoEnSecuencial.Start();

                EjemploHilos2("Secuencial A", 1000);
                EjemploHilos2("Secuencial B", 1000);

                cronoEnSecuencial.Stop();
                Console.WriteLine("Tiempo total (secuencial) :  " + cronoEnSecuencial.ElapsedMilliseconds + " ms");

            }
        }
       
    }
}







//static void Main(string[] args)
//{

//    ProcesosGuapardos p = new ProcesosGuapardos();
//    //p.EjemploProcesos0();

//    int contador = 0;

//    if (args.Length < 2)
//    {
//        Console.WriteLine("Uso: Subproceso_SumaParcial <inicio> <fin>");
//        return;
//    }

//    int inicio = int.Parse(args[0]);
//    int fin = int.Parse(args[1]);
//    long suma = 0;

//    for (int i = inicio; i <= fin; i++)
//    {
//        // suma += i;
//        if (p.esPrimo(i))
//        {
//            contador++;
//        }

//        Console.WriteLine(suma);


//        //Console.Write("Hola buenas tardes");

//        //string patata = Console.ReadLine();

//        //int valor = Convert.ToInt32(patata);

//        //for (int i = 0; i < valor; i++)
//        //{
//        //    Console.Write("Valor de i: " + valor);

//        //}
//    }


//}