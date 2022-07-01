using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barajas;
using Jugadores;

namespace Extensiones
{
    static public class ExtensionesPoker
    {
        public static int MaxPoker(this Jugador jugador)
        {
            foreach (Carta cartax in jugador.cartas)
            {
                int contador = 1;
                foreach (Carta cartay in jugador.cartas)
                {
                    if (cartax.Numero == cartay.Numero && !cartax.Palo.Equals(cartay.Palo))
                    {
                        contador++;
                    }
                }
                if (contador == 4)
                {
                    return cartax.Numero;
                }
            }
            return -1;
        }
    }
}
