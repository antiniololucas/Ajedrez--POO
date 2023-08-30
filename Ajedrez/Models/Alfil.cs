using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Models
{
    internal class Alfil : Piezas
    {
        public Alfil(bool validacion)
        {
            this.SonBlancas = validacion;
        }
        public override string DevolverCodigo()
        {
            if (SonBlancas)
            {
                return "\u2657";
            }
            return "\u265D";
        }

        public override bool mover(Piezas[,] tablero)
        {
            //Solo importa si baja o sube. 

            if (tablero[FilaDestino, ColumnaDestino] != null)
            {
                if (!validarComer(tablero)) return false;
            }

            if(FilaDestino > FilaOrigen && ColumnaDestino > ColumnaOrigen) {return DiagonalAbajoDer(tablero); }
            if(FilaDestino > FilaOrigen && ColumnaDestino < ColumnaOrigen) {return DiagonalAbajoIzq(tablero); }
            if(FilaDestino < FilaOrigen && ColumnaDestino > ColumnaOrigen) {return DiagonalArribaDer(tablero);}
            if(FilaDestino < FilaOrigen && ColumnaDestino < ColumnaOrigen) {return DiagonalArribaIzq(tablero);}
            return false;
        }

        private bool DiagonalArribaIzq(Piezas[,] tablero)
        {
            int x = ColumnaOrigen - 1;
            for (int i = FilaOrigen; i < FilaDestino; i--)
            {
                if (tablero[i, x] != null)
                {
                    return false;
                }
                x++;
            }
            return true;
        }

        private bool DiagonalArribaDer(Piezas[,] tablero)
        {
            int x = ColumnaOrigen + 1;
            for(int i = FilaOrigen; i < FilaDestino; i--)
            {
                if (tablero[i, x] != null)
                {
                    return false;
                }
                x++;
            }
            return true;
        }

        private bool DiagonalAbajoIzq(Piezas[,] tablero)
        {
            int x = ColumnaOrigen - 1;
            for (int i = FilaOrigen + 1; i < FilaDestino; i++)
            {
                if (tablero[i, x] != null)
                {
                    return false;
                }
                x--;
            }
            return true;
        }

        private bool DiagonalAbajoDer(Piezas[,] tablero)
        {
            int x = ColumnaOrigen+1;
            for(int i = FilaOrigen+1; i < FilaDestino; i++)
            {
               if( tablero[i, x] != null)
                {
                    return false;
                }
                x ++;
            }
            return true;
        }

        private bool validarComer(Piezas[,] tablero)
        {
            if (tablero[FilaDestino, ColumnaDestino].SonBlancas == this.SonBlancas)
            {
                return false;
            }
            return true;
        }
    }
}
