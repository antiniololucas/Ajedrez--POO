using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Models
{
    public abstract class Piezas
    {
        public abstract string devolverCodigo();
        public bool SonBlancas { get; set; }
    }
}
