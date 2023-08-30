using Ajedrez.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Models
{
    public abstract class Piezas : Imover
    {
        public abstract string DevolverCodigo();

        public abstract bool mover(Piezas[,] tablero);

        public bool SonBlancas { get; set; }
        public int FilaOrigen {  get; set; }
        public int ColumnaOrigen { get; set; }
        public int FilaDestino { get; set; }
        public int ColumnaDestino { get; set; }
        public bool esRey {  get; set; }

        public bool validarComer(Piezas[,] tablero)
        {
            if (tablero[FilaDestino, ColumnaDestino].SonBlancas == this.SonBlancas)
            {
                return false;
            }
            return true;
        }
    }
}
