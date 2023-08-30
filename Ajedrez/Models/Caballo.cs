using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Models
{
    internal class Caballo : Piezas
    {
        public Caballo(bool validacion)
        {
            this.SonBlancas = validacion;
        }

        public override string DevolverCodigo()
        {
            if (SonBlancas)
            {
                return "\u2658";
            }
            return "\u265E";
        }

        public override bool mover(Piezas[,] tablero)
        {
            if (tablero[FilaDestino, ColumnaDestino] != null)
            {
                if (!validarComer(tablero)) return false;
            }

            if (Math.Max(FilaOrigen,FilaDestino) - Math.Min(FilaOrigen,FilaDestino) == 1)
            {
               return validacionPrimerMov();
            }

            if(Math.Max(FilaOrigen, FilaDestino) - Math.Min(FilaOrigen, FilaDestino) == 2)
            {
                return validacionSegundoMov();
            }
            return false;
        }

        private bool validacionSegundoMov()
        {
            if (ColumnaDestino - ColumnaOrigen == 1 || ColumnaDestino - ColumnaOrigen == -1)
            {
                return true;
            }
            return false;
        }

        private bool validacionPrimerMov()
        {
            if (ColumnaDestino - ColumnaOrigen == 2 || ColumnaDestino - ColumnaOrigen == -2)
            {
                return true;
            }
            return false;
        }
    }
}
