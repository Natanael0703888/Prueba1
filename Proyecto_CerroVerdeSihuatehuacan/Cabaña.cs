using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CerroVerdeSihuatehuacan
{
    public class Cabaña : Atraccion
    {
        private int capacidadPersonas;
        private double precioNoche;

        public Cabaña(string nombre, int capacidadPersonas, double precioNoche) : base(nombre)
        {
            CapacidadPersonas = capacidadPersonas;
            PrecioNoche = precioNoche;
        }

        public int CapacidadPersonas
        {
            get { return capacidadPersonas; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La capacidad debe ser mayor que cero.");
                capacidadPersonas = value;
            }
        }

        public double PrecioNoche
        {
            get { return precioNoche; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El precio por noche no puede ser negativo.");
                precioNoche = value;
            }
        }

        public override string Describir()
        {
            return "Cabaña " + Nombre + " para " + CapacidadPersonas + " personas a $" + PrecioNoche.ToString("0.00") + " la noche.";
        }

        public override double CalcularCosto()
        {
            return PrecioNoche;
        }
    }
}
