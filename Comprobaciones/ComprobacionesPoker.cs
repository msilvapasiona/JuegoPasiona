using Jugadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barajas;
using ExtensionesPoker;

namespace Comprobaciones
{
    public class ComprobacionesPoker : IComprobacion
    {
        public string[] ganadores(List<Jugador> jugadores)
        {

            return new string[] {Ganador(jugadores)};
        }

        private string Ganador(List<Jugador> jugadores)
        {
            List<Jugador> auxiliar = jugadores.ToList();

            (bool respuesta, string ganador)[] jugadas = new (bool, string)[] { auxiliar.GanadorEscaleraReal(),
                                                                                auxiliar.GanadorEscaleraColor(),
                                                                                auxiliar.GanadorPoker(),
                                                                                auxiliar.GanadorFull(),
                                                                                auxiliar.GanadorColor(),
                                                                                auxiliar.GanadorEscalera(),
                                                                                auxiliar.GanadorTrio(),
                                                                                auxiliar.GanadorDoblePareja(),
                                                                                auxiliar.GanadorPareja()
                                                                              };
            foreach (var item in jugadas)
            {
                if (item.respuesta)
                {
                    return item.ganador;
                }
            }
            return auxiliar.GanadorCartaAlta() + ", gana por Carta Alta.";
        }
    }
}
