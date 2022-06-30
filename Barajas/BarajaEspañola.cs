using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barajas
{
    public class BarajaEspañola : IPalosNumeros
    {
        public BarajaEspañola()
        {
            Palos = new string[] { "oros", "copas", "bastos", "espadas" };
            Numeros = new int[] { 1, 2, 3, 4, 5, 6, 7, 10, 11, 12 };
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
