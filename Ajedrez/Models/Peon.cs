using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Models
{
    internal class Peon : Piezas
    {
        public Peon(bool validacion)
        {
            this.SonBlancas = validacion;
        }
        
        public override string DevolverCodigo()
        {
            return SonBlancas ? "\u2659" : "\u265F";
        }

        public override bool mover(Piezas[,] tablero)
        {
            return SonBlancas ? movimientoBlanco(tablero) : movimientoNegro(tablero);
        }

        private bool validarComer(Piezas[,]tablero)
        {
            if( this.SonBlancas == tablero[FilaDestino, ColumnaDestino].SonBlancas)
            {
                return false;
            }
            return true;
        }

        private bool movimientoNegro(Piezas[,] tablero)
        {
            if (tablero[FilaDestino, ColumnaDestino] != null)
            {
               return validarComer(tablero) ? comerNegro(tablero) : false;
            }

            if (ColumnaOrigen != ColumnaDestino || FilaDestino - FilaOrigen != 1)
            {
                return false;
            }
            return true;
        }

        private bool comerNegro(Piezas[,] tablero)
        {
            if (FilaDestino - FilaOrigen != 1 || ColumnaDestino.CompareTo(ColumnaOrigen) > 1)
            {
                return false;
            }
            return true;
        }

        private bool movimientoBlanco(Piezas[,] tablero)
        {
            if (tablero[FilaDestino, ColumnaDestino] != null)
            {
                return validarComer(tablero) ? comerBlanco(tablero) : false;
            }
            if (ColumnaOrigen != ColumnaDestino || FilaOrigen - FilaDestino != 1)
            {

                return false;
            }
            return true;
        }

        private bool comerBlanco(Piezas[,] tablero)
        {
            if (FilaOrigen - FilaDestino != 1 || ColumnaDestino.CompareTo(ColumnaOrigen) > 1)
            {
                return false;
            }
            return true;
        }
    }
}
