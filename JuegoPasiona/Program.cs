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
    Mus juego = new Mus(listaJugadoresMus);

    juego.MostrarCartasJugadores();

    Console.WriteLine(String.Join("\n", juego.ComprobarGanadores()));

    historial = new Historial(contador, juego.ComprobarGanadores(), juego.GetType().Name+".", listaJugadoresMus.Count);
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
    Poker juego = new Poker(listaJugadoresPoker);

    juego.MostrarCartasJugadores();

    Console.WriteLine(String.Join("\n", juego.ComprobarGanadores()));

    historial = new Historial(contador, juego.ComprobarGanadores(), juego.GetType().Name+".",listaJugadoresPoker.Count);
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
