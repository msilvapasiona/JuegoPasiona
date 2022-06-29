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

        public Baraja(ITipoCartas estiloCarta)
        {
            CrearBaraja(estiloCarta.Palos, estiloCarta.Numeros);
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

        public string MostrarCartas()
        {
            return String.Join("\n", listaCartas);
        }
    }
}
