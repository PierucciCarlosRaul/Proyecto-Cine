using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaLogica
{
  public class Lcalificacion
    {
        public static DataTable MostrarCalificaciones()
        {
            return new Dcalificacion().MostrarCalificaciones();
        }
    }
}
