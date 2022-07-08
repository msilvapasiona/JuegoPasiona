using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barajas
{
    public class Baraja:IBaraja
    {
        public List<Carta> listaCartas= new List<Carta>();

        public Baraja(IPalosNumeros carta)
        {
            CrearBaraja(carta.Palos, carta.Numeros);
            Barajar();
        }

        public void CrearBaraja(string[] palos, int[] numeros)
        {
            foreach (string palo in palos)
            {
                foreach (int numero in numeros)
                {
                    listaCartas.Add(new Carta(palo, numero));
                }
            }
        }

        public void Barajar()
        {
            for (int i = 0; i < listaCartas.Count - 1; i++)
            {
                Random random = new Random();
                int posicionRandom = random.Next(0, listaCartas.Count - 1);
                Carta auxiliar = listaCartas[i];
                listaCartas[i] = listaCartas[posicionRandom];
                listaCartas[posicionRandom] = auxiliar;
            }
        }

        public List<Carta> DarCarta(int cartasPorJugador)
        {
            List<Carta> cartasJugador = new List<Carta>();
            while (cartasJugador.Count != cartasPorJugador)
            {
                cartasJugador.Add(listaCartas[0]);
                listaCartas.RemoveAt(0);
            }
            return cartasJugador.OrderByDescending(x => x.Numero).ToList();
        }
        public string MostrarCartas()
        {
            return String.Join("\n", listaCartas);
        }
    }
}
