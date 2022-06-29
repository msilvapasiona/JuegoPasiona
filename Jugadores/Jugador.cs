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
        }

        public Jugador(string nombre)
        {
            Nombre = nombre;
        }

        public List<Carta> MostrarMano()
        {
            return cartas;
        }
    }
}
