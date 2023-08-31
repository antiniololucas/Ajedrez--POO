using Ajedrez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Utilities
{
    internal class Movimiento
    {
        Piezas piezaActual;
        bool juegaBlanco = true;
        int FilaPiezaElegida = 0;
        int columnaPiezaElegida = 0;
        int FilaDestino = 0;
        int ColumnaDestino = 0;
        Piezas[,] tabla;

        EscribirTablero writer = new EscribirTablero();
        FinJuego finalizar = new FinJuego();
       

        public void pedirMovimiento(Piezas[,] tablero)
        {
            Console.WriteLine("\n\n Ingrese numero de fila de pieza a mover");
            try
            {
                FilaPiezaElegida = int.Parse(Console.ReadLine()) - 1;
                if (!Validaciones.validarFila(FilaPiezaElegida))
                {
                    pedirMovimiento(tablero);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Formato incorrecto, intente de nuevo");
                pedirMovimiento(tablero);
            }
            tabla = tablero;

            Console.WriteLine("Ingrese letra de columna de pieza a mover");
            columnaPiezaElegida = Validaciones.buscarLetra(Console.ReadLine().ToLower());
            if (!Validaciones.validarColumna(columnaPiezaElegida))
            {
                pedirMovimiento(tablero);
            } 

            validarPieza();
            piezaActual = tablero[FilaPiezaElegida, columnaPiezaElegida];
            validarTurno();

            piezaActual.FilaOrigen = FilaPiezaElegida;
            piezaActual.ColumnaOrigen = columnaPiezaElegida;

            Console.WriteLine("Ingrese numero de fila de destino de la pieza");
            try
            {
                FilaDestino = int.Parse(Console.ReadLine()) - 1;
                if(!Validaciones.validarFila(FilaDestino))
                {
                    pedirMovimiento(tablero);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Formato incorrecto, intente de nuevo");
                pedirMovimiento(tablero);
            }

            Console.WriteLine("Ingrese letra de columna de destino de la pieza");
            ColumnaDestino = Validaciones.buscarLetra(Console.ReadLine().ToLower());
            if (!Validaciones.validarColumna(ColumnaDestino))
            {
                pedirMovimiento(tablero);
            }
            piezaActual.FilaDestino = FilaDestino;
            piezaActual.ColumnaDestino = ColumnaDestino;

            efectuarMovimiento();
        }
        

        public void efectuarMovimiento()
        {
            if (!piezaActual.mover(tabla))
            {
                Console.WriteLine("Movimiento incorrecto");
                pedirMovimiento(tabla);
            }
            if (!finalizar.esRey(tabla, piezaActual, juegaBlanco))
            {
                escribirCambios(); 
                return;
            }
            escribirCambios();
            juegaBlanco = !juegaBlanco;
            pedirMovimiento(tabla);
        }

        public void escribirCambios()
        {
            tabla[piezaActual.FilaDestino, piezaActual.ColumnaDestino] = tabla[piezaActual.FilaOrigen, piezaActual.ColumnaOrigen];
            tabla[piezaActual.FilaOrigen, piezaActual.ColumnaOrigen] = null;

            writer.escribirTablero(tabla);
        }

        public void validarPieza()
        {
            if (tabla[FilaPiezaElegida, columnaPiezaElegida] == null)
            {
                Console.WriteLine("Posicion vacia, intente de nuevo");
                pedirMovimiento(tabla);
            }
        }

        public void validarTurno()
        {
            if (juegaBlanco && !piezaActual.SonBlancas || !juegaBlanco && piezaActual.SonBlancas)
            {
                Console.WriteLine("Turno contrario");
                pedirMovimiento(tabla);
            }
        }

    }
}