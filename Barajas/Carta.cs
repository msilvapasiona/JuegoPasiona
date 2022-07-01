using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barajas
{
    public class Carta : IComparable<Carta>
    {
        public Carta(string palo, int numero)
        {
            Palo = palo;
            Numero = numero;
        }

        public string Palo { get; set; }
        public int Numero { get; set; }

        public int CompareTo(Carta? other)
        {
            if (this.Numero > other.Numero) return 1;
            if (this.Numero == other.Numero) return 0;
            return -1;
        }

        public override bool Equals(object? obj)
        {
            return obj is Carta carta && Palo == carta.Palo && Numero == carta.Numero;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Palo, Numero);
        }

        public override string ToString()
        {
            return Numero + " de " + Palo;
        }
    }
}
