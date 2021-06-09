using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaLogica
{
  public  class LtipoSala
    {
        public static DataTable MostrarTipoSala()
        {
            return new DtipoSala().MostrarTipoSala();
        }
    }
}
