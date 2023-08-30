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

        public override string devolverCodigo()
        {
            if (SonBlancas)
            {
                return "\u2655";
            }
            return "\u265B";
        }

        public override bool mover(Piezas[,] tablero)
        {
            throw new NotImplementedException();
        }
    }
}
