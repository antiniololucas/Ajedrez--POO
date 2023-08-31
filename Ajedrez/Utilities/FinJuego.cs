using Ajedrez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Utilities
{
    internal class FinJuego
    {
        public bool esRey(Piezas[,] tablero , Piezas piezaActual , bool juegaBlanco)
        {
            if (tablero[piezaActual.FilaDestino, piezaActual.ColumnaDestino] != null && tablero[piezaActual.FilaDestino, piezaActual.ColumnaDestino].esRey)
            {
                finalizarJuego(juegaBlanco);
                return false;
            }
            return true;
        }

        void finalizarJuego(bool juegaBlanco)
        {
            if (juegaBlanco)
            {
                Console.WriteLine("Fin del juego, Ganador : Jugador blancas");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Fin del juego, Ganador : Jugador negras");
            Console.ReadKey();
        }
    }
}
