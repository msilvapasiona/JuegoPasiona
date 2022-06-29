using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barajas
{
    public interface ITipoCartas
    {
        public string[] Palos { get; set; }
        public int[] Numeros { get; set; }
    }
}
