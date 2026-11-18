using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CerroVerdeSihuatehuacan
{
    public class Planta : SerVivo
    {
        private string color;
        private EstadoPlanta estado;

        public Planta(string nombre, string color, EstadoPlanta estado) : base(nombre)
        {
            Color = color;
            Estado = estado;
        }

        public string Color
        {
            get { return color; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El color no puede estar vacio.");
                color = value;
            }
        }

        public EstadoPlanta Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public override void Crecer()
        {
            Estado = EstadoPlanta.CRECIENDO;
            Console.WriteLine("La planta " + Nombre + " esta creciendo.");
        }

        public string Florecer()
        {
            Estado = EstadoPlanta.FLORECIENDO;
            return "La planta " + Nombre + " florecio con flores de color " + Color + ".";
        }
    }
}
