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
        //EscaleraReal
        public static (bool respuesta, string ganador) GanadorEscaleraReal(this List<Jugador> jugadores)
        {
            List<Jugador> jugadoresConEscaleraReal = new List<Jugador>();
            foreach (Jugador jugador in jugadores)
            {
                List<Carta> escaleraReferencia = new List<Carta>();
                string paloReferencia = jugador.cartas[0].Palo;

                for (int i = 14; i >= 10; i--)
                {
                    escaleraReferencia.Add(new Carta(paloReferencia, i));
                }

                if (escaleraReferencia.SequenceEqual(jugador.cartas))
                {
                    jugadoresConEscaleraReal.Add(jugador);
                }

            }
            if (jugadoresConEscaleraReal.Count >= 1)
            {
                return (true, jugadoresConEscaleraReal[0].Nombre + ",gana con escalera real.");
            }
            return (false, "Null");
        }
        //EscaleraColor
        public static (bool respuesta, string ganador) GanadorEscaleraColor(this List<Jugador> jugadores)
        {
            List<Jugador> jugadoresConEscaleraColor = new List<Jugador>();
            foreach (Jugador jugador in jugadores)
            {
                List<Carta> escaleraReferencia = new List<Carta>();
                string paloReferencia = jugador.cartas[0].Palo;

                int valorReferencia = jugador.cartas[0].Numero;

                for (int i = 0; i < 5; i++, valorReferencia--)
                {
                    escaleraReferencia.Add(new Carta(paloReferencia, valorReferencia));
                }

                if (escaleraReferencia.SequenceEqual(jugador.cartas))
                {
                    jugadoresConEscaleraColor.Add(jugador);
                }

            }
            if (jugadoresConEscaleraColor.Count == 1)
            {
                return (true, jugadoresConEscaleraColor[0].Nombre + ", gana con escalera de color.");
            }
            else if (jugadoresConEscaleraColor.Count > 1)
            {
                return (true, jugadoresConEscaleraColor.GanadorCartaAlta() + ", gana con escalera de color.");
            }
            return (false, "Null");
        }
        //Poker
        public static (bool respuesta, string ganador) GanadorPoker(this List<Jugador> jugadores)
        {
            List<Jugador> jugadoresConPoker = new List<Jugador>();
            int max = -1;
            foreach (Jugador jugador in jugadores)
            {
                if (jugador.Pareja(4) > max)
                {
                    jugadoresConPoker.Add(jugador);
                }
            }

            if (jugadoresConPoker.Count == 1)
            {
                return (true, jugadoresConPoker[0].Nombre + ", gana con Poker.");
            }
            return jugadoresConPoker.Count > 1 ? DesempatePoker(jugadoresConPoker) : (false, "Null");
        }
        //Full
        public static (bool respuesta, string nombre) GanadorFull(this List<Jugador> jugadores)
        {
            List<Jugador> jugadoresConFull = new List<Jugador>();
            foreach (Jugador jugador in jugadores)
            {
                if (jugador.Pareja(3) != -1 && jugador.SegundaPareja(jugador.Pareja(3)) != -1)
                {
                    jugadoresConFull.Add(jugador);
                }
            }

            if (jugadoresConFull.Count == 1)
            {
                return (true, jugadoresConFull[0].Nombre + ", gana con Full.");
            }
            else if (jugadoresConFull.Count > 1)
            {
                (bool respuesta, string ganador) desempateGanador = DesempateFullyTrio(jugadoresConFull);
                return (desempateGanador.respuesta, desempateGanador.ganador + ", gana con Full.");
            }
            return (false, "Null");
        }
        //Color
        public static (bool respuesta, string ganador) GanadorColor(this List<Jugador> jugadores)
        {
            List<Jugador> jugadoresConColor = new List<Jugador>();
            foreach (Jugador jugador in jugadores)
            {
                bool tieneColor = true;

                string paloReferencia = jugador.cartas[0].Palo;

                foreach (Carta carta in jugador.cartas)
                {
                    if (!(carta.Palo.Equals(paloReferencia)))
                    {
                        tieneColor = false;
                    }
                }

                if (tieneColor == true)
                {
                    jugadoresConColor.Add(jugador);
                }
            }
            if (jugadoresConColor.Count == 1)
            {
                return (true, jugadoresConColor[0].Nombre + ", gana con Color.");
            }
            else if (jugadoresConColor.Count > 1)
            {
                return (true, jugadoresConColor.GanadorCartaAlta() + ", gana con Color.");
            }
            return (false, "Null");
        }
        //Escalera
        public static (bool respuesta, string ganador) GanadorEscalera(this List<Jugador> jugadores)
        {
            List<Jugador> jugadoresConEscaleraReal = new List<Jugador>();
            foreach (Jugador jugador in jugadores)
            {
                List<Carta> escaleraReferencia = new List<Carta>();
                int valorReferencia = jugador.cartas[0].Numero;

                for (int i = 0; i < 5; i++, valorReferencia--)
                {
                    escaleraReferencia.Add(new Carta(jugador.cartas[i].Palo, valorReferencia));
                }

                if (escaleraReferencia.SequenceEqual(jugador.cartas))
                {
                    jugadoresConEscaleraReal.Add(jugador);
                }

            }

            if (jugadoresConEscaleraReal.Count == 1)
            {
                return (true, jugadoresConEscaleraReal[0].Nombre + ", gana con Escalera");
            }
            else if (jugadoresConEscaleraReal.Count > 1)
            {
                return (true, jugadoresConEscaleraReal.GanadorCartaAlta() + ", gana con Escalera.");
            }
            return (false, "Null");
        }
        //Trio
        public static (bool respuesta, string ganador) GanadorTrio(this List<Jugador> jugadores)
        {
            List<Jugador> jugadoresConTrio = new List<Jugador>();
            foreach (Jugador jugador in jugadores)
            {
                if (jugador.Pareja(3) > -1)
                {
                    jugadoresConTrio.Add(jugador);
                }
            }

            if (jugadoresConTrio.Count == 1)
            {
                return (true, jugadoresConTrio[0].Nombre + ", gana con Trio.");
            }
            else if (jugadoresConTrio.Count > 1)
            {
                (bool respuesta, string ganador) desempateGanador = DesempateFullyTrio(jugadoresConTrio);
                return (desempateGanador.respuesta, desempateGanador.ganador + ", gana con Trio.");
            }
            return (false, "Null");
        }
        //Doble Pareja
        public static (bool respuesta, string ganador) GanadorDoblePareja(this List<Jugador> jugadores)
        {
            List<Jugador> jugadoresConDoblePareja = new List<Jugador>();
            foreach (Jugador jugador in jugadores)
            {
                if (jugador.SegundaPareja(jugador.Pareja(2)) > -1)
                {
                    jugadoresConDoblePareja.Add(jugador);
                }
            }
            if (jugadoresConDoblePareja.Count == 1)
            {
                return (true, jugadoresConDoblePareja[0].Nombre + ", gana con Doble Pareja.");
            }
            return jugadoresConDoblePareja.Count > 1 ? DesempateDoblePareja(jugadoresConDoblePareja) : (false, "Null");
        }
        //Pareja
        public static (bool respuesta, string ganador) GanadorPareja(this List<Jugador> jugadores)
        {
            List<Jugador> jugadoresConPareja = new List<Jugador>();
            foreach (Jugador jugador in jugadores)
            {
                if (jugador.Pareja(2) > -1)
                {
                    jugadoresConPareja.Add(jugador);
                }
            }
            if (jugadoresConPareja.Count == 1)
            {
                return (true, jugadoresConPareja[0].Nombre + ",gana con Pareja.");
            }
            return jugadoresConPareja.Count > 1 ? DesempatePareja(jugadoresConPareja) : (false, "Null");
        }
        //CartaAlta
        public static string GanadorCartaAlta(this List<Jugador> jugadores)
        {
            for (int i = 0; i < jugadores[0].cartas.Count; i++)
            {
                (bool respuesta, string ganador) cartaAltaObtenida = CartaMasAlta(jugadores, i);

                if (cartaAltaObtenida.respuesta) return cartaAltaObtenida.ganador;

                if (i == jugadores[0].cartas.Count-1)
                {
                    (bool respuesta, string ganador) ganador = GanadorPorMano(jugadores, i, 0);
                    if (ganador.respuesta) return ganador.ganador;
                }
            }

            return ("no hay carta alta");
        }
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

        //Desempates
        private static (bool respuesta, string ganador) DesempatePoker(List<Jugador> jugadores)
        {
            int max = -1;
            foreach (Jugador item in jugadores)
            {
                if (item.Pareja(4) > max)
                {
                    max = item.Pareja(4);
                }
            }

            foreach (Jugador item in jugadores)
            {
                if (item.Pareja(4) == max)
                {
                    return (true, item.Nombre + ", gana con Poker.");
                }
            }
            return (false, "Null");
        }
        private static (bool respuesta, string ganador) DesempateFullyTrio(List<Jugador> jugadores)
        {
            List<int> valoresParejas = new List<int>();
            List<Jugador> jugadoresConMaximo = new List<Jugador>();

            foreach (Jugador jugador in jugadores)
            {
                valoresParejas.Add(jugador.Pareja(3));
            }

            foreach (Jugador jugador in jugadores)
            {
                if (jugador.Pareja(3) == valoresParejas.Max())
                {
                    return (true, jugador.Nombre);
                }
            }
            return (false, "Null");

        }
        private static (bool respuesta, string ganador) DesempatePareja(List<Jugador> jugadores)
        {
           Jugador ganador = jugadores.OrderByDescending(x => x.Pareja(2)).First();
            List<Jugador> PrimeraParejaGanadora = new List<Jugador>();
            foreach (var item in jugadores)
            {
                if (item.Pareja(2) == ganador.Pareja(2))
                {
                    PrimeraParejaGanadora.Add(item);
                }
            }
            if (PrimeraParejaGanadora.Count == 1)
            {
                return (true, PrimeraParejaGanadora[0].Nombre + ",gana con Pareja.");
            }
            if (PrimeraParejaGanadora.Count > 1)
            {
                return (true, PrimeraParejaGanadora.GanadorCartaAlta() + ", gana con Pareja.");
            }
            return (false, "Null");
        }
        private static (bool respuesta, string ganador) DesempateDoblePareja(List<Jugador> jugadores)
        {
            Jugador ganador = jugadores.OrderByDescending(x => x.Pareja(2)).First();
            List<Jugador> PrimeraParejaGanadora = new List<Jugador>();
            List<Jugador> SegundaParejaGanadora = new List<Jugador>();
            foreach (var item in jugadores)
            {
                if (item.Pareja(2) == ganador.Pareja(2))
                {
                    PrimeraParejaGanadora.Add(item);
                }
            }
            ganador = PrimeraParejaGanadora.OrderByDescending(x => x.SegundaPareja(x.Pareja(2))).First();
            foreach (var item in jugadores)
            {
                if (item.SegundaPareja(item.Pareja(2)) == ganador.SegundaPareja(ganador.Pareja(2)))
                {
                    SegundaParejaGanadora.Add(item);
                }
            }
            if (SegundaParejaGanadora.Count == 1) 
            {
                return (true, SegundaParejaGanadora[0].Nombre + ",gana con Doble Pareja.");
            }
            if (SegundaParejaGanadora.Count > 1) 
            {
                return (true, jugadores.OrderByDescending(x => x.cartas[jugadores[0].cartas.Count - 1].Numero).First().Nombre + ", gana con Doble Pareja.");
            }
            return (false, "Null");
        }

        //Extensiones Utiles para el Programa  
        public static int Pareja(this Jugador jugador, int cartasEmparejadas)
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
                if (contador == cartasEmparejadas)
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

