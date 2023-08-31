using Ajedrez.Models;
using Ajedrez.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Ajedrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            IniciaJuego iniciar = new IniciaJuego();
            iniciar.jugar();
        }
    }
        
 }