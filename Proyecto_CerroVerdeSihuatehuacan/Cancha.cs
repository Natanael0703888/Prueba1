using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CerroVerdeSihuatehuacan
{
    public class Cancha : Atraccion
    {
        private string superficie;
        private bool cercoPerimetral;

        public Cancha(string nombre, string superficie, bool cercoPerimetral) : base(nombre)
        {
            Superficie = superficie;
            CercoPerimetral = cercoPerimetral;
        }

        public string Superficie
        {
            get { return superficie; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La superficie no puede estar vacía.");
                superficie = value;
            }
        }

        public bool CercoPerimetral
        {
            get { return cercoPerimetral; }
            set { cercoPerimetral = value; }
        }

        public override string Describir()
        {
            string cerco = CercoPerimetral ? "con cerco perimetral" : "sin cerco perimetral";
            return "Cancha " + Nombre + " de " + Superficie + ", " + cerco + ".";
        }

        public override double CalcularCosto()
        {
            return 5.00;
        }
    }
}
