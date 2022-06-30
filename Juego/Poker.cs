using Jugadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comprobaciones;
using Jugadores;
using Barajas;

// https://www.888poker.es/blog/poker-de-ases Pagina para visualizar comprobaciones de poker.


namespace Juego
{
    public class Poker : Juego
    {
        int jugadoresMinimos = 2;
        int jugadoresMaximo = 10;
        static int contador = 0;

        public Poker(List<Jugador> jugadoresParam) : base(jugadoresParam) 
        {
            if (jugadoresParam.Count < jugadoresMinimos || jugadoresParam.Count > jugadoresMaximo)
            {
                throw new Exception($"No se puede empezar un poker con esta cantidad de jugadores: {jugadoresParam.Count}. (Se necesita tener entre 2 y 10 jugadores)");
            }
            baraja = new Baraja(new BarajaFrancesa());
            jugadores = jugadoresParam;
            darCartas(jugadores);
        }

        public override string[] ComprobarGanadores()
        {
            ComprobacionesPoker poker = new ComprobacionesPoker();
            return poker.ganadores(jugadores);
        }

        public override void darCartas(List<Jugador> jugadores)
        {
            foreach (Jugador jugador in jugadores)
            {
                int limite = contador + 5;
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
                Console.WriteLine();
            };
        }
    }
}
