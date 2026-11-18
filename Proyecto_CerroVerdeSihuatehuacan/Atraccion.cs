using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CerroVerdeSihuatehuacan
{
    public abstract class Atraccion
    {
        protected string nombre;

        protected Atraccion(string nombre)
        {
            Nombre = nombre;
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre de la atracción no puede estar vacío.");
                nombre = value;
            }
        }

        public abstract string Describir();

        public abstract double CalcularCosto();
    }
}
