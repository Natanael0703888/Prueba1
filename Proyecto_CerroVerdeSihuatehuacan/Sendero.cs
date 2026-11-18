using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CerroVerdeSihuatehuacan
{
    public class Sendero : Atraccion
    {
        private double longitud;
        private DificultadSendero dificultad;
        private List<SerVivo> vegetacion;

        public Sendero(string nombre, double longitud, DificultadSendero dificultad) : base(nombre)
        {
            Longitud = longitud;
            Dificultad = dificultad;
            vegetacion = new List<SerVivo>();
        }

        public double Longitud
        {
            get { return longitud; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La longitud debe ser mayor que cero.");
                longitud = value;
            }
        }

        public DificultadSendero Dificultad
        {
            get { return dificultad; }
            set { dificultad = value; }
        }

        public IReadOnlyList<SerVivo> Vegetacion
        {
            get { return vegetacion; }
        }

        public void AgregarSerVivo(SerVivo serVivo)
        {
            if (serVivo == null)
                throw new ArgumentNullException("serVivo");
            vegetacion.Add(serVivo);
        }

        public override string Describir()
        {
            return "Sendero " + Nombre + " de " + Longitud + " m, dificultad " + Dificultad + ", con " + vegetacion.Count + " seres vivos a la orilla.";
        }

        public override double CalcularCosto()
        {
            return 0;
        }
    }
}
