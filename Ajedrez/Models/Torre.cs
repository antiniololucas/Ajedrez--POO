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
        public override string devolverCodigo()
        {
            if (SonBlancas)
            {
                return "\u2656";
            }
            return "\u265C";
        }
    }
}
