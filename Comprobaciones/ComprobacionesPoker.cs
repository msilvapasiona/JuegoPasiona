using Jugadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comprobaciones
{
    public class ComprobacionesPoker : IComprobacion
    {
        public string[] ganadores(List<Jugador> jugadores)
        {
            return new string[] {"Ganador Soy."};
        }

    }
}
