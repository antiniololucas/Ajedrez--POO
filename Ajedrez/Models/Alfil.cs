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
        public override string devolverCodigo()
        {
            if (SonBlancas)
            {
                return "\u2657";
            }
            return "\u265D";
        }

        public override bool mover(Piezas[,] tablero)
        {
            throw new NotImplementedException();
        }
    }
}
