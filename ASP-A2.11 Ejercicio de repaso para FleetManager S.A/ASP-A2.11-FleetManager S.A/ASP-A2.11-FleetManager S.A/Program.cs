using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    class Programa
    {
        // =======================================
        // COLECCIÓN INTERNA (POLIMORFISMO)
        // =======================================
        static List<Vehiculo> flota = new List<Vehiculo>();

        // =======================================
        // MÉTODOS DE UTILIDAD
        // =======================================

        static int LeerOpcion()
        {
            while (true)
            {
                Console.Write("Introduce una opción entre 1 y 4: ");
                int opcion;
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    if (opcion >= 1 && opcion <= 4)
                        return opcion;
                }
                Console.WriteLine("Opción no válida.");
            }
        }

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
                Console.WriteLine("Valor inválido. Introduce un número válido.");
            }
        }

        static string LeerTexto(string mensaje)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(texto))
            {
                return "Sin datos";
            }
            return texto;
        }

        // =======================================
        // OPCIÓN 1: REGISTRAR VEHÍCULO
        // =======================================
        static void RegistrarVehiculo()
        {
            Console.WriteLine("Tipos de vehículo: autobus / camion");
            Console.Write("Introduce el tipo de vehículo: ");
            string tipo = Console.ReadLine().ToLower();

            string matricula = LeerTexto("Matrícula: ");
            double consumo = LeerDoubleNoNegativo("Consumo (litros/100 km): ");

            if (tipo.Equals("autobus"))
            {
                double capacidad = LeerDoubleNoNegativo("Capacidad máxima (pasajeros): ");
                Autobus bus = new Autobus(matricula, consumo, capacidad);
                flota.Add(bus);
                Console.WriteLine("Autobús registrado correctamente.");
            }
            else if (tipo.Equals("camion"))
            {
                double peaje = LeerDoubleNoNegativo("Peaje anual (€): ");
                Camion cam = new Camion(matricula, consumo, peaje);
                flota.Add(cam);
                Console.WriteLine("Camión registrado correctamente.");
            }
            else
            {
                Console.WriteLine("Tipo de vehículo no reconocido.");
            }
        }

        // =======================================
        // OPCIÓN 2: VER COSTOS OPERACIONALES
        // =======================================
        static void VerCostosOperacionales()
        {
            if (flota.Count == 0)
            {
                Console.WriteLine("No hay vehículos registrados.");
                return;
            }

            foreach (Vehiculo v in flota)
            {
                Console.WriteLine(v.ToString());
                Console.WriteLine($"Costo operacional por km: {v.CalcularCostoPorKm():0.0000} €/km");
                Console.WriteLine("--------------------------------------------");
            }
        }

        // =======================================
        // OPCIÓN 3: COSTO TOTAL DE FLOTA
        // =======================================
        static void CalcularCostoTotalFlota()
        {
            const double DISTANCIA = 100000.0;
            double total = flota.Sum(v => v.CalcularCostoPorKm() * DISTANCIA);
            Console.WriteLine($"Costo total estimado de la flota (para {DISTANCIA:0} km por vehículo): {total:0.00} €");
        }

        // =======================================
        // MENÚ
        // =======================================
        static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("===== FleetManager S.A - Sistema de Gestión de Vehículos =====");
            Console.WriteLine("1- Registrar vehículo");
            Console.WriteLine("2- Ver costos operacionales");
            Console.WriteLine("3- Calcular costo total de flota (100.000 km)");
            Console.WriteLine("4- Salir");
        }

        // =======================================
        // MAIN
        // =======================================
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8; // para que se vea el símbolo €
            while (true)
            {
                Menu();
                int opcion = LeerOpcion();

                switch (opcion)
                {
                    case 1:
                        RegistrarVehiculo();
                        break;
                    case 2:
                        VerCostosOperacionales();
                        break;
                    case 3:
                        CalcularCostoTotalFlota();
                        break;
                    case 4:
                        return;
                }
            }
        }

        // =======================================
        // CLASES DE DOMINIO
        // =======================================

        // Ejercicio 1: Clase base Vehiculo
        // Requisito técnico de abstracción
        public abstract class Vehiculo
        {
            public string Matricula { get; set; }

            private double _consumo;
            public double Consumo
            {
                get => _consumo;
                set => _consumo = value < 0 ? 0.0 : value;
            }

            // Propiedad de solo lectura
            public double CostoOperacionalBase => 0.15;

            protected Vehiculo(string matricula, double consumo)
            {
                Matricula = string.IsNullOrWhiteSpace(matricula) ? "Sin matrícula" : matricula;
                Consumo = consumo;
            }

            // Polimorfismo
            public virtual double CalcularCostoPorKm()
            {
                return Consumo * CostoOperacionalBase;
            }

            public override string ToString()
            {
                return $"Vehículo -> Matrícula: {Matricula}, Consumo: {Consumo:0.00} L/100km, Costo base: {CostoOperacionalBase:0.00} €/L";
            }
        }

        // Ejercicio 2: Clase Autobus
        // Requisito técnico de herencia
        public class Autobus : Vehiculo
        {
            private double _capacidadMaxima;
            public double CapacidadMaxima
            {
                get => _capacidadMaxima;
                set => _capacidadMaxima = value < 0 ? 0.0 : value;
            }

            // Factor de desgaste de 1.2
            public double FactorDesgaste => 1.2;

            public Autobus(string matricula, double consumo, double capacidadMaxima)
                : base(matricula, consumo)
            {
                CapacidadMaxima = capacidadMaxima;
            }

            // Coste por km = consumo × costo base × factor de desgaste
            public override double CalcularCostoPorKm()
            {
                return base.CalcularCostoPorKm() * FactorDesgaste;
            }

            public override string ToString()
            {
                return $"Autobús -> Matrícula: {Matricula}, Consumo: {Consumo:0.00} L/100km, Capacidad: {CapacidadMaxima:0.00} pasajeros, Factor desgaste: {FactorDesgaste}";
            }
        }

        // Ejercicio 3: Clase Camion
        public class Camion : Vehiculo
        {
            private double _peajeAnual;
            public double PeajeAnual
            {
                get => _peajeAnual;
                set => _peajeAnual = value < 0 ? 0.0 : value;
            }

            public Camion(string matricula, double consumo, double peajeAnual)
                : base(matricula, consumo)
            {
                PeajeAnual = peajeAnual;
            }

            // Coste por km = consumo × costo base + (peaje anual / 100000)
            public override double CalcularCostoPorKm()
            {
                return base.CalcularCostoPorKm() + (PeajeAnual / 100000.0);
            }

            public override string ToString()
            {
                return $"Camión -> Matrícula: {Matricula}, Consumo: {Consumo:0.00} L/100km, Peaje anual: {PeajeAnual:0.00} €";
            }
        }
    }
}
