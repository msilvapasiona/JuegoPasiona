using Jugadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barajas;
using ExtensionesPoker;

// https://www.888poker.es/blog/poker-de-ases Pagina para visualizar comprobaciones de poker.
namespace Comprobaciones
{
    public class ComprobacionesPoker : IComprobacion
    {
        public string[] ganadores(List<Jugador> jugadores)
        {

            return new string[] {Ganador(jugadores)};
        }

        private string Ganador(List<Jugador> jugadores)
        {
            List<Jugador> auxiliar = jugadores.ToList();

            (bool respuesta, string ganador)[] jugadas = new(bool, string)[] {EscaleraColor(auxiliar), Color(auxiliar), Poker(auxiliar) };

            foreach (var item in jugadas)
            {
                if (item.respuesta)
                {
                    return item.ganador;
                }
            }
            return "Nadie tiene nada";
        }

        
        //EscaleraReal
        private (bool respuesta, string ganador)EscaleraReal(List<Jugador> jugadores)
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

            if (jugadoresConEscaleraReal.Count == 1)
            {
                return (true, jugadoresConEscaleraReal[0].Nombre +", con escalera Real.");
            }
            else if (jugadoresConEscaleraReal.Count > 1)
            {
                (bool respuesta, string ganador) desempateGanador = DesempatePorManoEscaleras(jugadoresConEscaleraReal);
                return (desempateGanador.respuesta, desempateGanador.ganador + ", con escalera Real.");
            }
            return (false, "Null");
        }

        //EscaleraColor
        private (bool respuesta, string ganador) EscaleraColor(List<Jugador> jugadores)
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
                return (true, jugadoresConEscaleraColor[0].Nombre + ", con escalera de color.");
            }
            else if (jugadoresConEscaleraColor.Count > 1)
            {
                (bool respuesta, string ganador) desempateGanador = DesempatePorManoEscaleras(jugadoresConEscaleraColor);
                return (desempateGanador.respuesta, desempateGanador.ganador + ", con escalera de color.");
            }
            return (false, "Null");
        }

        //Poker
        private (bool respuesta, string ganador) Poker(List<Jugador> jugadores)
        {
            List<Jugador> jugadoresConPoker = new List<Jugador>();
            int max = -1;
            foreach (Jugador jugador in jugadores)
            {
                if (jugador.MaxPoker() > max)
                {
                    jugadoresConPoker.Add(jugador);
                }
            }

            if (jugadoresConPoker.Count == 1)
            {
                return (true, jugadoresConPoker[0].Nombre + "con Poker.");
            }
            return jugadoresConPoker.Count > 1 ? DesempatePoker(jugadoresConPoker) : (false, "Null");
        }

        //Full
        private(bool respuesta, string nombre) Full(List<Jugador> jugadores)
        {
            List<Jugador> jugadoresConFull = new List<Jugador>();
            foreach (Jugador jugador in jugadores)
            {
                if (jugador.Trio() != -1 && jugador.SegundaPareja(jugador.Trio()) != -1)
                {
                    jugadoresConFull.Add(jugador);
                }
            }

            if (jugadoresConFull.Count == 1)
            {
                return (true, jugadoresConFull[0].Nombre);
            }
            return jugadoresConFull.Count > 1 ? DesempateFull(jugadoresConFull) : (false, "Null");
        }

        //Color
        private (bool respuesta, string ganador) Color(List<Jugador> jugadores)
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
                return (true, jugadoresConColor[0].Nombre);
            }
            return jugadoresConColor.Count > 1 ? DesempatePorManoEscaleras(jugadoresConColor) : (false, "Null");
        }

        //Escalera

        private (bool respuesta, string ganador) Escalera(List<Jugador> jugadores)
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
                return (true, jugadoresConEscaleraReal[0].Nombre);
            }

            return jugadoresConEscaleraReal.Count > 1 ? DesempatePorManoEscaleras(jugadoresConEscaleraReal) : (false, "Null");
        }

        //Trio
        private(bool respuesta, string ganador) Trio(List<Jugador> jugadores)
        {
            return (false, "Null");
        }
        //DoblePareja

        //Pareja

        //CartaAlta



        //Desempates
        private (bool respuesta, string ganador) DesempatePorManoEscaleras(List<Jugador> jugadores)
        {
            int max = -1;

            foreach (Jugador jugador in jugadores)
            {
                if (jugador.cartas[0].Numero > max)
                {
                    max = jugador.cartas[0].Numero;
                }
            }

            foreach (Jugador jugador in jugadores)
            {
                if (jugador.cartas[0].Numero == max)
                {
                    return (true, jugador.Nombre);
                }
            }

            return (false, "Null");
        }

        private (bool respuesta, string ganador) DesempatePoker(List<Jugador> jugadores)
        {
            int max = -1;
            foreach (Jugador item in jugadores)
            {
                if (item.MaxPoker() > max)
                {
                    max = item.MaxPoker();
                }
            }

            foreach (Jugador item in jugadores)
            {
                if (item.MaxPoker()== max)
                {
                    return (true, item.Nombre);
                }
            }
            return (false, "Null");
        }

        private (bool respuesta, string ganador) DesempateFull(List<Jugador> jugadores)
        {
            List<int> valoresParejas = new List<int>();
            List<Jugador> jugadoresConMaximo = new List<Jugador>();

            foreach (Jugador jugador in jugadores)
            {
                valoresParejas.Add(jugador.Trio());
            }

            foreach (Jugador jugador in jugadores)
            {
                if (jugador.Trio() == valoresParejas.Max())
                {
                    jugadoresConMaximo.Add(jugador);
                }
            }

            if (jugadoresConMaximo.Count == 1)
            {
                return (true, jugadoresConMaximo[0].Nombre);
            }
            return (false, "Null");

        }
    }
}
