using Ajedrez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Utilities
{
    internal class EscribirTablero
    {

        public void escribirTablero(Piezas[,] tablero)
        {
            Console.WriteLine("    A \t  B \t  C \t  D \t  E \t  F \t  G \t  H \n");
            Console.Write("1  ");
            int contadorFila = 1;
            int contador = 0;
            foreach (var pieza in tablero)
            {
                contador++;
                if (pieza != null)
                {
                    Console.Write("|" + pieza.DevolverCodigo() + "\t");
                }
                else
                {
                    Console.Write("|" + "" + "\t");
                }
                if (contador == 8)
                {
                    Console.Write("|");
                    Console.WriteLine(" \n    -------------------------------------------------------------");
                    contadorFila++;
                    if (contadorFila != 9) Console.Write($"{contadorFila}  ");
                    contador = 0;
                }
            }
        }
    }
}
