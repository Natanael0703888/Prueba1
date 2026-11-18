using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CerroVerdeSihuatehuacan
{
    public class Parque
    {
        private string nombre;
        private List<Atraccion> listaAtracciones;
        private List<Visitante> listaVisitantes;

        public Parque(string nombre)
        {
            Nombre = nombre;
            listaAtracciones = new List<Atraccion>();
            listaVisitantes = new List<Visitante>();
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre del parque no puede estar vacio.");
                nombre = value;
            }
        }

        public IReadOnlyList<Atraccion> ListaAtracciones
        {
            get { return listaAtracciones; }
        }

        public IReadOnlyList<Visitante> ListaVisitantes
        {
            get { return listaVisitantes; }
        }

        public void AgregarAtraccion(Atraccion atraccion)
        {
            if (atraccion == null)
                throw new ArgumentNullException("atraccion");
            listaAtracciones.Add(atraccion);
        }

        public void RecibirVisitante(Visitante visitante)
        {
            if (visitante == null)
                throw new ArgumentNullException("visitante");
            if (visitante.Boletos.Count == 0)
                throw new InvalidOperationException(visitante.Nombre + " no puede ingresar sin boleto.");
            listaVisitantes.Add(visitante);
            Console.WriteLine(visitante.Nombre + " ingreso al parque " + Nombre + ".");
        }
    }
}
