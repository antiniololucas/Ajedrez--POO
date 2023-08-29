using Ajedrez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Piezas[,] tablero =
            {
                {new Torre(false) , new Caballo(false), new Alfil(false), new Rey(false ) , new Reina(false) , new Alfil(false) , new Caballo(false), new Torre(false) },
                {new Peon(false)  , new Peon(false)   , new Peon(false) , new Peon(false) , new Peon(false)  , new Peon(false)  , new Peon(false)   , new Peon(false)  },
                {null             , null              , null            , null            , null             , null             , null              ,   null           },
                {null             , null              , null            , null            , null             , null             , null              ,   null           },
                {null             , null              , null            , null            , null             , null             , null              ,   null           },
                {null             , null              , null            , null            , null             , null             , null              ,   null           },
                {new Peon(true)   , new Peon(true)    , new Peon(true)  , new Peon(true)  , new Peon(true)  , new Peon(false)   , new Peon(true)    , new Peon(true)   },
                {new Torre(true)  , new Caballo(true),  new Alfil(true),  new Rey( true ) , new Reina(true)  , new Alfil(true)  , new Caballo(true),  new Torre(true)  },
            };

            escribirTablero();
            Console.ReadKey();
            
           void escribirTablero()
            {
                int contador = 0;
                foreach (var pieza in tablero)
                {
                    contador++;
                    if (pieza != null)
                    {
                        Console.Write("|" + pieza.devolverCodigo() + "\t");
                    }
                    else
                    {
                        Console.Write("|" + ""  + "\t");
                    }
                    if (contador == 8)
                    {
                        Console.WriteLine("\n -----------------------------------------------------------------");
                        contador = 0;
                    } 
                }
            }


        }
    }
}