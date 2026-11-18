using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CerroVerdeSihuatehuacan
{
    public class Guia : Persona
    {
        private string idioma;
        private int añosExperiencia;

        public Guia(string nombre, string idioma, int añosExperiencia) : base(nombre)
        {
            Idioma = idioma;
            AñosExperiencia = añosExperiencia;
        }

        public string Idioma
        {
            get { return idioma; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El idioma no puede estar vacío.");
                idioma = value;
            }
        }

        public int AñosExperiencia
        {
            get { return añosExperiencia; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Los años de experiencia no pueden ser negativos.");
                añosExperiencia = value;
            }
        }

        public void Explicar(Atraccion atraccion)
        {
            Console.WriteLine("Guia " + Nombre + " (" + Idioma + "): " + atraccion.Describir());
        }

        public void GuiarGrupo()
        {
            Console.WriteLine("Guia " + Nombre + " da la bienvenida y guía al grupo por el recorrido.");
        }
    }
}
