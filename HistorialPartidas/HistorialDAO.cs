using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistorialPartidas
{
    public class HistorialDAO
    {
        private IDictionary<int, Historial> _historialPartidas = new Dictionary<int,Historial>();

        public IDictionary<int, Historial> ObtenerListaPartidas()
        {
            return _historialPartidas;
        }

        public Historial GuardarPartida(Historial historial)
        {
            if (!_historialPartidas.ContainsKey(historial.IdPartida))
            {
                _historialPartidas.Add(historial.IdPartida, historial);
                return historial;
            }
            return null;
        }

        public override string ToString()
        {
            return String.Join("\n \n", _historialPartidas);
        }
    }
}
