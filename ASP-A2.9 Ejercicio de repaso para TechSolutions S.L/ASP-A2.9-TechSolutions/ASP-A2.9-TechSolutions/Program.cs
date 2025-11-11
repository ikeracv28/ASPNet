using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    // Igual que en tu ejemplo: toda la lógica dentro de una clase interna
    class Programa
    {
        // Colección interna de empleados (polimorfismo)
        static List<Empleado> empleados = new List<Empleado>();

        // --- MÉTODOS DE UTILIDAD ---

        // Requisito de calidad: leer opción válida del menú
        static int LeerOpcion()
        {
            while (true)
            {
                Console.Write("Introduce una opción entre 1 y 4: ");
                int opcion = 0;
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    if (opcion >= 1 && opcion <= 4)
                    {
                        return opcion;
                    }
                }
                Console.WriteLine("Opción no válida.");
            }
        }

        // Lectura numérica con validación y ajuste a 0.0 si negativo (requisito del enunciado)
        static double LeerDoubleNoNegativo(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                double valor;
                if (double.TryParse(Console.ReadLine(), out valor))
                {
                    if (valor < 0)
                    {
                        Console.WriteLine("Valor negativo detectado. Se asignará 0.0 automáticamente.");
                        return 0.0;
                    }
                    return valor;
                }
                Console.WriteLine("Valor inválido. Introduce un número.");
            }
        }

        // Lectura simple de nombre, con control mínimo
        static string LeerNombre(string mensaje)
        {
            Console.Write(mensaje);
            string nombre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return "Sin nombre";
            }
            return nombre;
        }

        // --- OPCIÓN 1: CONTRATAR EMPLEADO ---
        static void ContratarEmpleado()
        {
            Console.WriteLine("Tipos de empleado disponibles: base / fijo / hora");
            Console.Write("Introduce el tipo de empleado: ");
            string tipo = Console.ReadLine().ToLower();

            string nombre = LeerNombre("Nombre: ");
            double salarioBase = LeerDoubleNoNegativo("Salario base mensual: ");

            if (tipo.Equals("base"))
            {
                EmpleadoBase e = new EmpleadoBase(nombre, salarioBase);
                empleados.Add(e);
                Console.WriteLine("Empleado base contratado correctamente.");
            }
            else if (tipo.Equals("fijo"))
            {
                double bonoAnual = LeerDoubleNoNegativo("Bono anual: ");
                EmpleadoFijo e = new EmpleadoFijo(nombre, salarioBase, bonoAnual);
                empleados.Add(e);
                Console.WriteLine("Empleado fijo contratado correctamente.");
            }
            else if (tipo.Equals("hora"))
            {
                double tarifaHora = LeerDoubleNoNegativo("Tarifa por hora: ");
                double horasMes = LeerDoubleNoNegativo("Horas trabajadas en el mes: ");
                EmpleadoPorHora e = new EmpleadoPorHora(nombre, salarioBase, tarifaHora, horasMes);
                empleados.Add(e);
                Console.WriteLine("Empleado por hora contratado correctamente.");
            }
            else
            {
                Console.WriteLine("Tipo de empleado no reconocido. No se ha creado el empleado.");
            }
        }

        // --- OPCIÓN 2: VER NÓMINAS INDIVIDUALES ---
        static void VerNominasIndividuales()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados contratados.");
                return;
            }

            foreach (Empleado e in empleados)
            {
                // Polimorfismo: se llama al ToString() y CalcularNomina() específico de cada tipo
                Console.WriteLine(e.ToString());
                Console.WriteLine($"Nómina mensual: {e.CalcularNomina():0.00}");
                Console.WriteLine("--------------------------------------");
            }
        }

        // --- OPCIÓN 3: CALCULAR COSTE TOTAL ---
        static void CalcularCosteTotalNominas()
        {
            double total = empleados.Sum(e => e.CalcularNomina());
            Console.WriteLine($"Coste total de nóminas del mes: {total:0.00}");
        }

        // --- MENÚ ---
        static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("=== TechSolutions S.L. - HRSystem ===");
            Console.WriteLine("1- Contratar empleado");
            Console.WriteLine("2- Ver nóminas individuales");
            Console.WriteLine("3- Calcular coste total de nóminas");
            Console.WriteLine("4- Salir");
        }

        // --- MAIN ---
        public static void Main()
        {
            while (true)
            {
                Menu();
                int opcion = LeerOpcion();

                switch (opcion)
                {
                    case 1:
                        ContratarEmpleado();
                        break;
                    case 2:
                        VerNominasIndividuales();
                        break;
                    case 3:
                        CalcularCosteTotalNominas();
                        break;
                    case 4:
                        // Terminar programa
                        return;
                }
            }
        }

        // ======================
        //   CLASES DE DOMINIO
        // ======================

        // Ejercicio 1: Clase base Empleado
        // Requisito técnico de abstracción
        public abstract class Empleado
        {
            // Propiedad automática: Nombre (Requisito funcional)
            public string Nombre { get; set; }

            // Propiedad NO automática: SalarioBase (con validación)
            private double _salarioBase;

            // Requisito de calidad: si es negativo, se guarda 0.0
            public double SalarioBase
            {
                get => _salarioBase;
                set => _salarioBase = value < 0 ? 0.0 : value;
            }

            // Constructor (encapsulación + validación)
            protected Empleado(string nombre, double salarioBase)
            {
                Nombre = string.IsNullOrWhiteSpace(nombre) ? "Sin nombre" : nombre;
                SalarioBase = salarioBase;
            }

            // Métodos polimórficos
            public abstract double CalcularNomina();
            public abstract override string ToString();
        }

        // Empleado Base (sin bono ni extras)
        public class EmpleadoBase : Empleado
        {
            // Constructor que llama al base (reutilización)
            public EmpleadoBase(string nombre, double salarioBase)
                : base(nombre, salarioBase)
            {
            }

            // Nómina mensual = salario base
            public override double CalcularNomina()
            {
                return SalarioBase;
            }

            // ToString polimórfico
            public override string ToString()
            {
                return $"Empleado Base -> Nombre: {Nombre}, Salario base: {SalarioBase:0.00}";
            }
        }

        // Ejercicio 2: EmpleadoFijo
        // Requisito técnico de herencia
        public class EmpleadoFijo : Empleado
        {
            // Propiedad no automática con validación
            private double _bonoAnual;

            public double BonoAnual
            {
                get => _bonoAnual;
                set => _bonoAnual = value < 0 ? 0.0 : value;
            }

            // Constructor apoyado en la clase base
            public EmpleadoFijo(string nombre, double salarioBase, double bonoAnual)
                : base(nombre, salarioBase)
            {
                BonoAnual = bonoAnual;
            }

            // Nómina mensual = salario base + (bono anual / 12)
            public override double CalcularNomina()
            {
                return SalarioBase + (BonoAnual / 12.0);
            }

            public override string ToString()
            {
                return $"Empleado Fijo -> Nombre: {Nombre}, Salario base: {SalarioBase:0.00}, Bono anual: {BonoAnual:0.00}";
            }
        }

        // Ejercicio 3: EmpleadoPorHora
        public class EmpleadoPorHora : Empleado
        {
            private double _tarifaHora;
            private double _horasTrabajadasMes;

            public double TarifaHora
            {
                get => _tarifaHora;
                set => _tarifaHora = value < 0 ? 0.0 : value;
            }

            public double HorasTrabajadasMes
            {
                get => _horasTrabajadasMes;
                set => _horasTrabajadasMes = value < 0 ? 0.0 : value;
            }

            // Constructor apoyado en base
            public EmpleadoPorHora(string nombre, double salarioBase, double tarifaHora, double horasTrabajadasMes)
                : base(nombre, salarioBase)
            {
                TarifaHora = tarifaHora;
                HorasTrabajadasMes = horasTrabajadasMes;
            }

            // Nómina mensual = salario base + tarifaHora * horasTrabajadasMes
            public override double CalcularNomina()
            {
                return SalarioBase + (TarifaHora * HorasTrabajadasMes);
            }

            public override string ToString()
            {
                return $"Empleado Por Hora -> Nombre: {Nombre}, Salario base: {SalarioBase:0.00}, Tarifa/hora: {TarifaHora:0.00}, Horas mes: {HorasTrabajadasMes:0.00}";
            }
        }
    }
}
