using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Models
{
    internal class Rey : Piezas
    {
        public Rey(bool validacion)
        {
            this.SonBlancas = validacion;
        }

        public override string devolverCodigo()
        {
            if (SonBlancas)
            {
                return "\u2654";
            }
            return "\u265A";
        }

        public override bool mover(Piezas[,] tablero)
        {
            throw new NotImplementedException();
        }
    }
}
