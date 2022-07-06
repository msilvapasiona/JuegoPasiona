using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistorialPartidas
{
    public class Historial
    {
        public Historial()
        {
        }

        public Historial(int id, string[] ganador_es, string juego, int jugadoresTotales)
        {
            IdPartida = id;
            Ganador_es = ganador_es;
            Juego = juego;
            JugadoresTotales = jugadoresTotales;    
        }

        public int IdPartida { get; set; }
        public string[] Ganador_es { get; set; }

        public int JugadoresTotales { get; set; }
        public string Juego { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Historial historial &&
                   IdPartida == historial.IdPartida;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdPartida);
        }

        public override string ToString()
        {
            return $"*Id Partida: {IdPartida}. \n" +
                $"*Jugadores en Total = {JugadoresTotales}. \n"+
                $"*Ganador/es: \n -{String.Join("\n -", Ganador_es)} " +
                $"" +
                $"\n *Juego: {Juego} ";
        }
    }
}
