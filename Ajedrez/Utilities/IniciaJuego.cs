using Ajedrez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Utilities
{
    internal class IniciaJuego
    {
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

        EscribirTablero writer = new EscribirTablero();
        Movimiento pedir = new Movimiento();

        internal void jugar()
        {
            writer.escribirTablero(tablero);
            pedir.pedirMovimiento(tablero);
        }
    }
}
