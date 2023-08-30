using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Models
{
    internal class Reina : Piezas
    {
        public Reina(bool validacion)
        {
            this.SonBlancas = validacion;
        }

        public override string DevolverCodigo()
        {
            if (SonBlancas)
            {
                return "\u2655";
            }
            return "\u265B";
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

            if (ColumnaDestino == ColumnaOrigen)
            {
                return movimientoHorizontal(tablero);
            }

            if (FilaDestino > FilaOrigen && ColumnaDestino > ColumnaOrigen) { return DiagonalAbajoDer(tablero); }
            if (FilaDestino > FilaOrigen && ColumnaDestino < ColumnaOrigen) { return DiagonalAbajoIzq(tablero); }
            if (FilaDestino < FilaOrigen && ColumnaDestino > ColumnaOrigen) { return DiagonalArribaDer(tablero); }
            if (FilaDestino < FilaOrigen && ColumnaDestino < ColumnaOrigen) { return DiagonalArribaIzq(tablero); }

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
            int x = ColumnaOrigen + 1;
            for (int i = FilaOrigen + 1; i < FilaDestino; i++)
            {
                if (tablero[i, x] != null)
                {
                    return false;
                }
                x++;
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

        private bool movimientoVertical(Piezas[,] tablero)
        {
            for (int i = Math.Min(ColumnaOrigen, ColumnaDestino); i < Math.Max(ColumnaOrigen, ColumnaDestino); i++)
            {
                if (i == ColumnaDestino || i == ColumnaOrigen) continue;

                if (tablero[FilaOrigen, i] != null)
                {
                    return false;
                }
            }
            return true;
        }

        private bool movimientoHorizontal(Piezas[,] tablero)
        {
            for (int x = Math.Min(FilaOrigen, FilaDestino); x < Math.Max(FilaOrigen, FilaDestino); x++)
            {
                if (x == FilaDestino || x == FilaOrigen) continue;
                if (tablero[x, ColumnaOrigen] != null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
