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
            Piezas piezaActual;
            bool FinJuego = false;

            gestor.escribirTablero(tablero);
            pedirMovimiento();


            void pedirMovimiento()
            {
                Console.WriteLine("\n\n Ingrese numero de fila de pieza a mover");
                try
                {
                    FilaPiezaElegida = int.Parse(Console.ReadLine()) - 1;
                    validarFila(FilaPiezaElegida);
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato incorrecto, intente de nuevo");
                    pedirMovimiento();
                }

                Console.WriteLine("Ingrese letra de columna de pieza a mover");
                columnaPiezaElegida = gestor.buscarLetra(Console.ReadLine().ToLower());
                validarColumna(columnaPiezaElegida);

                validarPieza();

                piezaActual = tablero[FilaPiezaElegida, columnaPiezaElegida];

                validarTurno();

                piezaActual.FilaOrigen = FilaPiezaElegida;
                piezaActual.ColumnaOrigen = columnaPiezaElegida;

                Console.WriteLine("Ingrese numero de fila de destino de la pieza");
                try
                {
                    FilaDestino = int.Parse(Console.ReadLine()) - 1;
                    validarFila(FilaDestino);
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato incorrecto, intente de nuevo");
                    pedirMovimiento();
                }

                Console.WriteLine("Ingrese letra de columna de destino de la pieza");
                ColumnaDestino = gestor.buscarLetra(Console.ReadLine().ToLower());
                validarColumna(ColumnaDestino);

                piezaActual.FilaDestino = FilaDestino;
                piezaActual.ColumnaDestino = ColumnaDestino;

                esRey();
                efectuarMovimiento();
            }

            void efectuarMovimiento()
            {
                if (!piezaActual.mover(tablero))
                {
                    Console.WriteLine("Movimiento incorrecto");
                    pedirMovimiento();
                }
                tablero[FilaDestino, ColumnaDestino] = tablero[FilaPiezaElegida, columnaPiezaElegida];
                tablero[FilaPiezaElegida, columnaPiezaElegida] = null;

                gestor.escribirTablero(tablero);

                if (FinJuego)
                {
                    finalizarJuego();
                    return;
                }
                juegaBlanco = !juegaBlanco;
                pedirMovimiento();
            }

            void validarPieza()
            {
                if (tablero[FilaPiezaElegida, columnaPiezaElegida] == null)
                {
                    Console.WriteLine("Posicion vacia, intente de nuevo");
                    pedirMovimiento();
                }
            }

            void validarFila(int fila)
            {
                if(fila < 0 || fila > 7)
                {
                    Console.WriteLine("numero de fila incorrecto, intente de nuevo");
                    pedirMovimiento();
                }
            }
            void validarColumna(int columna)
            {
                if (columna == 99)
                {
                    Console.WriteLine("Formato incorrecto, intente de nuevo");
                    pedirMovimiento();
                }
            }

            void validarTurno()
            {
                if (juegaBlanco && !piezaActual.SonBlancas || !juegaBlanco && piezaActual.SonBlancas)
                {
                    Console.WriteLine("Turno contrario");
                    pedirMovimiento();
                }
            }

            void esRey()
            {
                if (tablero[FilaDestino, ColumnaDestino] != null && tablero[FilaDestino, ColumnaDestino].esRey)
                {
                    FinJuego = true;
                }
            }

            void finalizarJuego()
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
        
 }