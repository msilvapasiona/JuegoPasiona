using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jugadores;
using Barajas;
using ExtensionesMus;
namespace Comprobaciones
{
    public class ComprobacionesMUS : IComprobacion
    {
        public string[] ganadores(List<Jugador> jugadores)
        {
            List<Jugador> cartaAlta = new List<Jugador>(jugadores);

            List<Jugador> cartaBaja = new List<Jugador>(jugadores);

            List<Jugador> juego = new List<Jugador>(jugadores);

            List<Jugador> pares = new List<Jugador>(jugadores);

            return new string[] {$"Ganador Carta Alta:{   cartaAlta.GanadorCartaAlta()   }", 
                                 $"Ganador Carta Baja:{   cartaBaja.GanadorCartaBaja()   }", 
                                 $"Ganador Juego: {        juego.GanadorJuego()           }", 
                                 $"Ganador Parejas: {      pares.GanadorParejas()         }"}; 
        }
    }
}
