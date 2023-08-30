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

            GestorJuego gestor = new GestorJuego();
            bool juegaBlanco = true;
            int FilaPiezaElegida = 0;
            int columnaPiezaElegida = 0;
            int FilaDestino = 0;
            int ColumnaDestino = 0;


            gestor.escribirTablero(tablero);
            pedirMovimiento();


            void pedirMovimiento()
            {
                Console.WriteLine("\n\n Ingrese numero de fila de pieza a mover");
                FilaPiezaElegida = int.Parse(Console.ReadLine()) - 1;

                Console.WriteLine("Ingrese letra de columna de pieza a mover");
                columnaPiezaElegida = gestor.buscarLetra(Console.ReadLine().ToLower());

                if (!gestor.validarTurno(tablero[FilaPiezaElegida, columnaPiezaElegida], juegaBlanco))
                {
                    Console.WriteLine("Turno contrario");
                    pedirMovimiento();
                }

                tablero[FilaPiezaElegida, columnaPiezaElegida].FilaOrigen = FilaPiezaElegida;
                tablero[FilaPiezaElegida, columnaPiezaElegida].ColumnaOrigen = columnaPiezaElegida;


                Console.WriteLine("Ingrese numero de fila de destino de la pieza");
                FilaDestino = int.Parse(Console.ReadLine()) - 1;
                tablero[FilaPiezaElegida, columnaPiezaElegida].FilaDestino = FilaDestino;

                Console.WriteLine("Ingrese letra de columna de destino de la pieza");
                ColumnaDestino = gestor.buscarLetra(Console.ReadLine().ToLower());
                tablero[FilaPiezaElegida, columnaPiezaElegida].ColumnaDestino = ColumnaDestino;

                validarMovimiento();
            }

            void validarMovimiento()
            {
                if (!tablero[FilaPiezaElegida, columnaPiezaElegida].mover(tablero))
                {
                    Console.WriteLine("Movimiento incorrecto");
                }
                tablero[FilaDestino, ColumnaDestino] = tablero[FilaPiezaElegida, columnaPiezaElegida];
                tablero[FilaPiezaElegida, columnaPiezaElegida] = null;
                juegaBlanco = !juegaBlanco;
                gestor.escribirTablero(tablero);
                pedirMovimiento();
            }

        }
    }
}