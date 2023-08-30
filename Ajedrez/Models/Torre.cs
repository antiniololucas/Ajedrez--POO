using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Models
{
    internal class Torre : Piezas
    {
        public Torre(bool validacion)
        {
            this.SonBlancas = validacion;
        }
        public override string DevolverCodigo()
        {
            if (SonBlancas)
            {
                return "\u2656";
            }
            return "\u265C";
        }

        public override bool mover(Piezas[,] tablero)
        {
            if (tablero[FilaDestino, ColumnaDestino] != null)
            {
               if (!validarComer(tablero)) return false;
            }

            if (FilaOrigen == FilaDestino)
            {
                return movimientoVertical(tablero);
            }

            if(ColumnaDestino == ColumnaOrigen)
            {
                return movimientoHorizontal(tablero);
            }

            return false;
           
        }

        private bool movimientoVertical(Piezas[,] tablero)
        {
            for (int i = Math.Min(ColumnaOrigen, ColumnaDestino); i < Math.Max(ColumnaOrigen, ColumnaDestino); i++)
            {
                if (i == ColumnaDestino || i== ColumnaOrigen ) continue;

                if (tablero[FilaOrigen, i] != null)
                {
                    return false;
                }
            }
            return true;
        }

        private bool movimientoHorizontal(Piezas[,] tablero)
        {
            for(int x = Math.Min(FilaOrigen, FilaDestino); x < Math.Max(FilaOrigen, FilaDestino); x++) 
            {
                if( x == FilaDestino || x == FilaOrigen ) continue;
                if (tablero[x, ColumnaOrigen] != null)
                {
                    return false;
                }   
            }
            return true;
        }


    }
}
