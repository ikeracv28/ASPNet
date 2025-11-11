using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    class Programa
    {
        // ================================
        //  COLECCIÓN (POLIMORFISMO)
        // ================================
        // Requisito técnico: polimorfismo con colección de la clase base
        static List<Envio> envios = new List<Envio>();

        // ================================
        //  MÉTODOS DE UTILIDAD
        // ================================

        // Requisito de calidad: leer opción válida del menú
        static int LeerOpcion()
        {
            while (true)
            {
                Console.Write("Introduce una opción entre 1 y 4: ");
                int opcion;
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

        // Requisito de calidad: lectura numérica con validación
        // Si es negativo → se informa y se devuelve 0.0
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
                Console.WriteLine("Entrada inválida. Introduce un número válido.");
            }
        }

        static string LeerTexto(string mensaje)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(texto))
            {
                return "Sin descripción";
            }
            return texto;
        }

        // ================================
        //  OPCIÓN 1: CREAR ENVÍO
        // ================================
        // Ejercicio 4: creación polimórfica
        static void CrearEnvio()
        {
            Console.WriteLine("Tipos de envío disponibles: estandar / express");
            Console.Write("Introduce el tipo de envío: ");
            string tipo = Console.ReadLine().ToLower();

            string descripcion = LeerTexto("Descripción del envío: ");
            double peso = LeerDoubleNoNegativo("Peso (kg): ");

            if (tipo.Equals("estandar"))
            {
                double tarifaPlana = LeerDoubleNoNegativo("Tarifa plana (€): ");
                PaqueteEstandar pe = new PaqueteEstandar(descripcion, peso, tarifaPlana);
                envios.Add(pe);
                Console.WriteLine("Paquete estándar creado correctamente.");
            }
            else if (tipo.Equals("express"))
            {
                double recargo = LeerDoubleNoNegativo("Recargo urgencia por kg (€): ");
                PaqueteExpress px = new PaqueteExpress(descripcion, peso, recargo);
                envios.Add(px);
                Console.WriteLine("Paquete express creado correctamente.");
            }
            else
            {
                Console.WriteLine("Tipo de envío no reconocido. No se ha creado el envío.");
            }
        }

        // ================================
        //  OPCIÓN 2: VER COSTOS INDIVIDUALES
        // ================================
        static void VerCostosIndividuales()
        {
            if (envios.Count == 0)
            {
                Console.WriteLine("No hay envíos registrados.");
                return;
            }

            foreach (Envio e in envios)
            {
                // Polimorfismo: se ejecuta el ToString() y CalcularCostoTotal() de la subclase real
                Console.WriteLine(e.ToString());
                Console.WriteLine($"Costo total: {e.CalcularCostoTotal():0.00} €");
                Console.WriteLine("-----------------------------------");
            }
        }

        // ================================
        //  OPCIÓN 3: CALCULAR INGRESO TOTAL
        // ================================
        static void CalcularIngresoTotal()
        {
            double total = envios.Sum(e => e.CalcularCostoTotal());
            Console.WriteLine($"Ingreso total por envíos: {total:0.00} €");
        }

        // ================================
        //  MENÚ
        // ================================
        static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("====== LogiTrack S.A - Sistema de Gestión de Envíos ======");
            Console.WriteLine("1- Crear envío");
            Console.WriteLine("2- Ver costos individuales");
            Console.WriteLine("3- Calcular ingreso total");
            Console.WriteLine("4- Salir");
        }

        // ================================
        //  MAIN
        // ================================
        public static void Main()
        {
            while (true)
            {
                Menu();
                int opcion = LeerOpcion();

                switch (opcion)
                {
                    case 1:
                        CrearEnvio();
                        break;
                    case 2:
                        VerCostosIndividuales();
                        break;
                    case 3:
                        CalcularIngresoTotal();
                        break;
                    case 4:
                        return; // salir del programa
                }
            }
        }

        // ================================
        //  CLASES DE DOMINIO
        // ================================

        // ================================
        //  Ejercicio 1: Clase base Envio
        // ================================
        // Requisito técnico: abstracción
        public abstract class Envio
        {
            // Propiedad automática (Requisito funcional)
            public string Descripcion { get; set; }

            // Propiedad no automática con validación (Requisito de calidad)
            private double _peso;
            public double Peso
            {
                get => _peso;
                set => _peso = value < 0 ? 0.0 : value;
            }

            // Propiedad solo lectura: 2.0 € por kg (Requisito técnico)
            // Costo base = 2.0 * Peso
            public double CostoBase
            {
                get { return 2.0 * Peso; }
            }

            // Constructor con encapsulación + validación
            protected Envio(string descripcion, double peso)
            {
                Descripcion = string.IsNullOrWhiteSpace(descripcion) ? "Sin descripción" : descripcion;
                Peso = peso;
            }

            // Método polimórfico: se podrá sobrescribir
            public virtual double CalcularCostoTotal()
            {
                // Por defecto, el envío base solo cuesta el costo base
                return CostoBase;
            }

            // Método polimórfico ToString()
            public override string ToString()
            {
                return $"Envío -> Descripción: {Descripcion}, Peso: {Peso:0.00} kg, Costo base: {CostoBase:0.00} €";
            }
        }

        // ================================
        //  Ejercicio 2: PaqueteEstandar
        // ================================
        // Requisito técnico: herencia
        public class PaqueteEstandar : Envio
        {
            // Propiedad no automática con validación
            private double _tarifaPlana;
            public double TarifaPlana
            {
                get => _tarifaPlana;
                set => _tarifaPlana = value < 0 ? 0.0 : value;
            }

            // Constructor apoyado en el de la base
            public PaqueteEstandar(string descripcion, double peso, double tarifaPlana)
                : base(descripcion, peso)
            {
                TarifaPlana = tarifaPlana;
            }

            // CostoTotal = CostoBase + TarifaPlana
            public override double CalcularCostoTotal()
            {
                return base.CalcularCostoTotal() + TarifaPlana;
            }

            public override string ToString()
            {
                return $"Paquete Estándar -> Descripción: {Descripcion}, Peso: {Peso:0.00} kg, " +
                       $"Costo base: {CostoBase:0.00} €, Tarifa plana: {TarifaPlana:0.00} €";
            }
        }

        // ================================
        //  Ejercicio 3: PaqueteExpress
        // ================================
        public class PaqueteExpress : Envio
        {
            // Recargo por urgencia (por kg, según enunciado)
            private double _recargoUrgencia;
            public double RecargoUrgencia
            {
                get => _recargoUrgencia;
                set => _recargoUrgencia = value < 0 ? 0.0 : value;
            }

            // Constructor apoyado en la base
            public PaqueteExpress(string descripcion, double peso, double recargoUrgencia)
                : base(descripcion, peso)
            {
                RecargoUrgencia = recargoUrgencia;
            }

            // CostoTotal = CostoBase + RecargoUrgencia * Peso
            public override double CalcularCostoTotal()
            {
                return base.CalcularCostoTotal() + (RecargoUrgencia * Peso);
            }

            public override string ToString()
            {
                return $"Paquete Express -> Descripción: {Descripcion}, Peso: {Peso:0.00} kg, " +
                       $"Costo base: {CostoBase:0.00} €, Recargo urgencia/kg: {RecargoUrgencia:0.00} €";
            }
        }
    }
}
