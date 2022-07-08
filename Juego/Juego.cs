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
        public Juego(List<Jugador> jugadoresParam)
        {
        }

        public abstract void repartirCartas(List<Jugador> jugadores);
        public abstract string[] ComprobarGanadores();
        public abstract void MostrarCartasJugadores();
    }
}
