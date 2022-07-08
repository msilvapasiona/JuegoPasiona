using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jugadores;
using Barajas;
namespace ExtensionesMus
{
    static public class ExtensionesMus
    {
        public static string GanadorCartaAlta(this List<Jugador> jugadores)
        {
            for (int i = 0; i < jugadores[0].cartas.Count; i++)
            {
                (bool respuesta, string ganador) cartaAltaObtenida = CartaMasAlta(jugadores, i);

                if (cartaAltaObtenida.respuesta) return cartaAltaObtenida.ganador;

                if (i == jugadores[0].cartas.Count - 1)
                {
                    (bool respuesta, string ganador) ganador = GanadorPorMano(jugadores, i, 0);
                    if (ganador.respuesta) return ganador.ganador;
                }
            }

            return ("no hay carta alta");
        }
        public static string GanadorCartaBaja(this List<Jugador> jugadores)
        {
            for (int i = jugadores[0].cartas.Count - 1 ; i >= 0; i--)
            {
                (bool respuesta, string ganador) cartaBajaObtenida = CartaMasBaja(jugadores, i);

                if (cartaBajaObtenida.respuesta) return cartaBajaObtenida.ganador;

                if (i == 0)
                {
                    (bool respuesta, string ganador) ganador = GanadorPorMano(jugadores, i, 0);
                    if (ganador.respuesta) return ganador.ganador;
                }
            }
            return ("no hay carta baja");
        }
        public static string GanadorJuego(this List<Jugador> jugadores)
        {
            int[] puntosJugadores = RellenarPuntosJugadores(jugadores);

            if (ComprobarMenosde30(puntosJugadores))
            {
                return jugadores[GanadorJuegoMenosDe30(puntosJugadores)].Nombre;
            }
            else
            {
                return jugadores[GanadorJuegoMasDe30(puntosJugadores)].Nombre;
            }
        }
        public static string GanadorParejas(this List<Jugador> jugadores)
        {
            (bool respuesta, string nombre) ganador = ComprobacionGanadores(jugadores, 4);
            if (ganador.respuesta) return ganador.nombre + ", doble pareja.";

            ganador = ComprobacionGanadores(jugadores, 3);
            if (ganador.respuesta) return ganador.nombre + ", triple pareja.";

            ganador = ComprobacionGanadores(jugadores, 2);
            if (ganador.respuesta) return ganador.nombre + ", pareja simple.";

            return "Nadie tiene pareja.";
        }
        //Carta ALta y Carta Baja
        private static (bool respuesta, string ganador) CartaMasAlta(List<Jugador> jugadores, int index)
        {
            Jugador vacio = new Jugador("Null");
            vacio.cartas = new List<Carta>() { new Carta("n", 0), new Carta("n", 0), new Carta("n", 0), new Carta("n", 0) };
            int max = -1;
            List<Jugador> ganadores = new List<Jugador>();

            foreach (Jugador jugadorx in jugadores)
            {
                if (jugadorx.cartas[index].Numero > max)
                {
                    max = jugadorx.cartas[index].Numero;
                }
            }

            for (int i = 0; i < jugadores.Count; i++)
            {
                if (jugadores[i].cartas[index].Numero == max)
                {
                    ganadores.Add(jugadores[i]);
                    
                }
                else
                {
                    jugadores[i] = vacio;
                }
            }

            if (ganadores.Count == 1)
            {
                return (true, ganadores[0].Nombre);
            }
            return (false, "Null");
        }
        private static (bool respuesta, string ganador) CartaMasBaja(List<Jugador> jugadores, int index)
        {
            Jugador vacio = new Jugador("Null");
            vacio.cartas = new List<Carta>() { new Carta("n", 13), new Carta("n", 13), new Carta("n", 13), new Carta("n", 13) };
            int min = 13;
            List<Jugador> ganadores = new List<Jugador>();

            foreach (Jugador jugadorx in jugadores)
            {
                if (jugadorx.cartas[index].Numero < min && jugadorx.cartas[index].Numero != 0)
                {
                    min = jugadorx.cartas[index].Numero;
                }
            }

            for (int i = 0; i < jugadores.Count; i++)
            {
                if (jugadores[i].cartas[index].Numero == min)
                {
                    ganadores.Add(jugadores[i]);    
                }
                else
                {
                    jugadores[i] = vacio;
                }
            }

            if (ganadores.Count == 1)
            {
                return (true, ganadores[0].Nombre);
            }
            return (false, "Null");
        }
        private static (bool respuesta, string ganador) GanadorPorMano(List<Jugador> jugadores, int index, int referencia)
        {
            foreach (Jugador item in jugadores)
            {
                if (item.cartas[index].Numero != referencia)
                {
                    return (true, item.Nombre);
                }
            }
            return (false, "No Valido.");
        }

