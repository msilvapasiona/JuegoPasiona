using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barajas
{
    internal interface IBaraja
    {
        public void CrearBaraja(string[]palos, int[] numeros);
        public void Barajar();
        public string MostrarCartas();
    }
}
