using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CerroVerdeSihuatehuacan
{
    public class Piscina : Atraccion
    {
        private double profundidad;
        private double temperatura;
        private int capacidadMaxima;
        private int visitantesActuales;

        public Piscina(string nombre, double profundidad, double temperatura, int capacidadMaxima) : base(nombre)
        {
            Profundidad = profundidad;
            Temperatura = temperatura;
            CapacidadMaxima = capacidadMaxima;
            visitantesActuales = 0;
        }

        public double Profundidad
        {
            get { return profundidad; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La profundidad debe ser mayor que cero.");
                profundidad = value;
            }
        }

        public double Temperatura
        {
            get { return temperatura; }
            set
            {
                if (value < 0 || value > 50)
                    throw new ArgumentException("La temperatura debe estar entre 0 y 50 °C.");
                temperatura = value;
            }
        }

        public int CapacidadMaxima
        {
            get { return capacidadMaxima; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La capacidad máxima debe ser mayor que cero.");
                capacidadMaxima = value;
            }
        }

        public int VisitantesActuales
        {
            get { return visitantesActuales; }
        }

        public int CalcularCantidadPersonas()
        {
            return visitantesActuales;
        }

        public bool VerificarCapacidad()
        {
            return visitantesActuales < capacidadMaxima;
        }

        public void IngresarVisitante()
        {
            if (!VerificarCapacidad())
                throw new CapacidadExcedidaException("La piscina " + Nombre + " está llena (" + capacidadMaxima + " personas).");
            visitantesActuales++;
        }

        public void SalirVisitante()
        {
            if (visitantesActuales > 0)
                visitantesActuales--;
        }

        public override string Describir()
        {
            return "Piscina " + Nombre + " de " + Profundidad + " m de profundidad a " + Temperatura + " °C, con " + visitantesActuales + "/" + capacidadMaxima + " personas.";
        }

        public override double CalcularCosto()
        {
            return 2.00;
        }
    }
}
