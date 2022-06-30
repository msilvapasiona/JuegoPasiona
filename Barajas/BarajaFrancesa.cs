using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barajas
{
    public class BarajaFrancesa:IPalosNumeros
    {
        IDictionary<string, int> numeros = new Dictionary<string, int>();

        public BarajaFrancesa()
        {
            Palos = new string[] { "picas", "treboles", "corazones", "diamantes"};
            Numeros = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
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
