using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jugadores;
using Barajas;

namespace Juego
{
    public abstract class Juego
    {
        private static string[] palos;
        private static int[] numeros;
        private static CartasTipo cartas;
        public Baraja baraja { get; set; }
        public List<Jugador> jugadores { get; set; }
        public Juego(ITipoCartas cartas, List<Jugador> jugadoresParam)
        {
            baraja = new Baraja(cartas);
            jugadores = jugadoresParam;
            darCartas(jugadores);
        }

        public abstract void darCartas(List<Jugador> jugadores);
        public abstract string[] ComprobarGanadores();
        public abstract void MostrarCartasJugadores();
    }
}
