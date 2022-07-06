using Barajas;
using Juego;
using Jugadores;
using Comprobaciones;
using HistorialPartidas;

int contador = 1;
HistorialDAO partidasJugadas = new HistorialDAO();
Historial historial = new Historial();

Console.WriteLine("-------------------------------MUS---------------------------------------");

List<Jugador> listaJugadoresMus = new List<Jugador>() { new Jugador("Manuel"), new Jugador("Maria"), new Jugador("Lole"), new Jugador("Pedro")};

try
{
    Mus mus = new Mus(listaJugadoresMus);

    mus.MostrarCartasJugadores();

    Console.WriteLine(String.Join("\n", mus.ComprobarGanadores()));

    historial = new Historial(contador, mus.ComprobarGanadores(),"Mus.", listaJugadoresMus.Count);
    partidasJugadas.GuardarPartida(historial);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
contador++;

Console.WriteLine("-------------------------------POKER---------------------------------------");

List<Jugador> listaJugadoresPoker = new List<Jugador>() { new Jugador("Manuel"), new Jugador("Maria"), new Jugador("Lole"), new Jugador("Pedro")};

try
{
    Poker poker = new Poker(listaJugadoresPoker);

    poker.MostrarCartasJugadores();

    Console.WriteLine(String.Join("\n", poker.ComprobarGanadores()));

    historial = new Historial(contador, poker.ComprobarGanadores(), "Poker.",listaJugadoresPoker.Count);
    partidasJugadas.GuardarPartida(historial);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
contador++;

Console.WriteLine();
Console.WriteLine("-------------------------------Historial Partidas---------------------------------------");
Console.WriteLine(partidasJugadas);
