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
        public Baraja baraja { get; set; }
        public List<Jugador> jugadores { get; set; }
        public Juego(string[] palos, int[] numeros, List<Jugador> jugadoresParam)
        {
            baraja = new Baraja(palos, numeros);
            jugadores = jugadoresParam;
            darCartas(jugadores);
        }

        public abstract void darCartas(List<Jugador> jugadores);
        public abstract string[] ComprobarGanadores();
    }
}
