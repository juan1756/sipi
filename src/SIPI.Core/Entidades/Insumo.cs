using System.Collections.Generic;

namespace SIPI.Core.Entidades
{
    public class Insumo
    {
        private Insumo()
        {
        }

        public Insumo(Pedido pedido, int numero, decimal precio, int tamano)
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