using Barajas;
using Juego;
using Jugadores;
using Comprobaciones;

List<Jugador> listaJugadores = new List<Jugador>() { new Jugador("Manuel"), new Jugador("Maria"), new Jugador("Lole"), new Jugador("Pedro") };

Mus mus = new Mus(listaJugadores);

mus.MostrarCartasJugadores();

Console.WriteLine(String.Join("\n", mus.ComprobarGanadores()));
