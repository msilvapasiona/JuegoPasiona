
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barajas;
using Comprobaciones;
using Jugadores;

namespace Juego
{
    public class Mus : Juego
    {
        static int contador = 0;

        public Mus(string[] palos, int[] numeros, List<Jugador> jugadoresParam) : base(palos, numeros, jugadoresParam)
        {
            baraja = new Baraja(palos, numeros);
            jugadores = jugadoresParam;
            darCartas(jugadores);
        }

        public override string[] ComprobarGanadores()
        {
            ComprobacionesMUS comprobaciones = new ComprobacionesMUS();
            return new string[] {  comprobaciones.GanadorParejas(jugadores),   comprobaciones.GanadorJuego(jugadores),
                comprobaciones.GanadorCartaAlta(jugadores, 0), comprobaciones.GanadorCartaBaja(jugadores, 3)};
        }

        public override void darCartas(List<Jugador> jugadores)
        {
            foreach (Jugador jugador in jugadores)
            {
                int limite = contador + 4;
                jugador.cartas = new List<Carta>();
                for (contador = contador; contador < limite; contador++)
                {
                    jugador.cartas.Add(baraja.listaCartas[contador]);
                }
                jugador.cartas.Sort();
                jugador.cartas.Reverse();
            }
        }
    }
}
