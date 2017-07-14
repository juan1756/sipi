using System.Collections.Generic;
using System.Collections.ObjectModel;

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
    }
}