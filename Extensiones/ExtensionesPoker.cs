using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barajas;
using Jugadores;

namespace ExtensionesPoker
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

        public static int Trio(this Jugador jugador)
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
                if (contador == 3)
                {
                    return cartax.Numero;
                }
            }
            return -1;
        }

        public static int Pareja(this Jugador jugador)
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
                if (contador == 2)
                {
                    return cartax.Numero;
                }
            }
            return -1;
        }

        public static int SegundaPareja(this Jugador jugador, int distinto)
        {
            foreach (Carta cartax in jugador.cartas)
            {
                int contador = 1;
                foreach (Carta cartay in jugador.cartas)
                {
                    if (cartax.Numero == cartay.Numero && !cartax.Palo.Equals(cartay.Palo) && cartax.Numero != distinto)
                    {
                        contador++;
                    }
                }
                if (contador == 2)
                {
                    return cartax.Numero;
                }
            }
            return -1;
        }
    }
}

