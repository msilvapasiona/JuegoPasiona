using Jugadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barajas;

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
            List<Jugador> escaleraReal = jugadores.ToList();
            (bool respuesta, string ganador) ganadorEscaleraReal = EscaleraReal(escaleraReal);
            return ganadorEscaleraReal.ganador;
        }

        //EscaleraReal
        private (bool respuesta, string ganador) EscaleraReal(List<Jugador> jugadores)
        {
            List<Jugador> jugadoresConEscaleraReal = new List<Jugador>();
            foreach (Jugador jugador in jugadores)
            {
                List<Carta> escaleraReferencia = new List<Carta>();
                string paloReferencia = jugador.cartas[0].Palo;

                int valorReferencia = jugador.cartas[0].Numero;

                for (int i = 0; i < 5; i++)
                {
                    escaleraReferencia.Add(new Carta(paloReferencia, valorReferencia));
                    valorReferencia--;
                }

                if (ComprobacionesEscaleraRealValida(escaleraReferencia, jugador.cartas))
                {
                    jugadoresConEscaleraReal.Add(jugador);
                }
                   
            }

            if (jugadoresConEscaleraReal.Count == 1)
            {
                return (true, jugadoresConEscaleraReal[0].Nombre);
            }
            else
            {
                return DesempateEscaleraReal(jugadoresConEscaleraReal);
            }
            return (false, "Null");
        }
        private bool ComprobacionesEscaleraRealValida(List<Carta> referencia, List<Carta> jugadorCartas)
        {
            for (int i = 0; i < referencia.Count; i++)
            {
                if ( !(referencia[i].Equals(jugadorCartas[i])) )
                {
                    return false;
                }
            }
            return true;
        }
        private (bool respuesta, string ganador) DesempateEscaleraReal(List<Jugador> jugadores)
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

    }
}
