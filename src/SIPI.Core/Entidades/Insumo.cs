using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SIPI.Core.Entidades
{
    public class Insumo
    {
        protected Insumo()
        {
            Medios = new Collection<MedioAudiovisual>();
        }

        public Insumo(Pedido pedido, int numero, decimal precio, int tamano)
            : this()
        {
            Pedido = pedido;
            Numero = numero;
            Precio = precio;
            Tamano = tamano;
        }

        public int PedidoNumero { get; private set; }

        public int Numero { get; private set; }

        public decimal Precio { get; private set; }

        public virtual Pedido Pedido { get; private set; }

        public virtual ICollection<MedioAudiovisual> Medios { get; private set; }

        public int Tamano { get; private set; }

        public bool SoportaMedio(MedioAudiovisual medio)
        {
            return Tamano >= Medios.Sum(x => x.Tamano) + medio.Tamano;
        }

        internal void AgregarMedio(MedioAudiovisual medio)
        {
            if (!SoportaMedio(medio))
                throw new InsumoNoSoportaMedioException();

            Medios.Add(medio);
        }

        public class InsumoNoSoportaMedioException : Exception
        {
            public InsumoNoSoportaMedioException()
                :base("El insumo no soporta el medio que se quiere agregar")
            {

            }
        }
    }
}