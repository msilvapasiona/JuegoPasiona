
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
        private static string[] palos = new string[] { "oros", "copas", "bastos", "espadas" };
        private static int[] numeros = new int[] { 1, 2, 3, 4, 5, 6, 7, 10, 11, 12 };
        private static CartasTipo cartas = new CartasTipo(palos, numeros);
        public Mus(List<Jugador> jugadoresParam) : base(cartas, jugadoresParam)
        {
            baraja = new Baraja(cartas);
            jugadores = jugadoresParam;
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
                jugador.cartas = new List<Carta>();
                for (contador = contador; contador < limite; contador++)
                {
                    jugador.cartas.Add(baraja.listaCartas[contador]);
                }
                jugador.cartas.Sort();
                jugador.cartas.Reverse();
            }
        }

        public override void MostrarCartasJugadores()
        {
            Console.WriteLine();
            foreach (Jugador jugador in jugadores)
            {
                int puntos = 0;
                Console.WriteLine("Jugador: " + jugador.Nombre);
                foreach (Carta carta in jugador.cartas)
                {
                    puntos += carta.Numero;
                    Console.WriteLine(carta);
                }
                Console.WriteLine($"Puntos Totales = {puntos}");
                Console.WriteLine();
            }
        }
    }
}
