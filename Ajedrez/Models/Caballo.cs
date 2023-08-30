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

        public override string devolverCodigo()
        {
            if (SonBlancas)
            {
                return "\u2658";
            }
            return "\u265E";
        }

        public override bool mover(Piezas[,] tablero)
        {
            throw new NotImplementedException();
        }
    }
}
