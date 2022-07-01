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
            List<Jugador> escaleraColor = jugadores.ToList();
            List<Jugador> poker = jugadores.ToList();
            List<Jugador> full = jugadores.ToList();
            List<Jugador> color = jugadores.ToList();
            List<Jugador> escalera = jugadores.ToList();
            List<Jugador> trio = jugadores.ToList();
            List<Jugador> doblePareja = jugadores.ToList();
            List<Jugador> pareja = jugadores.ToList();
            List<Jugador> cartaAlta = jugadores.ToList();

            (bool respuesta, string ganador)[] jugadas = new(bool, string)[] {EscaleraReal(escaleraReal), EscaleraColor(escaleraColor)};

            foreach (var item in jugadas)
            {
                if (item.respuesta)
                {
                    return item.ganador;
                }
            }
            return "Null Nadie tiene nada";
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
           
            return jugadoresConEscaleraReal.Count>1 ? DesempatePorManoEscaleras(jugadoresConEscaleraReal) : (false,"Null");
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

        //EscaleraColor
        private (bool respuesta, string ganador) EscaleraColor(List<Jugador> jugadores)
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
            else
            {
                return DesempatePorManoEscaleras(jugadoresConColor);
            }
            return (false, "Null");
        }

        //Desempate Por Mano
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
    }
}
