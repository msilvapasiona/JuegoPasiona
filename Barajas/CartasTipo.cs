using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barajas
{
    public class CartasTipo : ITipoCartas
    {
        public CartasTipo(string[] palo, int[] numeros)
        {
            Palos = new string[palo.Length];
            Numeros = new int[numeros.Length];
            Palos = palo;
            Numeros = numeros;
        }

        public string[] Palos
        {
            get;
            set;
        }
        public int[] Numeros
        {
            get;
            set;
        }
    }
}
