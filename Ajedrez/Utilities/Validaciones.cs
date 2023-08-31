using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Utilities
{
    static class Validaciones
    {
         public static bool validarFila(int fila)
        {
            if (fila < 0 || fila > 7)
            {
                Console.WriteLine("numero de fila incorrecto, intente de nuevo");
                return false;
            }
            return true;
        }

         public static bool validarColumna(int columna)
        {
            if (columna == 99)
            {
                Console.WriteLine("Formato incorrecto, intente de nuevo");
                return false;
            }
            return true;
        }

         public static int buscarLetra(string filaPiezaElegida)
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
