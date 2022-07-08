
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
        int numeroDeCartasPorJugador = 4;

        public static IDictionary<int, string> numeros = new Dictionary<int, string>();
        public Mus(List<Jugador> jugadoresParam) : base(jugadoresParam)
        {
            if (jugadoresParam.Count != jugadoresPermitidos)
            {
                throw new Exception($"No se puede empezar un mus con esta cantidad de jugadores: {jugadoresParam.Count}. (Se necesita tener entre 4 jugadores)");

            }
            baraja = new Baraja(new BarajaEspañola());
            jugadores = jugadoresParam;
            repartirCartas(jugadores);
        }

        public override string[] ComprobarGanadores()
        {
            ComprobacionesMUS comprobaciones = new ComprobacionesMUS();
            return comprobaciones.ganadores(jugadores);
        }

        public override void repartirCartas(List<Jugador> jugadores)
        {
            foreach (Jugador jugador in jugadores)
            {
                jugador.cartas = baraja.DarCarta(numeroDeCartasPorJugador);
            }
        }

        public override void MostrarCartasJugadores()
        {
            ValoresNumeros();
            Console.WriteLine();
            foreach (Jugador jugador in jugadores)
            {
                int puntos = 0;
                Console.WriteLine("Jugador: " + jugador.Nombre);
                foreach (Carta carta in jugador.cartas)
                {
                    puntos += carta.Numero;
                    string valor = "";
                    numeros.TryGetValue(carta.Numero, out valor!);
                    Console.WriteLine($"{valor} de {carta.Palo}");
                }
                Console.WriteLine($"Puntos Totales = {puntos}");
                Console.WriteLine();
            };
        }
        public static void ValoresNumeros()
        {
            numeros.Add(1, "1");
            numeros.Add(2, "2");
            numeros.Add(3, "3");
            numeros.Add(4, "4");
            numeros.Add(5, "5");
            numeros.Add(6, "6");
            numeros.Add(7, "7");
            numeros.Add(10, "Sota");
            numeros.Add(11, "Caballo");
            numeros.Add(12, "Rey");
        }
    }
}
