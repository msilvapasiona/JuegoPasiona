using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barajas;
namespace Jugadores
{
    public class Jugador
    {
        public string Nombre { get; set; }
        public List<Carta> cartas
        {
            get; set;
        } = new List<Carta>();

        public Jugador(string nombre)
        {
            Nombre = nombre;
        }

        public List<Carta> MostrarMano()
        {
            return cartas;
        }

        public override bool Equals(object? obj)
        {
            return obj is Jugador jugador &&
                   Nombre == jugador.Nombre &&
                   EqualityComparer<List<Carta>>.Default.Equals(cartas, jugador.cartas);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nombre, cartas);
        }
    }
}
