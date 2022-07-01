using Jugadores;
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
    public class Poker : Juego
    {
        static int jugadoresMinimos = 2;
        static int jugadoresMaximo = 10;
        static int contador = 0;
        public static IDictionary<int, string> numeros = new Dictionary<int, string>();
        
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
            Carta auxiliar = new Carta("picas",13);
            jugadores[0].cartas.Add(auxiliar);
            auxiliar = new Carta("picas", 12);
            jugadores[0].cartas.Add(auxiliar);

            auxiliar = new Carta("picas", 11);
            jugadores[0].cartas.Add(auxiliar);

            auxiliar = new Carta("picas", 10);
            jugadores[0].cartas.Add(auxiliar);

            auxiliar = new Carta("picas", 9);
            jugadores[0].cartas.Add(auxiliar);


            auxiliar = new Carta("picas", 14);
            jugadores[1].cartas.Add(auxiliar);
            auxiliar = new Carta("picas", 13);
            jugadores[1].cartas.Add(auxiliar);

            auxiliar = new Carta("picas", 12);
            jugadores[1].cartas.Add(auxiliar);

            auxiliar = new Carta("picas", 11);
            jugadores[1].cartas.Add(auxiliar);

            auxiliar = new Carta("picas", 10);
            jugadores[1].cartas.Add(auxiliar);


            /* foreach (Jugador jugador in jugadores)
             {
                 int limite = contador + 5;
                 jugador.cartas = new List<Carta>();
                 for (contador = contador; contador < limite; contador++)
                 {
                     jugador.cartas.Add(baraja.listaCartas[contador]);
                 }
                 jugador.cartas.Sort();
                 jugador.cartas.Reverse();
             }*/
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
                    string valor = "";
                    numeros.TryGetValue(carta.Numero, out valor!);
                    Console.WriteLine($"{valor} de {carta.Palo}");
                }
                Console.WriteLine();
            };
        }

        public static void ValoresNumeros()
        {
            numeros.Add(2, "Dos");
            numeros.Add(3, "Tres");
            numeros.Add(4, "Cuatro");
            numeros.Add(5, "Cinco");
            numeros.Add(6, "Seis");
            numeros.Add(7, "Siete");
            numeros.Add(8, "Ocho");
            numeros.Add(9, "Nueve");
            numeros.Add(10, "Diez");
            numeros.Add(11, "J");
            numeros.Add(12, "Q");
            numeros.Add(13, "K");
            numeros.Add(14, "AS");
        }
    }
}
