using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaLogica
{
  public class LBarrio
    {
        public static DataTable Mostrar()
        {
            return new DBarrio().Mostrar();
        }
    }
}