        //Juego
        private static int[] RellenarPuntosJugadores(List<Jugador> jugadores)
        {
            int[] puntosJugadores = new int[jugadores.Count];

            for (int i = 0; i < jugadores.Count; i++)
            {
                foreach (Carta carta in jugadores[i].cartas)
                {
                    puntosJugadores[i] += carta.Numero;
                }
            }
            return puntosJugadores;
        }
        private static bool ComprobarMenosde30(int[] puntosJugadores)
        {
            foreach (int puntos in puntosJugadores)
            {
                if ((puntos > 30 && puntos != 38 && puntos != 39 && puntos <= 40))
                {
                    return false;
                }
            }
            return true;
        }
        private static int GanadorJuegoMenosDe30(int[] puntosJugadores)
        {
            for (int i = 0; i < puntosJugadores.Length; i++)
            {
                int puntosActuales = puntosJugadores[i];
                if (puntosActuales <= 30)
                {
                    puntosJugadores[i] = 30 - puntosActuales;
                }
            }

            int min = puntosJugadores[0];

            foreach (int punto in puntosJugadores)
            {
                if (punto < min && punto >= 0)
                {
                    min = punto;
                }
            }

            for (int i = 0; i < puntosJugadores.Length; i++)
            {
                if (puntosJugadores[i] == min)
                {
                    return i;
                }
            }

            return -1;
        }
        private static int GanadorJuegoMasDe30(int[] puntosJugadores)
        {
            int[] jugadas = { 31, 32, 40, 37, 36, 35, 34, 33 };

            foreach (int puntos in jugadas)
            {
                for (int i = 0; i < puntosJugadores.Length; i++)
                {
                    if (puntos == puntosJugadores[i])
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        //Parejas
        private static (bool respuesta, int valorMaximo) ComprobacionParejas(Jugador jugador, int parejasaformadas)
        {
            if (parejasaformadas == 4)
            {
                (bool respuesta, int valorMaximo) doblePareja = ComprobacionDoblePareja(jugador);
                if (doblePareja.respuesta)
                {
                    return (doblePareja.respuesta, doblePareja.valorMaximo);
                }
            }
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
                if (contador == parejasaformadas)
                {
                    return (true, cartax.Numero);
                }
            }
            return (false, 0);
        }
        private static (bool respuesta, int valorMaximo) ComprobacionDoblePareja(Jugador jugador)
        {
            int[] parejaFormada = new int[2] { 0, 0 };

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
                    parejaFormada[0] = cartax.Numero;
                }
                break;
            }

            foreach (Carta cartax in jugador.cartas)
            {
                int contador = 1;
                foreach (Carta cartay in jugador.cartas)
                {
                    if (cartax.Numero == cartay.Numero && !cartax.Palo.Equals(cartay.Palo) && cartax.Numero != parejaFormada[0])
                    {
                        contador++;
                    }
                }
                if (contador == 2)
                {
                    parejaFormada[1] = cartax.Numero;
                }
            }


            if (parejaFormada[0] != 0 && parejaFormada[1] != 0)
            {
                return parejaFormada[0] > parejaFormada[1] ? (true, parejaFormada[0]) : (true, parejaFormada[1]);
            }


            return (false, 0);
        }
        private static (bool respuesta, string nombre) ComprobacionGanadores(List<Jugador> jugadores, int parejaFormada)
        {
            (bool respuesta, int valorMaximo)[] parejasJugadores = new (bool respuesta, int valorMaximo)[jugadores.Count];

            for (int i = 0; i < parejasJugadores.Length; i++)
            {
                parejasJugadores[i] = ComprobacionParejas(jugadores[i], parejaFormada);
            }
            int max = -1;

            foreach (var item in parejasJugadores)
            {
                if (item.respuesta && item.valorMaximo > max)
                {
                    max = item.valorMaximo;
                }
            }

            for (int i = 0; i < parejasJugadores.Length; i++)
            {
                if (parejasJugadores[i].respuesta && parejasJugadores[i].valorMaximo == max)
                {
                    return (true, jugadores[i].Nombre);
                }
            }
            return (false, "null");
        }
    }
}
