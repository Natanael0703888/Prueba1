using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CerroVerdeSihuatehuacan
{
    public class Arbol : SerVivo
    {
        private string especie;
        private double altura;
        private int edadAproximada;

        public Arbol(string nombre, string especie, double altura, int edadAproximada) : base(nombre)
        {
            Especie = especie;
            Altura = altura;
            EdadAproximada = edadAproximada;
        }

        public string Especie
        {
            get { return especie; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La especie no puede estar vacia.");
                especie = value;
            }
        }

        public double Altura
        {
            get { return altura; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("La altura no puede ser negativa.");
                altura = value;
            }
        }

        public int EdadAproximada
        {
            get { return edadAproximada; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("La edad no puede ser negativa.");
                edadAproximada = value;
            }
        }

        public override void Crecer()
        {
            Altura += 0.5;
            Console.WriteLine("El arbol " + Nombre + " crecio y ahora mide " + Altura + " m.");
        }

        public string DarSombra()
        {
            return "El arbol " + Nombre + " (" + Especie + ") da sombra a los visitantes.";
        }
    }
}
