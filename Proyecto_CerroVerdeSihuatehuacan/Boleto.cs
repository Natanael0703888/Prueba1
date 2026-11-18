using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CerroVerdeSihuatehuacan
{
    public class Boleto
    {
        private double precioBase;
        private DateTime fechaEmision;
        private DateTime fechaValidez;

        public Boleto(double precioBase, DateTime fechaEmision, DateTime fechaValidez)
        {
            PrecioBase = precioBase;
            FechaEmision = fechaEmision;
            FechaValidez = fechaValidez;
        }

        public double PrecioBase
        {
            get { return precioBase; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El precio base no puede ser negativo.");
                precioBase = value;
            }
        }

        public DateTime FechaEmision
        {
            get { return fechaEmision; }
            set { fechaEmision = value; }
        }

        public DateTime FechaValidez
        {
            get { return fechaValidez; }
            set
            {
                if (value < fechaEmision)
                    throw new ArgumentException("La fecha de validez no puede ser anterior a la emisión.");
                fechaValidez = value;
            }
        }

        public bool EstaVigente()
        {
            DateTime ahora = DateTime.Now;
            return ahora >= FechaEmision && ahora <= FechaValidez;
        }

        public bool Validar()
        {
            return EstaVigente();
        }

        public bool EsGratis(Visitante visitante)
        {
            return visitante.Edad >= 60;
        }

        public double CalcularPrecioEntrada(Visitante visitante)
        {
            if (EsGratis(visitante))
                return 0;
            if (visitante.Tipo == TipoVisitante.EXTRANJERO)
                return PrecioBase * 2;
            return PrecioBase;
        }
    }
}
