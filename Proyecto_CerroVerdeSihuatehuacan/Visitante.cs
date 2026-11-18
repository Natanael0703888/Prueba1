using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CerroVerdeSihuatehuacan
{
    public class Visitante : Persona
    {
        private int edad;
        private TipoVisitante tipo;
        private List<Boleto> boletos;

        public Visitante(string nombre, int edad, TipoVisitante tipo) : base(nombre)
        {
            Edad = edad;
            Tipo = tipo;
            boletos = new List<Boleto>();
        }

        public int Edad
        {
            get { return edad; }
            set
            {
                if (value < 0 || value > 90)
                    throw new ArgumentException("La edad debe estar entre 0 y 90.");
                edad = value;
            }
        }

        public TipoVisitante Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public IReadOnlyList<Boleto> Boletos
        {
            get { return boletos; }
        }

        public void Pagar(double monto)
        {
        }

        public void PagarBoleto(Boleto boleto)
        {
            double costo = boleto.CalcularPrecioEntrada(this);
            Pagar(costo);
            boletos.Add(boleto);
            Console.WriteLine(Nombre + " adquirio su boleto por un valor de $" + costo.ToString("0.00") + ".");
        }

        public void TomarFoto(Atraccion atraccion)
        {
            Console.WriteLine(Nombre + " tomo una foto en: " + atraccion.Nombre + ".");
        }
    }

}
