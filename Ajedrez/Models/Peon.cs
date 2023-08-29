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
        
        public override string devolverCodigo()
        {
            if (SonBlancas)
            {
                return "\u2659";
            }
            return "\u265F";
        }


    }
}
