using Barajas;
using Juego;
using Jugadores;
using Comprobaciones;
using HistorialPartidas;


int contador = 1;
HistorialDAO partidasJugadas = new HistorialDAO();
Historial historial = new Historial();


Console.WriteLine("-------------------------------MUS---------------------------------------");

List<Jugador> listaJugadores = new List<Jugador>() { new Jugador("Manuel"), new Jugador("Maria"), new Jugador("Lole"), new Jugador("Pedro")};

try
{
    Mus juego = new Mus(listaJugadores);

    juego.MostrarCartasJugadores();

    Console.WriteLine(String.Join("\n", juego.ComprobarGanadores()));

    historial = new Historial(contador, juego.ComprobarGanadores(), juego.GetType().Name+".", listaJugadores.Count);
    partidasJugadas.GuardarPartida(historial);
    contador++;
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}




Console.WriteLine("-------------------------------POKER---------------------------------------");

try
{
    Poker juego = new Poker(listaJugadores);

    juego.MostrarCartasJugadores();

    Console.WriteLine(String.Join("\n", juego.ComprobarGanadores()));

    historial = new Historial(contador, juego.ComprobarGanadores(), juego.GetType().Name+".",listaJugadores.Count);
    partidasJugadas.GuardarPartida(historial);
    contador++;
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}




Console.WriteLine("-------------------------------Historial Partidas---------------------------------------");
Console.WriteLine(partidasJugadas);
