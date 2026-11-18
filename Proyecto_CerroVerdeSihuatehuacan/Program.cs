using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CerroVerdeSihuatehuacan
{
    internal class Program
    {
        private const double precioCerroVerde = 3.00;
        private const double precioSihuatehuacan = 3.00;

        private static Parque parque;
        private static Guia guia;
        private static Sendero sendero;
        private static Piscina piscina;
        private static Visitante visitanteActual; // Guardamos al visitante para el segundo menú

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            PrepararParque();

            // ==========================================
            // FASE 1: CERRO VERDE
            // ==========================================
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("   FASE 1: PARQUE NATURAL CERRO VERDE");
            Console.WriteLine("==============================================");
            Console.WriteLine("El bus ha llegado. Presiona Enter para bajar...");
            Console.ReadLine();

            bool salirFase1 = false;
            while (!salirFase1)
            {
                MostrarMenuCerroVerde();
                int opcion = LeerEntero("Elige una opción: ", 0, 3);
                Console.WriteLine();

                switch (opcion)
                {
                    case 1: RegistrarYCobrarBoletoCerroVerde(); break;
                    case 2: IniciarRecorridoCerroVerde(); break;
                    case 3:
                        if (visitanteActual != null) salirFase1 = true;
                        else Console.WriteLine("Primero debes registrarte y comprar tu boleto (Opción 1).");
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        return;
                }
                if (!salirFase1) Pausa();
            }

            // ==========================================
            // TRANSICIÓN: VIAJE EN BUS
            // ==========================================
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("   VIAJANDO A SIHUATEHUACÁN");
            Console.WriteLine("==============================================");
            Console.WriteLine("Dejando atrás el Cerro Verde, el bus se dirige al parque recreativo...");
            Console.WriteLine("Presiona Enter al llegar...");
            Console.ReadLine();

            // ==========================================
            // FASE 2: SIHUATEHUACÁN
            // ==========================================
            bool salirFase2 = false;
            while (!salirFase2)
            {
                MostrarMenuSihuatehuacan();
                int opcion = LeerEntero("Elige una opción: ", 0, 3);
                Console.WriteLine();

                switch (opcion)
                {
                    case 1: EntrarALasPiscinas(); break;
                    case 2: ComprarEnLaTienda(); break;
                    case 3: salirFase2 = true; break;
                    case 0: return;
                }
                if (!salirFase2) Pausa();
            }

            Console.WriteLine("Regresando a casa... ¡Gracias por la excursión!");
        }

        // ==========================================
        // MENÚS
        // ==========================================
        private static void MostrarMenuCerroVerde()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("   MENÚ: CERRO VERDE");
            Console.WriteLine("------------------------------------------");

            if (visitanteActual == null)
            {
                Console.WriteLine(" 1. Registrar visitante y comprar boleto");
                Console.WriteLine(" 0. Salir del programa");
            }
            else
            {
                Console.WriteLine(" 1. [Listo] Boleto comprado");
                Console.WriteLine(" 2. Realizar recorrido guiado");
                Console.WriteLine(" 3. Ir a Sihuatehuacán (Terminar recorrido)");
                Console.WriteLine(" 0. Salir del programa");
            }
            Console.WriteLine("------------------------------------------");
        }

        private static void MostrarMenuSihuatehuacan()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("   MENÚ: PARQUE RECREATIVO SIHUATEHUACÁN");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(" 1. Ir a las piscinas");
            Console.WriteLine(" 2. Comprar en la tienda");
            Console.WriteLine(" 3. Regresar a casa");
            Console.WriteLine("------------------------------------------");
        }

        // ==========================================
        // LÓGICA DE CERRO VERDE
        // ==========================================
        private static void RegistrarYCobrarBoletoCerroVerde()
        {
            if (visitanteActual != null) return;

            Console.WriteLine("--- REGISTRO Y PAGO (CERRO VERDE) ---");
            string nombre = LeerTexto("Nombre del visitante: ");
            int edad = LeerEntero("Edad (0-90): ", 0, 90);
            Console.WriteLine("Tipo de visitante: 1. Nacional   2. Extranjero");
            int tipoOpcion = LeerEntero("Elige (1-2): ", 1, 2);
            TipoVisitante tipo = tipoOpcion == 1 ? TipoVisitante.NACIONAL : TipoVisitante.EXTRANJERO;

            visitanteActual = new Visitante(nombre, edad, tipo);
            DateTime ahora = DateTime.Now;
            Boleto boleto = new Boleto(precioCerroVerde, ahora, ahora.AddHours(8));
            double precio = boleto.CalcularPrecioEntrada(visitanteActual);

            if (precio == 0)
                Console.WriteLine("¡" + visitanteActual.Nombre + " es mayor de 60 años y entra gratis!");
            else
                Console.WriteLine("Cobrando boleto a " + visitanteActual.Nombre + "... Total: $" + precio.ToString("0.00"));

            visitanteActual.PagarBoleto(boleto);
            parque.RecibirVisitante(visitanteActual);
        }

        private static void IniciarRecorridoCerroVerde()
        {
            if (visitanteActual == null)
            {
                Console.WriteLine("Primero debes comprar tu boleto.");
                return;
            }

            Console.WriteLine("--- RECORRIDO GUIADO: CERRO VERDE ---");
            Console.WriteLine("Esperando al guía... Presiona Enter cuando llegue.");
            Console.ReadLine();

            guia.GuiarGrupo();
            Console.WriteLine();
            guia.Explicar(sendero);

            foreach (SerVivo s in sendero.Vegetacion)
            {
                if (s is Arbol) Console.WriteLine(((Arbol)s).DarSombra());
                else if (s is Planta) Console.WriteLine(((Planta)s).Florecer());
            }

            Console.WriteLine("\nEl grupo llega al mirador...");
            Atraccion mirador = parque.ListaAtracciones.FirstOrDefault(a => a is Mirador);
            if (mirador != null) guia.Explicar(mirador);

            Console.WriteLine("\nTermina el recorrido. Ya puedes irte a Sihuatehuacán (Opción 3).");
        }

        // ==========================================
        // LÓGICA DE SIHUATEHUACÁN
        // ==========================================
        private static void EntrarALasPiscinas()
        {
            Console.WriteLine("--- PISCINAS DE SIHUATEHUACÁN ---");

            Console.WriteLine("Para ingresar debes pagar una entrada adicional de $" + precioSihuatehuacan.ToString("0.00"));
            string pagar = LeerTexto("¿Deseas pagar? (s/n): ");

            if (pagar.Trim().ToLower() == "s")
            {
                Console.WriteLine("\n¡Pago exitoso!");
                Console.WriteLine("==============================================");
                Console.WriteLine("   REGLAS DE LA PISCINA:");
                Console.WriteLine(" - Los hombres deben bañarse sin camisa.");
                Console.WriteLine(" - Las señoritas no deben usar pantalones jeans o shorts jeans.");
                Console.WriteLine("==============================================");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No puedes ingresar a las piscinas sin pagar la entrada.");
                return;
            }

            try
            {
                piscina.IngresarVisitante();
                Console.WriteLine("¡Ingreso exitoso a la piscina!");
                Console.WriteLine("Personas en la piscina: " + piscina.CalcularCantidadPersonas() + "/" + piscina.CapacidadMaxima);
            }
            catch (CapacidadExcedidaException ex)
            {
                Console.WriteLine("Lo sentimos: " + ex.Message);
            }
        }

        private static void ComprarEnLaTienda()
        {
            Console.WriteLine("--- TIENDA ---");
            Console.WriteLine("Comprando un refrigerio para recuperar energía después de nadar.");
        }

        // ==========================================
        // MÉTODOS AUXILIARES
        // ==========================================
        private static void PrepararParque()
        {
            parque = new Parque("Cerro Verde y Sihuatehuacán");

            sendero = new Sendero("Sendero Las Flores Misteriosas", 1200, DificultadSendero.MEDIA);
            sendero.AgregarSerVivo(new Arbol("Ceiba", "Ceiba pentandra", 25.5, 120));
            sendero.AgregarSerVivo(new Planta("Floripondio", "amarillo", EstadoPlanta.FLORECIENDO));

            piscina = new Piscina("Piscina Natural", 1.5, 26, 3);

            parque.AgregarAtraccion(sendero);
            parque.AgregarAtraccion(new Mirador("Mirador del Volcán", 2030, true));
            parque.AgregarAtraccion(piscina);
            parque.AgregarAtraccion(new Cancha("Cancha de Fútbol", "grama sintética", true));
            parque.AgregarAtraccion(new Cabaña("Cabaña Familiar", 6, 35.00));

            guia = new Guia("Carlos", "Español", 5);
        }

        private static string LeerTexto(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string texto = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(texto))
                    return texto.Trim();
                Console.WriteLine("Este dato no puede quedar vacío. Intenta de nuevo.");
            }
        }

        private static int LeerEntero(string mensaje, int minimo, int maximo)
        {
            while (true)
            {
                Console.Write(mensaje);
                int valor;
                if (int.TryParse(Console.ReadLine(), out valor) && valor >= minimo && valor <= maximo)
                    return valor;
                Console.WriteLine("Escribe un número entre " + minimo + " y " + maximo + ".");
            }
        }

        private static void Pausa()
        {
            Console.WriteLine();
            Console.Write("Presiona cualquier tecla para continuar...");
            Console.ReadKey(true);
        }
    }

    public class CapacidadExcedidaException : Exception
    {
        public CapacidadExcedidaException(string mensaje) : base(mensaje) { }
    }

    public enum TipoVisitante { NACIONAL, EXTRANJERO }
    public enum DificultadSendero { BAJA, MEDIA, ALTA }
    public enum EstadoPlanta { CRECIENDO, FLORECIENDO, MARCHITA }
}