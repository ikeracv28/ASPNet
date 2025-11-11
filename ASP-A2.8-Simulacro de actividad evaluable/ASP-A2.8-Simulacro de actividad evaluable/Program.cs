using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Program
{

    class Programa
    {
        static List<Figura> figuras = new List<Figura>();


        static int LeerOpcion()
        {
            while (true)
            {
                Console.Write("Introduce una opcion entre 1 y 5: ");
                int opcion = 0;
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    if (opcion >= 1 && opcion <= 5)
                    {
                        return opcion;
                    }
                }
            }
        }



        // Rquisito funcional
        static void CrearFigura()
        {
            Console.WriteLine("Elija un circulo, rectangulo o rombo: ");
            string figura = Console.ReadLine().ToLower();

            if (figura.Equals("circulo"))
            {
                Console.Write("Radio: ");
                double radio;
                if (double.TryParse(Console.ReadLine(), out radio))
                {
                    Circulo circulo = new Circulo();
                    circulo.Radio = radio;
                    figuras.Add(circulo);

                }
                else
                {
                    Console.WriteLine("No se ha creado");
                }
            } else if (figura.Equals("rectangulo"))
            {
                Console.Write("Altura: ");
                double altura;
                Console.Write("Base: ");
                double basec;
                if (!double.TryParse(Console.ReadLine(), out altura))
                {
                    Console.WriteLine("Altura inválida. No se ha creado");
                    return;
                }
                Console.Write("Base: ");
                double baseRect;
                if (!double.TryParse(Console.ReadLine(), out baseRect))
                {
                    Console.WriteLine("Base inválida. No se ha creado");
                    return;
                }              
                    Rectangulo rectangulo = new Rectangulo();
                    rectangulo.Altura = altura;
                    rectangulo.Base = baseRect;
                    figuras.Add(rectangulo);
                
            }
        }


        static void VerColeccion()
        {
            foreach (Figura figura in figuras)
            {
                Console.WriteLine(figura.ToString());
            }
        }
        static void CalcularAreaTotal()
        {
            Console.WriteLine($"Area total = {figuras.Sum(f => f.CalcularArea())}");
        }

        static void CalcularPerimetroTotal()
        {
            Console.WriteLine($"Perimetro  total = {figuras.Sum(f => f.CalcularPerimetro())}");
        }

        static void Menu()
        {
            Console.WriteLine("1- Crear Figura");
            Console.WriteLine("2- Ver coleccion");
            Console.WriteLine("3- Calcular Area Total");
            Console.WriteLine("4- Calcular Perimetro Total");
            Console.WriteLine("5- CTerminar");
        }

        public static void Main()
        {
            while (true)
            {
                Menu();
                int opcion = LeerOpcion();
                switch (opcion)
                {
                    case 1:
                        CrearFigura();
                        break;
                    case 2:
                        VerColeccion();
                        break;

                    case 3:
                        CalcularAreaTotal();
                        break;

                    case 4:
                        CalcularPerimetroTotal();
                        break;

                    case 5:
                        break;

                }
            }


        }

        // Requisito Tecnico de Abstraccion
        public abstract class Figura
        {


            // Rquisito técnico de polimorfismo
            public abstract double CalcularArea();

            public abstract double CalcularPerimetro();


        }

        // Requisito Tecnico de Herencia
        public class Circulo : Figura
        {
            // Requisito funcional
            // Propiedades no automaticas
            private double _radio;

            // Requisito de calidad si valores negativos
            public double Radio { get => _radio; set => _radio = value <= 0 ? 1 : value; }

            // Requisitos tecnicos de propiedad de solo lectura
            public double Area { get => Math.PI * Math.Pow(Radio, 2); }
            public double Perimetro { get => 2 * Math.PI * Radio; }

            public override double CalcularArea()
            {
                return Area;
            }

            public override double CalcularPerimetro()
            {
                return Perimetro;
            }

            // Requisito funcional ver coleccion
            public override string ToString()
            {
                return $"Circulo de radio {Radio} con área {Area} y perímetro {Perimetro}";
            }
        }

        public class Rectangulo : Figura
        {
            // Requisito funcional
            // Propiedades no automaticas
            private double _base;
            private double _altura;

            // Requisito de calidad si valores negativos
            public double Base { get => _base; set => _base = value <= 0 ? 1 : value; }
            public double Altura { get => _altura; set => _altura = value <= 0 ? 1 : value; }

            public double Area { get => Base * Altura; }
            public double Perimetro { get => 2 * (Base + Altura); }


            public override double CalcularArea()
            {
                return Area;
            }

            public override double CalcularPerimetro()
            {
                return Perimetro;
            }

            // Requisito funcional ver coleccion
            public override string ToString()
            {
                return $"Rectangulo de base {Base} y altura {Altura} con área {Area} y perímetro {Perimetro}";
            }
        }
        public class Rombo : Figura
        {
            // Requisito funcional
            // Propiedades no automaticas
            private double _diagonalMayor;
            private double _diagonalMenor;

            // Requisito de calidad si valores negativos
            public double DiagonalMayor { get => _diagonalMayor; set => _diagonalMayor = value <= 0 ? 1 : value; }
            public double DiagonalMenor { get => _diagonalMenor; set => _diagonalMenor = value <= 0 ? 1 : value; }

            public double Area { get => (DiagonalMayor * DiagonalMenor) / 2; }
            public double Perimetro { get => 2 * Math.Sqrt(Math.Pow(DiagonalMayor, 2) + Math.Pow(DiagonalMenor, 2)); }

            var consumo = LeerDouble("Consumo (L/100km) (ej: 25.5): ");


            public override double CalcularArea()
            {
                return Area;
            }

            public override double CalcularPerimetro()
            {
                return Perimetro;
            }

            // Requisito funcional ver coleccion
            public override string ToString()
            {
                return $"Rombo de DiagonalMayor {DiagonalMayor} y DiagonalMenor {DiagonalMenor} con área {Area} y perímetro {Perimetro}";
            }

            

        }

    }
}

