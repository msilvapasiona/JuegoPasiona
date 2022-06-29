using Barajas;
using Juego;
using Jugadores;
using Comprobaciones;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string[] palo = new string[] { "oros", "copas", "bastos", "espadas" };
int[] numeros = new int[] { 1, 2, 3, 4, 5, 6, 7, 10, 11, 12 };
CartasTipo palosYNumeros = new CartasTipo(palo, numeros);

Jugador manuel = new Jugador("Manuel");
Jugador maria = new Jugador("Maria");
Jugador pedro = new Jugador("Pedro");
Jugador lole = new Jugador("Lole");
List<Jugador> listaJugadores = new List<Jugador>();
listaJugadores.Add(manuel);
listaJugadores.Add(maria);
listaJugadores.Add(lole);
listaJugadores.Add(pedro);


Mus mus = new Mus(palosYNumeros, listaJugadores);

foreach (Jugador jugador in mus.jugadores)
{
    Console.WriteLine("Jugador: " + jugador.Nombre);
    foreach (Carta carta in jugador.cartas)
    {
        Console.WriteLine(carta);
    }
    Console.WriteLine();
}

string[] ganadores = mus.ComprobarGanadores();

foreach (var item in ganadores)
{
    Console.WriteLine(item);
}