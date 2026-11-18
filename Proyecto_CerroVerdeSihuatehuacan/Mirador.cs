using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CerroVerdeSihuatehuacan
{
    public class Mirador : Atraccion
    {
        private double altitud;
        private bool tieneColumpio;

        public Mirador(string nombre, double altitud, bool tieneColumpio) : base(nombre)
        {
            Altitud = altitud;
            TieneColumpio = tieneColumpio;
        }

        public double Altitud
        {
            get { return altitud; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("La altitud no puede ser negativa.");
                altitud = value;
            }
        }

        public bool TieneColumpio
        {
            get { return tieneColumpio; }
            set { tieneColumpio = value; }
        }

        public override string Describir()
        {
            string columpio = TieneColumpio ? "con columpio" : "sin columpio";
            return "Mirador " + Nombre + " a " + Altitud + " metros, " + columpio + ", con vista panorámica.";
        }

        public override double CalcularCosto()
        {
            return 0;
        }
    }
}
