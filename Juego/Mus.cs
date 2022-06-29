
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
        public Mus(ITipoCartas tipoCartas, List<Jugador> jugadoresParam) : base(tipoCartas, jugadoresParam)
        {
            this.baraja = new Baraja(tipoCartas);
            this.jugadores.AddRange(jugadoresParam);
            darCartas(jugadores);
        }

        public override string[] ComprobarGanadores()
        {
            ComprobacionesMUS comprobaciones = new ComprobacionesMUS();
            return comprobaciones.ganadores(jugadores);
        }

        public override void darCartas(List<Jugador> jugadores)
        {
            foreach (Jugador jugador in jugadores)
            {
                int limite = contador + 4;

                for (contador = contador; contador < limite; contador++)
                {
                    jugador.cartas = new List<Carta>();
                    jugador.cartas.Add(baraja.listaCartas[contador]);
                }
                jugador.cartas.Sort();
                jugador.cartas.Reverse();
            }
        }
    }
}
