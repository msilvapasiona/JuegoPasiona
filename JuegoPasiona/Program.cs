using Barajas;
using Juego;
using Jugadores;
using Comprobaciones;

Console.WriteLine("-------------------------------MUS---------------------------------------");

List<Jugador> listaJugadoresMus = new List<Jugador>() { new Jugador("Manuel"), new Jugador("Maria"), new Jugador("Lole"), new Jugador("Pedro")};

try
{
    Mus mus = new Mus(listaJugadoresMus);

    mus.MostrarCartasJugadores();

    Console.WriteLine(String.Join("\n", mus.ComprobarGanadores()));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


Console.WriteLine("-------------------------------POKER---------------------------------------");

List<Jugador> listaJugadoresPoker = new List<Jugador>() { new Jugador("Manuel"), new Jugador("Maria")/*, new Jugador("Lole"), new Jugador("Pedro")*/};

try
{
    Poker poker = new Poker(listaJugadoresPoker);

    poker.MostrarCartasJugadores();

    Console.WriteLine(String.Join("\n", poker.ComprobarGanadores()));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
