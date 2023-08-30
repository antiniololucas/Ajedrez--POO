using Ajedrez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Utilities
{
    internal class GestorJuego
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
                    Console.Write("|" + pieza.devolverCodigo() + "\t");
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

        public int buscarLetra(string filaPiezaElegida)
        {
            switch (filaPiezaElegida)
            {
                case "a": return 0;
                case "b": return 1;
                case "c": return 2;
                case "d": return 3;
                case "e": return 4;
                case "f": return 5;
                case "g": return 6;
                case "h": return 7;
                default: return 99;
            }
        }


        

        
    }
}
