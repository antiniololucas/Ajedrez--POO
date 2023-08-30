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
            if(Math.Max(FilaDestino, FilaOrigen).CompareTo(Math.Min(FilaOrigen, FilaDestino)) != 1 || Math.Max(ColumnaOrigen,ColumnaDestino).CompareTo(Math.Min(ColumnaOrigen,ColumnaDestino)) > 1)
            {
                return false;
            }
            if (tablero[FilaDestino, ColumnaDestino]!= null && tablero[FilaDestino,ColumnaDestino].SonBlancas == this.SonBlancas)
            {
                return false;
            }
            return true;
        }
    }
}
