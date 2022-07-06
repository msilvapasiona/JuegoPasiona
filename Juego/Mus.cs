 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comprobaciones;
using Jugadores;
using Barajas;

namespace Juego
{
    public class Mus : Juego
    {
        int jugadoresPermitidos = 4;
        static int contador = 0;
        public Mus(List<Jugador> jugadoresParam) : base(jugadoresParam)
        {
            if (jugadoresParam.Count != jugadoresPermitidos)
            {
                throw new Exception($"No se puede empezar un mus con esta cantidad de jugadores: {jugadoresParam.Count}. (Se necesita tener entre 4 jugadores)");

            }
            baraja = new Baraja(new BarajaEspañola());
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
